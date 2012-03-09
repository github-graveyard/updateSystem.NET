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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace updateSystemDotNet.Administration.UI.Controls {
	internal sealed class extendedListView : ListView {
		//Listview universal constants
		private const int LVM_FIRST = 0x1000;
		//Listview messages
		private const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
		//Listview extended styles
		private const int LVS_EX_DOUBLEBUFFER = 0x00010000;
		private Boolean elv;

		public extendedListView() {
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			DoubleBuffered = true;
			HeaderStyle = ColumnHeaderStyle.Nonclickable;
			FullRowSelect = true;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVGROUP lParam);

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

		// sollte nach dem die gruppen hinzugefügt worden sind aufgerufen werden, jedoch am besten im form.shown event
		internal void MakeCollapsable() {
			if (Environment.OSVersion.Version.Major < 6)
				return;
			// Not supported by OS

			const int lvmFirst = 0x1000;
			const int LVM_SETGROUPINFO = (lvmFirst + 147);


			for (int i = 0; i <= Groups.Count - 1; i++) {
				var grp = new LVGROUP();
				grp.CbSize = Marshal.SizeOf(grp);
				grp.State = ListViewGroupState.Collapsible;
				grp.Mask = ListViewGroupMask.State;
				grp.IGroupId = GetGroupID(Groups[i]);
				//If grp.IGroupId = -1 Then grp.IGroupId = i
				if (grp.IGroupId >= 0) {
					SendMessage(Handle, LVM_SETGROUPINFO, grp.IGroupId, ref grp);
				}
			}
		}

		private static int GetGroupID(ListViewGroup lstvwgrp) {
			int rtnval = -1;
			Type GrpTp = lstvwgrp.GetType();
			{
				PropertyInfo pi = GrpTp.GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
				if (pi != null) {
					object tmprtnval = pi.GetValue(lstvwgrp, null);
					if (tmprtnval != null)
						rtnval = (int) tmprtnval;
				}
			}
			return rtnval;
		}

		protected override void WndProc(ref Message m) {
			const int WM_LBUTTONUP = 0x202;

			// Benötigt, sonst passiert beim klicken von erweitern/verkleinern nix
			if (m.Msg == WM_LBUTTONUP && Environment.OSVersion.Version.Major >= 6)
				DefWndProc(ref m);

			// Listen for operating system messages.
			switch (m.Msg) {
				case 15:
					//Paint event
					if (!elv) {
						//1-time run needed
						SetWindowTheme(Handle, "explorer", null);

						SendMessage(Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_DOUBLEBUFFER, LVS_EX_DOUBLEBUFFER);
						//Blue selection, keeps other extended styles
						elv = true;
					}
					break;
			}

			base.WndProc(ref m);
		}

		/// <summary>Exportiert die komplette ListView als CSV-Datei</summary>
		public void exportAsCSV(string filename) {
			if(string.IsNullOrEmpty(filename))
				throw new ArgumentException("filename");
			
			using(var csvWriter = new StreamWriter(filename, false, Encoding.UTF8)) {
				
				//Columns schreiben
				for (var i = 0; i < Columns.Count; i++) {
					csvWriter.Write(Columns[i].Text);
					if (i < (Columns.Count - 1))
						csvWriter.Write(";");
				}
				csvWriter.WriteLine();

				//Einträge schreiben
				for (var i = 0; i < Items.Count; i++) {
					//SubItems schreiben
					for (var k = 0; k < Items[i].SubItems.Count; k++) {
						csvWriter.Write(Items[i].SubItems[k].Text);
						if (k < (Items[i].SubItems.Count - 1))
							csvWriter.Write(";");
					}
					csvWriter.WriteLine();
				}
				csvWriter.Flush();
			}
		}

		#region Nested type: LVGROUP

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct LVGROUP {
			internal int CbSize;
			internal ListViewGroupMask Mask;
			[MarshalAs(UnmanagedType.LPWStr)] internal string PszHeader;
			internal int CchHeader;
			[MarshalAs(UnmanagedType.LPWStr)] internal string PszFooter;
			internal int CchFooter;
			internal int IGroupId;
			internal int StateMask;
			internal ListViewGroupState State;
			internal uint UAlign;
			internal IntPtr PszSubtitle;
			internal uint CchSubtitle;
			[MarshalAs(UnmanagedType.LPWStr)] internal string PszTask;
			internal uint CchTask;
			[MarshalAs(UnmanagedType.LPWStr)] internal string PszDescriptionTop;
			internal uint CchDescriptionTop;
			[MarshalAs(UnmanagedType.LPWStr)] internal string PszDescriptionBottom;
			internal uint CchDescriptionBottom;
			internal int ITitleImage;
			internal int IExtendedImage;
			internal int IFirstItem;
			internal IntPtr CItems;
			internal IntPtr PszSubsetTitle;
			internal IntPtr CchSubsetTitle;
		}

		#endregion

		#region Nested type: ListViewGroupMask

		internal enum ListViewGroupMask {
			None = 0x0,
			Header = 0x1,
			Footer = 0x2,
			State = 0x4,
			Align = 0x8,
			GroupId = 0x10,
			SubTitle = 0x100,
			Task = 0x200,
			DescriptionTop = 0x400,
			DescriptionBottom = 0x800,
			TitleImage = 0x1000,
			ExtendedImage = 0x2000,
			Items = 0x4000,
			Subset = 0x8000,
			SubsetItems = 0x10000
		}

		#endregion

		#region Nested type: ListViewGroupState

		internal enum ListViewGroupState {
			Normal = 0,
			Collapsed = 1,
			Hidden = 2,
			NoHeader = 4,
			Collapsible = 8,
			Focused = 16,
			Selected = 32,
			SubSeted = 64,
			SubSetLinkFocused = 128
		}

		#endregion
	}
}