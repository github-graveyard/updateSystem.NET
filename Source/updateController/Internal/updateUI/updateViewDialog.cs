using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using updateSystemDotNet.Internal.updateUI.Views;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal.updateUI {
	[Flags]
	internal enum updateViewStates {
		Search = 2,
		Display = 4,
		Download = 8,
	}

	internal class updateViewDialog : Form {
		private const int _maximumStatusWidth = 370;
		private const string _nameBtnCancel = "btnCancel";
		private const string _nameBtnInstallUpdate = "btnInstallUpdate";
		private const string _nameBtnPanel = "pnlButtons";
		private const string _nameLblStatus = "lblStatus";
		private const string _namePnlView = "pnlView";
		private const int _spaceToBorder = 12;
		private const int _spaceToControl = 6;
		private Image _appImage;
		private Rectangle _rectangleImage;

		public updateViewDialog(updateController instance) {
			controllerInstance = instance;
			dataExchange = new Dictionary<string, object>();
			initializeComponents();
		}

		public updateController controllerInstance { get; set; }

		public Dictionary<string, object> dataExchange { get; private set; }

		public updateViewStates availableViewStates { get; set; }

		#region " ControlManagement "

		private Button btnCancelUpdate;
		private Button btnInstallUpdate;
		private FlowLayoutPanel buttonPanel;
		private Label lblStatus;
		private Panel pnlView;

		private void initializeComponents() {
			//Form initialisieren
			Font = SystemFonts.MessageBoxFont;
			BackColor = Color.White;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MinimizeBox = false;
			MaximizeBox = false;
			ShowInTaskbar = controllerInstance.showDialogsInTaskbar;
			StartPosition = FormStartPosition.CenterScreen;
			MinimumSize = new Size(100, 100);
			MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Text = "updateSystem.NET";

			//Anwendungssymbol
			_rectangleImage = new Rectangle(new Point(_spaceToBorder, _spaceToBorder), new Size(32, 32));

			//Statuslabel
			lblStatus = new Label {
			                      	Name = _nameLblStatus,
			                      	AutoSize = true,
			                      	Location =
			                      		new Point((_rectangleImage.X + _rectangleImage.Width + _spaceToControl), _spaceToBorder),
			                      	Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12),
			                      	ForeColor = Color.FromArgb(0, 51, 153),
			                      	//BackColor = Color.Black
			                      };

			//Buttonpanel
			buttonPanel = new FlowLayoutPanel {
			                                  	Name = _nameBtnPanel,
			                                  	Dock = DockStyle.Bottom,
			                                  	Padding = new Padding(4, 4, 4, 4),
			                                  	Margin = new Padding(10),
			                                  	AutoSize = true,
			                                  	FlowDirection = FlowDirection.RightToLeft
			                                  };
			buttonPanel.Paint += buttonPanel_Paint;

			//InstallButton
			btnInstallUpdate = new Button {
			                              	Name = _nameBtnInstallUpdate,
			                              	Margin = new Padding(4, 4, 4, 4),
			                              	AutoSize = true,
			                              	FlatStyle = FlatStyle.System,
			                              	Text = "Installieren"
			                              };
			btnInstallUpdate.Click += btnInstallUpdate_Click;
			//UAC-Schild anzeigen?
			if (Environment.OSVersion.Version.Major >= 6 && !IsUserAnAdmin() && controllerInstance.requestElevation) {
				SendMessage(new HandleRef(btnInstallUpdate, btnInstallUpdate.Handle), 0x160c, IntPtr.Zero, new IntPtr(1));
				btnInstallUpdate.MinimumSize = new Size(
					btnInstallUpdate.Width + 20, //Etwas Platz für das Schildicon herausschlagen
					btnInstallUpdate.Height);
			}

			//CancelButton
			btnCancelUpdate = new Button {
			                             	Name = _nameBtnCancel,
			                             	Margin = new Padding(4, 4, 4, 4),
			                             	AutoSize = true,
			                             	FlatStyle = FlatStyle.System,
			                             	Text = "Abbrechen"
			                             };

			//View
			pnlView = new Panel {
			                    	Name = _namePnlView,
			                    	AutoSize = true,
			                    	AutoSizeMode = AutoSizeMode.GrowAndShrink,
			                    	//BackColor = Color.Red
			                    };

			buttonPanel.Controls.AddRange(new Control[] {btnCancelUpdate, btnInstallUpdate});

			//Controls zur Form hinzufügen
			Controls.AddRange(new Control[] {lblStatus, buttonPanel, pnlView});

			updateSizes();
		}

		private void btnInstallUpdate_Click(object sender, EventArgs e) {
			if ((availableViewStates & updateViewStates.Download) == updateViewStates.Download)
				loadView<viewUpdateDownloadAndApply>();
			else {
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void buttonPanel_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(SystemColors.Control);
			e.Graphics.DrawLine(SystemPens.ControlLight, new Point(0, 0), new Point(e.ClipRectangle.Width, 0));
		}

		private void updateSizes() {
			lblStatus.MinimumSize = new Size(
				_maximumStatusWidth,
				40);
			lblStatus.MaximumSize = new Size(
				_maximumStatusWidth,
				Screen.PrimaryScreen.WorkingArea.Height);

			pnlView.MinimumSize = new Size(
				ClientRectangle.Width - (2*_spaceToBorder),
				50);
			pnlView.MaximumSize = new Size(
				ClientRectangle.Width - (2*_spaceToBorder),
				Screen.PrimaryScreen.WorkingArea.Height);
			pnlView.Location = new Point(_spaceToBorder, (_spaceToBorder + lblStatus.Height + _spaceToControl));
			pnlView.Margin = new Padding(0, 0, 0, Controls[_nameBtnPanel].Height + _spaceToControl);
		}

		protected override void OnResizeEnd(EventArgs e) {
			base.OnResizeEnd(e);
			updateSizes();
		}

		#endregion

		[DllImport("shell32.dll")]
		private static extern bool IsUserAnAdmin();

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>Lädt eine Ansicht in den Contentpanel des Dialogs</summary>
		public void loadView(Type T) {
			//Überprüfen ob der übergebene Type von der richtigen Basisklasse abgeleitet wurde.
			if (T.BaseType == null || T.BaseType != typeof (updateBaseView))
				throw new ArgumentException("viewType has to be derived from updateBaseView");

			//Wenn vorhanden, altes View aus dem Panel entfernen
			Controls[_namePnlView].Controls.Clear();

			//Neue Instanz erzeugen
			var viewInstance = (updateBaseView) Activator.CreateInstance(T);
			viewInstance.controllerInstance = controllerInstance;
			viewInstance.dataExchange = dataExchange;
			viewInstance.availableViewStates = availableViewStates;
			viewInstance.changeUpdateView += viewInstance_changeUpdateView;
			viewInstance.titleChanged += viewInstance_titleChanged;
			viewInstance.closeDialog += viewInstance_closeDialog;

			//viewInstance.BackColor = Color.Green;
			viewInstance.MinimumSize = new Size(Controls[_namePnlView].ClientRectangle.Width, 30);

			//Viewspezifische Einstellungen setzen
			lblStatus.Text = viewInstance.Title;
			btnInstallUpdate.Visible = viewInstance.showInstallButton;
			btnCancelUpdate.Visible = viewInstance.showCancelButton;

			pnlView.Controls.Add(viewInstance);
			updateSizes();

			//Form wieder zentrieren
			if (ParentForm != null)
				CenterToParent();
			else
				CenterToScreen();


			//View ausführen
			viewInstance.Execute();
		}

		private void viewInstance_closeDialog(object sender, closeDialogEventArgs e) {
			DialogResult = e.dialogResult;
			Close();
		}

		private void viewInstance_titleChanged(object sender, EventArgs e) {
			lblStatus.Text = ((updateBaseView) sender).Title;
		}

		/// <summary>Lädt eine Ansicht in den Contentpanel des Dialogs</summary>
		public void loadView<T>() {
			loadView(typeof (T));
		}

		private void viewInstance_changeUpdateView(object sender, changeUpdateViewEventArgs e) {
			((updateBaseView) sender).changeUpdateView -= viewInstance_changeUpdateView;
			((updateBaseView) sender).closeDialog -= viewInstance_closeDialog;
			loadView(e.newView);
		}

		public new DialogResult ShowDialog(IWin32Window owner) {
			//Nur auf CenterParent setzen wenn auch wirklich ein Parent gesetzt ist.
			if (owner != null)
				StartPosition = FormStartPosition.CenterParent;

			return base.ShowDialog(Owner);
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			//Header zeichnen, dieser ist immer gleich
			if (_appImage == null) {
				string executingPath = Assembly.GetEntryAssembly().Location;
				if (File.Exists(executingPath) && executingPath.EndsWith(".exe")) {
					Icon appIcon = Icon.ExtractAssociatedIcon(executingPath) ?? SystemIcons.Application;
					_appImage = appIcon.ToBitmap();
				}
				else
					_appImage = SystemIcons.Application.ToBitmap();
			}

			//Bild zeichnen
			e.Graphics.DrawImage(_appImage, _rectangleImage);
		}
	}
}