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