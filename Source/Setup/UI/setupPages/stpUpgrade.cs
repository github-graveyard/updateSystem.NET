using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using updateSystemDotNet.Setup.Core;
using System.Reflection;
using System.Diagnostics;

namespace updateSystemDotNet.Setup.UI.setupPages {
	internal partial class stpUpgrade : basePage, ISetupPage {
		
		public stpUpgrade() {
			InitializeComponent();
		}

		#region Implementation of ISetupPage

		/// <summary>Gibt das aktuelle Setupcontext zurück welches erweiterte Informationen über die Anwendung bereitstellt.</summary>
		public setupContext Context { get; set; }

		/// <summary>Gibt den Titel der aktuellen Seite zurück.</summary>
		public string Title {
			get { return string.Format("Upgrade auf Version {0}", Assembly.GetExecutingAssembly().GetName().Version); }
		}

		/// <summary>Gibt an, ob der Assistent beim Klick auf Weiter geschlossen werden soll</summary>
		public bool isLastPage { get { return false; } }

		/// <summary>Gibt das Steuerelement zurück welches zur Anzeige im Setup verwendet werden soll.</summary>
		public basePage View { get { return this; } }

		/// <summary>Der Type der Assistentenseite die beim Klick auf "Zurück" geladen werden soll.</summary>
		/// <remarks>Null zurückgeben um die Funktionalität zu deaktivieren.</remarks>
		public Type forwardPage { get { return typeof (stpInstall); } }

		/// <summary>Der Type der Assistentenseite die beim Klick auf "Weiter" geladen werden soll.</summary>
		/// <remarks>Null zurückgeben um die Funktionalität zu deaktivieren.</remarks>
		public Type backwardPage { get { return null; } }

		#endregion

		private void picDonate_Click(object sender, EventArgs e) {
			Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Y67TPZVJUG968");
		}
	}
}
