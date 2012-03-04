using System.ComponentModel;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Core.updateActions;
using System.Drawing;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	[ToolboxItem(false)]
	internal partial class actionEditorBase : UserControl {
		public actionEditorBase() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		#region " Updateaktion "

		/// <summary>Gibt die Instanz der selektierten updateAction zurück oder legt diese fest.</summary>
		public actionBase updateAction { get; set; }

		public applicationSession Session { get; set; }

		/// <summary>Initialisiert den Inhalt des Actioneditors.</summary>
		public virtual void initializeActionContent() {
		}

		#endregion
	}
}