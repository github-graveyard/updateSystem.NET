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
using System.Drawing;
using System.Windows.Forms;

namespace updateSystemDotNet.Internal.updateUI.Views {
	internal sealed class viewUpdatesAvailable : updateBaseView {
		private Label lblCurrentVersion;
		private Label lblNewVersion;
		private Label lblSize;
		private TextBox txtChanges;

		public viewUpdatesAvailable() {
			Title = "Für Ihre Anwendung sind Aktualisierungen verfügbar!";
		}

		public override bool showInstallButton {
			get { return true; }
		}

		public override bool showCancelButton {
			get { return true; }
		}

		protected override void initializeComponents() {
			//Text für den Changelog hinzufügen
			txtChanges = new TextBox {
			                         	Text = "Changelog goes here....",
			                         	Height = 170,
			                         	ScrollBars = ScrollBars.Vertical,
			                         	ReadOnly = true,
			                         	Multiline = true,
			                         	BackColor = Color.White,
			                         	Cursor = Cursors.Default
			                         };
			addControl(txtChanges);

			//Label mit gesamtgröße aller Updates
			lblSize = new Label {
			                    	Text = "Updategröße: 2,13 MB (fake)"
			                    };
			addControl(lblSize);

			//Label mit aktuell installierter Version hinzufügen
			lblCurrentVersion = new Label {
			                              	Text = "Installierte Version: 0.0.0.0 (fake)"
			                              };
			addControl(lblCurrentVersion);

			//Label mit neuester Version setzen
			lblNewVersion = new Label {
			                          	Text = "Neueste Version: 1.0.0.0 (fake)",
			                          	Font = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold)
			                          };

			addControl(lblNewVersion);
		}
	}
}