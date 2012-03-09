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
using System.Collections.Generic;
using System.Windows.Forms;
using updateSystemDotNet.appEventArgs;

namespace updateSystemDotNet.Internal.updateUI {
	/// <summary>Basiscontrol für alle Ansichten der verschiedenen Updatedialoge.</summary>
	internal abstract class updateBaseView : UserControl {
		private const int _spaceBetweenControls = 5;
		private int _controlIndex;
		private string _title;


		//View initialisieren
		protected updateBaseView() {
			_title = string.Empty;
			initializeComponents();
			base.AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
		}

		/// <summary>Gibt den Titel für den UpdateDialog zurück.</summary>
		public string Title {
			get { return _title; }
			set {
				_title = value;

				if (titleChanged != null)
					titleChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>Gibt zurück oder legt fest, ob der Button zur Updateinstallation angezeigt werden soll.</summary>
		public abstract bool showInstallButton { get; }

		/// <summary>Gibt zurück oder legt fest, ob der Abbrechenbutton angezeigt werden soll.</summary>
		public abstract bool showCancelButton { get; }

		/// <summary>Verknüpfung von erlaubten Ansichten.</summary>
		public updateViewStates availableViewStates { get; set; }

		/// <summary>Referenz auf das updateController-Objekt von welchem aus der Dialog aufgerufen wurde.</summary>
		public updateController controllerInstance { get; set; }

		/// <summary>Dictionary zum austauschen von Daten unter den Views</summary>
		public Dictionary<string, object> dataExchange { get; set; }

		/// <summary>Event welches eintritt, wenn die Ansicht gewechselt werden soll.</summary>
		public event EventHandler<changeUpdateViewEventArgs> changeUpdateView;

		/// <summary>Event welches eintritt, wenn sich der Titel verändert hat.</summary>
		public event EventHandler titleChanged;

		/// <summary>Event um den ParentDialog schließen zu können.</summary>
		public event EventHandler<closeDialogEventArgs> closeDialog;

		/// <summary>Initialisiert die Controls in dem View</summary>
		protected abstract void initializeComponents();

		protected void addControl(Control ctrl) {
			ctrl.Margin = new Padding(0, 0, 0, _spaceBetweenControls);
			ctrl.Dock = DockStyle.Top;

			ctrl.TabIndex = _controlIndex;
			_controlIndex++;

			Controls.Add(ctrl);
		}

		protected void onChangeUpdateView(Type newView) {
			if (changeUpdateView != null)
				changeUpdateView(this, new changeUpdateViewEventArgs(newView));
		}

		/// <summary>Löst das closeDialog-Event aus.</summary>
		protected void onCloseDialog(closeDialogEventArgs e) {
			EventHandler<closeDialogEventArgs> handler = closeDialog;
			if (handler != null) handler(this, e);
		}

		/// <summary>Führt Aktionen nach dem Öffnen des Views aus, z.B. Updatesuche oder Download.</summary>
		public virtual void Execute() {
			//Nichts machen
		}
	}
}