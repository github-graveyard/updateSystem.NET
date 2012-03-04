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