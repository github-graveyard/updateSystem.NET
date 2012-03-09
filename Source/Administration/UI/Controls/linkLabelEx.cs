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

using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class linkLabelEx : LinkLabel {
		public linkLabelEx() {
			LinkColor = SystemColors.HotTrack;
			Font = SystemFonts.MessageBoxFont; // Core.Fonts.defaultFont;
			ActiveLinkColor = SystemColors.Highlight;
			LinkBehavior = LinkBehavior.NeverUnderline;
		}

		public string Url { get; set; }

		private void openFailed() {
			MessageBox.Show(
				"Die Adresse konnte wegen eines Fehlers nicht geöffnet werden:\r\n" + Url,
				"assemblyCompressor",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}

		protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e) {
			if (!string.IsNullOrEmpty(Url)) {
				new Thread(openUrl).Start(Url);
			}
			else {
				base.OnLinkClicked(e);
			}
		}

		private void openUrl(object argument) {
			try {
				Process.Start((argument as string));
			}
			catch {
				Invoke(new delOpenFailed(openFailed));
			}
		}

		#region Nested type: delOpenFailed

		private delegate void delOpenFailed();

		#endregion
	}
}