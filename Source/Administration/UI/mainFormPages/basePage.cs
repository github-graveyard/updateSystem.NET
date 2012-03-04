using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	
	[ToolboxItem(false)]
	internal class basePage : UserControl {

		#region Events

		#endregion

		#region Private Fields

		private TreeNode _node;
		private Controls.mainInstructionsLabel _lblTitle;

		#endregion

		public basePage() {
			base.Font = SystemFonts.MessageBoxFont;
			toolStripButtons = new List<ToolStripItem>();
			initializeComponents();
		}

		private void initializeComponents() {
			_lblTitle = new mainInstructionsLabel() {
			                      	Location = new Point(0, 0),
			                      	Text = "#no title set#"
			                      };
			Controls.Add(_lblTitle);
			_lblTitle.AutoSize = true;
			subPages = new List<baseSubPage>();
		}

		#region Properties

		/// <summary>Gibt die aktuelle Anwendungssession zurück oder legt diese fest.</summary>
		public applicationSession Session { get; set; }

		/// <summary>Gibt das Symbolzurück welches im TreeView angezeigt werden soll oder legt dieses fest.</summary>
		public Image pageSymbol { get; protected set; }

		/// <summary>Gibt den Namen zurück der im TreeView für diese Seite angezeigt werden soll oder legt diesen fest.</summary>
		public string pageName { get; set; }

		/// <summary>Gibt eine GUID zurück welche die Page eindeutig identifiziert oder legt diese fest.</summary>
		public string Id { get; protected set; }

		/// <summary>Gibt die Seite zurück die angezeigt werden soll, wenn <see cref="canShowPage"/> False zurück gibt.</summary>
		public basePage fallbackPage { get; protected set; }

		/// <summary>Gibt die Anzeigereihenfolge wieder oder legt diese fest.</summary>
		public int displayOrder { get; protected set; }

		/// <summary>Gibt den Titel zurück der auf der Seite angezeigt werden soll.</summary>
		public string Title { get { return _lblTitle.Text; } set { _lblTitle.Text = value; } }

		/// <summary>Gibt zurück ob die Seite in der Navigation verborgen werden soll.</summary>
		public virtual bool hideFromNavigation { get { return false; } }

		//ToolStrip
		/// <summary>Gibt an oder legt fest, ob diese Seite den ToolStrip der Hauptseite erweitert.</summary>
		public bool extendsToolStrip { get; set; }

		/// <summary>Gibt eine Auflistung mit Toolstrip-Buttons zurück die in die Toolbar der Hauptform eingefügt werden sollen.</summary>
		public List<ToolStripItem> toolStripButtons { get; protected set; }

		/// <summary>Gibt den Node zurück um die Seite im TreeView der Hauptnavigation darstellen zu können.</summary>
		public virtual TreeNode Node {
			get {
				return _node ?? (_node = new TreeNode(pageName) {
				                                                	ImageKey = Id,
				                                                	SelectedImageKey = Id,
																	Tag = GetType()
				                                                });
			}
		}

		protected List<baseSubPage> subPages { get; set; }

		#endregion

		#region Virtual Methods

		/// <summary>Gibt an ob die Seite zu diesem Zeitpunkt im TreeView angezeigt werden soll.</summary>
		/// <returns>True wenn die Seite angezeigt werden soll, andernfalls False.</returns>
		public virtual bool canShowPage() {
			return true;
		}

		/// <summary>Methode zum initialisieren der Daten auf der Seite.</summary>
		/// <remarks>Hier kann auch auf die Session zugegriffen werden, im Gegensatz zum Konstruktor wie diese null ist.</remarks>
		public virtual void initializeData() {
		}

		/// <summary>Initialisiert evtl. vorhandene Unterseiten.</summary>
		public virtual void initializeSubPages() {
		}

		/// <summary>Methode zum initialisieren der ToolStripButtons</summary>
		protected virtual void initializeToolStripButtons() {
		}

		#endregion

		#region Public Methods

		// still to come...

		#endregion

		#region Protected Methods

		/// <summary>Erstellt eine neue Subpage</summary>
		/// <param name="argument">Das der Subpage zu übergebende Argument.</param>
		/// <typeparam name="T">Der Type aus dem eine neue Subpage erstellt werden soll.</typeparam>
		protected T createSubPage<T>(object argument) where T : baseSubPage {
			var instance = Activator.CreateInstance<T>();
			instance.Session = Session;
			instance.Argument = argument;
			instance.parentPage = this;

			if (instance.pageSymbol != null && !Node.TreeView.ImageList.Images.ContainsKey(instance.Id)) {
				Node.TreeView.ImageList.Images.Add(instance.Id, instance.pageSymbol);
			}

			return instance;
		}

		/// <summary>Speichert die Breiten der Columnheader.</summary>
		protected void saveColumnHeaderSizes(ListView listView) {
			foreach(ColumnHeader header in listView.Columns) {
				if (string.IsNullOrEmpty(header.Text))
					throw new InvalidOperationException(string.Format("header.Text ist null (ListView: {0} Header-Index: {1}",
					                                                  listView.Name, header.Index));

				string headerKey = generateColumnHash(listView, header);
				if (Session.Settings.columnSizes.ContainsKey(headerKey))
					Session.Settings.columnSizes[headerKey] = header.Width;
				else
					Session.Settings.columnSizes.Add(headerKey, header.Width);
			}
		}

		/// <summary>Stellt die gespeicherten Breiten der ColumnHeader wieder her.</summary>
		protected void restoreColumnHeaderSizes(ListView listView) {
			foreach(ColumnHeader header in listView.Columns) {
				if (string.IsNullOrEmpty(header.Text))
					throw new InvalidOperationException(string.Format("header.Text ist null (ListView: {0} Header-Index: {1}",
					                                                  listView.Name, header.Index));

				string headerKey = generateColumnHash(listView, header);
				if (Session.Settings.columnSizes.ContainsKey(headerKey))
					header.Width = Session.Settings.columnSizes[headerKey];
			}
		}

		/// <summary>Erstellt einen neuen, vorkonfigurierten ToolStripButton.</summary>
		protected ToolStripButton createToolStripButton(string text) {
			return createToolStripButton(text, string.Empty);
		}

		/// <summary>Erstellt einen neuen, vorkonfigurierten ToolStripButton.</summary>
		protected ToolStripButton createToolStripButton(string text, string tooltip) {
			var tsBtn = new ToolStripButton(text) {
			                                      	DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
			                                      	AutoToolTip = (!string.IsNullOrEmpty(tooltip)),
			                                      	ToolTipText = tooltip,
			                                      	Tag = this
			                                      };
			toolStripButtons.Add(tsBtn);
			return tsBtn;
		}

		#endregion

		#region Private Methods

		private string generateColumnHash(ListView listView, ColumnHeader header) {
			return string.Format("{0}_{1}", listView.Name, header.Text);
		}

		#endregion

	}
}