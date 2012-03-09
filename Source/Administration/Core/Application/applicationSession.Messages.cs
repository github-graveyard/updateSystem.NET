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

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace updateSystemDotNet.Administration.Core.Application {
	
	internal sealed partial class applicationSession {

		private class dummyWindow : IWin32Window {
			private readonly IntPtr _handle;
			public dummyWindow(IntPtr handle) {
				_handle = handle;
			}
			public IntPtr Handle {
				get { return _handle; }
			}
		}

		[DllImport("comctl32", CharSet = CharSet.Auto)]
		private static extern IntPtr TaskDialog(IntPtr hWndParent, IntPtr hInstance, string windowTitle, string mainInstruction, string content, IntPtr commonButtons, int icon, out int buttonPressed);


		public DialogResult showMessage(string message) {
			return showMessage(null, message, string.Empty, MessageBoxIcon.Information, MessageBoxButtons.OK);
		}
		public DialogResult showMessage(IWin32Window owner, string message) {
			return showMessage(owner, message, string.Empty, MessageBoxIcon.Information, MessageBoxButtons.OK);
		}
		public DialogResult showMessage(string message, MessageBoxIcon icon, MessageBoxButtons buttons) {
			return showMessage(null, message, string.Empty, icon, buttons);
		}
		public DialogResult showMessage(IWin32Window owner, string message, MessageBoxIcon icon, MessageBoxButtons buttons) {
			return showMessage(owner, message, string.Empty, icon, buttons);
		}
		public DialogResult showMessage(IWin32Window owner, string message, string title, MessageBoxIcon icon, MessageBoxButtons buttons) {

			//Wenn kein Owner mitgegeben wurde, dann Versuchen das Hauptfenster anzuzeigen
			if (owner == null || owner.Handle == IntPtr.Zero)
				owner = new dummyWindow(Process.GetCurrentProcess().MainWindowHandle);

			const string appTitle = "updateSystem.NET Administration";

			//Nachricht loggen
			logLevel lLevel;
			switch (icon) {
				case MessageBoxIcon.Error:
					lLevel = logLevel.Error;
					break;
				case MessageBoxIcon.Exclamation:
					lLevel = logLevel.Warning;
					break;
				default:
					lLevel = logLevel.Info;
					break;
			}
			Log.writeState(lLevel,
			                        string.Format("{0}{1}", string.IsNullOrEmpty(title) ? "" : string.Format("{0} -> ", title),
			                                      message));

			var dlgResponse = Environment.OSVersion.Version.Major >= 6
			       	? showTaskDialog(owner, appTitle, title, message, buttons, icon)
			       	: showMessageBox(owner, appTitle, title, message, icon, buttons);

			Log.writeKeyValue(lLevel, "Messagedialogresult", dlgResponse.ToString());

			return dlgResponse;
		}

		//Methode zum Anzeigen der ollen MessageBox für XP
		private DialogResult showMessageBox(IWin32Window owner, string title, string mainInstruction, string content, MessageBoxIcon icon, MessageBoxButtons buttons) {
			var messageBoxText = string.Format("{0}{1}",
			                                      string.IsNullOrEmpty(mainInstruction) ? "" : string.Format("{0}\r\n\r\n", mainInstruction),
			                                      content);
			return MessageBox.Show(
				owner,
				messageBoxText,
				title,
				buttons,
				icon
				);
		}

		//Methode zum Anzeigen der TaskDialog MessageBox (Windows Vista oder höher)
		private DialogResult showTaskDialog(IWin32Window owner, string title, string mainInstruction, string content, MessageBoxButtons buttons, MessageBoxIcon icon) {
			var buttonId = 1;
			int iconId;
			switch (buttons) {
				case MessageBoxButtons.AbortRetryIgnore:
					throw new InvalidOperationException();
				case MessageBoxButtons.OK:
					buttonId = 1;
					break;
				case MessageBoxButtons.OKCancel:
					buttonId = 9;
					break;
				case MessageBoxButtons.RetryCancel:
					buttonId = 0x18;
					break;
				case MessageBoxButtons.YesNo:
					buttonId = 6;
					break;
				case MessageBoxButtons.YesNoCancel:
					buttonId = 14;
					break;
			}
			switch (icon) {
				case MessageBoxIcon.Asterisk:
				case MessageBoxIcon.Question:
					iconId = 0xfffd;
					break;
				case MessageBoxIcon.Error:
					iconId = 0xfffe;
					break;
				case MessageBoxIcon.Exclamation:
					iconId = 0xffff;
					break;
				default:
					iconId = 0;
					break;
			}

			IntPtr handle;
			if (owner == null || owner.Handle == IntPtr.Zero)
				handle = Process.GetCurrentProcess().MainWindowHandle;
			else handle = owner.Handle;

			int result;

			TaskDialog(
				handle,
				IntPtr.Zero,
				title,
				mainInstruction,
				content,
				(IntPtr) ((long) buttonId),
				iconId,
				out result
				);

			switch (result) {
				case 2:
					return DialogResult.Cancel;
				case 7:
					return DialogResult.No;
				case 0:
					return DialogResult.None;
				case 1:
					return DialogResult.OK;
				case 4:
					return DialogResult.Retry;
				case 6:
					return DialogResult.Yes;
				default:
					return DialogResult.None;
			}
		}

	}
}
