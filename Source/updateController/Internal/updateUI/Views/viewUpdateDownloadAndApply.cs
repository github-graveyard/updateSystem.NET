/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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
using updateSystemDotNet.Internal.updateUI.Controls;

namespace updateSystemDotNet.Internal.updateUI.Views {
	internal sealed class viewUpdateDownloadAndApply : updateBaseView {
		private ProgressBar prgUpdate;
		private statusLabel staApply;
		private statusLabel staDownload;

		public viewUpdateDownloadAndApply() {
			Title = "Die Aktualisierungen für Ihre Anwendung werden nun heruntergeladen und installiert";
		}

		public override bool showInstallButton {
			get { return false; }
		}

		public override bool showCancelButton {
			get { return true; }
		}

		protected override void initializeComponents() {
			//Progressbar
			prgUpdate = new ProgressBar {
			                            	Height = 15,
			                            	Value = 60
			                            };
			addControl(prgUpdate);

			//StatusLabel Installation
			staApply = new statusLabel {
			                           	Text = "Updates werden installiert",
			                           	State = statusLabelStates.Waiting,
			                           	Size = new Size(Width, 30)
			                           };
			addControl(staApply);

			//StatusLabel Download
			staDownload = new statusLabel {
			                              	Text = "Updates werden heruntergeladen (60% abgeschlossen)",
			                              	State = statusLabelStates.Progress,
			                              	Size = new Size(Width, 30)
			                              };
			addControl(staDownload);
		}
	}
}