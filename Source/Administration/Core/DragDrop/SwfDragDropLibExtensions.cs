﻿//Not my work, credits go to http://blogs.msdn.com/b/adamroot/archive/2008/02/19/shell-style-drag-and-drop-in-net-wpf-and-winforms.aspx
using System.Drawing;

namespace updateSystemDotNet.Administration.Core.DragDrop {
	public static class SwfDragDropLibExtensions {
		/// <summary>
		/// Converts a System.Windows.Point value to a DragDropLib.Win32Point value.
		/// </summary>
		/// <param name="pt">Input value.</param>
		/// <returns>Converted value.</returns>
		public static Win32Point ToWin32Point(this Point pt) {
			var wpt = new Win32Point();
			wpt.x = pt.X;
			wpt.y = pt.Y;
			return wpt;
		}
	}
}