/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using updateSystemDotNet.Administration.Core.Application;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.DataValidation;
using System.Text;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal class dialogBase : Form {

		private readonly List<Control> _protectedControls;

		public dialogBase() {
			validationManager = new validationManager();
			AutoScaleMode = AutoScaleMode.Font;
			base.Font = SystemFonts.MessageBoxFont;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MinimizeBox = false;
			MaximizeBox = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			base.BackColor = Color.White;
			if(!DesignMode)
				Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			_protectedControls = new List<Control>();
		}

		/// <summary>Methode zum initialisieren der Daten auf dem Dialog.</summary>
		/// <remarks>Hier kann auch auf die Session zugegriffen werden, im Gegensatz zum Konstruktor wie diese null ist.</remarks>
		public virtual void initializeData() {
		}

		public applicationSession Session { get; set; }

		protected validationManager validationManager { get; private set; }

		public object Argument { get; set; }

		public object Result { get; set; }

		/// <summary>Speichert die Breiten der Columnheader.</summary>
		protected void saveColumnHeaderSizes(ListView listView) {
			foreach (ColumnHeader header in listView.Columns) {
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
			foreach (ColumnHeader header in listView.Columns) {
				if (string.IsNullOrEmpty(header.Text))
					throw new InvalidOperationException(string.Format("header.Text ist null (ListView: {0} Header-Index: {1}",
																	  listView.Name, header.Index));

				string headerKey = generateColumnHash(listView, header);
				if (Session.Settings.columnSizes.ContainsKey(headerKey))
					header.Width = Session.Settings.columnSizes[headerKey];
			}
		}
		private string generateColumnHash(ListView listView, ColumnHeader header) {
			return string.Format("{0}_{1}", listView.Name, header.Text);
		}

		/// <summary>Deaktiviert permenent ein Control auf dem Dialog ohne das dieses bei lockUi wieder aktiviert wird.</summary>
		protected void permanentlyDisableControl(Control control) {
			if (!_protectedControls.Contains(control))
				_protectedControls.Add(control);
			control.Enabled = false;
		}

		/// <summary>Sperrt bzw. Entsperrt die Steuerelemente auf der Form während z.B. eine asynchrone Serverabfrage läuft.</summary>
		protected void lockUi(bool enabled) {
			foreach (Control control in Controls)
				lockUiInternal(control, enabled);
		}
		private void lockUiInternal(Control control, bool enabled) {
			if ((control is Button ||
				control is TextBox ||
				control is RadioButton ||
				control is CheckBox ||
				control is NumericUpDown ||
				control is LinkLabel) && !_protectedControls.Contains(control))
				control.Enabled = enabled;

			//Wenn dieses Control über weitere Controls verfügt
			if (control.Controls.Count > 0) {
				//diese auch deaktivieren
				foreach (Control child in control.Controls)
					lockUiInternal(child, enabled);
			}
		}

		/// <summary>Registriert einen neuen Überprüfungseintrag.</summary>
		protected void registerValidationEntry(Control control, validationTypes validationType, string friendlyName) {
			registerValidationEntry(control, validationType, friendlyName, validationEntry.defaultValidationPropertyName);
		}

		/// <summary>Registriert einen neuen Überprüfungseintrag.</summary>
		protected void registerValidationEntry(Control control, validationTypes validationType, string friendlyName, string propertyName) {
			validationManager.addEntry(new validationEntry {
																Owner = control,
																validationType = validationType,
																friendlyName = friendlyName,
																validationPropertyName = propertyName
			                                                 });
		}

		public bool validateDialog() {
			bool result = validationManager.Validate();
			if(!result) {
				var sbMissing = new StringBuilder();
				foreach(var valResult in validationManager.validationResults) {
					sbMissing.AppendLine(string.Format("- {0}", valResult.errorText));
				}
				Session.showMessage(this, sbMissing.ToString(), "Es sind noch Benutzereingaben notwendig!", MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
			}
			return result;
		}

	}
}