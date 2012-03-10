//Not my work, credits go to http://blogs.msdn.com/b/adamroot/archive/2008/02/19/shell-style-drag-and-drop-in-net-wpf-and-winforms.aspx
using System;
using System.Runtime.InteropServices;

namespace updateSystemDotNet.Administration.Core.DragDrop {
	[StructLayout(LayoutKind.Sequential)]
	public struct Win32Point {
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Win32Size {
		public int cx;
		public int cy;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ShDragImage {
		public Win32Size sizeDragImage;
		public Win32Point ptOffset;
		public IntPtr hbmpDragImage;
		public int crColorKey;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 1044)]
	public struct DropDescription {
		public int type;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szMessage;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szInsert;
	}
}