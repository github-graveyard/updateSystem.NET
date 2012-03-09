#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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