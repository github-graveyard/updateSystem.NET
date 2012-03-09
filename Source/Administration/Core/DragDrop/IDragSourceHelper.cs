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
using System.Runtime.InteropServices.ComTypes;

namespace updateSystemDotNet.Administration.Core.DragDrop {
	[ComVisible(true)]
	[ComImport]
	[Guid("DE5BF786-477A-11D2-839D-00C04FD918D0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDragSourceHelper {
		void InitializeFromBitmap(
			[In, MarshalAs(UnmanagedType.Struct)] ref ShDragImage dragImage,
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject);

		void InitializeFromWindow(
			[In] IntPtr hwnd,
			[In] ref Win32Point pt,
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject);
	}

	[ComVisible(true)]
	[ComImport]
	[Guid("83E07D0D-0C5F-4163-BF1A-60B274051E40")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDragSourceHelper2 {
		void InitializeFromBitmap(
			[In, MarshalAs(UnmanagedType.Struct)] ref ShDragImage dragImage,
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject);

		void InitializeFromWindow(
			[In] IntPtr hwnd,
			[In] ref Win32Point pt,
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject);

		void SetFlags(
			[In] int dwFlags);
	}
}