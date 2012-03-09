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
	[Guid("4657278B-411B-11D2-839A-00C04FD918D0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDropTargetHelper {
		void DragEnter(
			[In] IntPtr hwndTarget,
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject,
			[In] ref Win32Point pt,
			[In] int effect);

		void DragLeave();

		void DragOver(
			[In] ref Win32Point pt,
			[In] int effect);

		void Drop(
			[In, MarshalAs(UnmanagedType.Interface)] IDataObject dataObject,
			[In] ref Win32Point pt,
			[In] int effect);

		void Show(
			[In] bool show);
	}
}