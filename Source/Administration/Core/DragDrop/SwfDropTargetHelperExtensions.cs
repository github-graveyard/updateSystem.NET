//Not my work, credits go to http://blogs.msdn.com/b/adamroot/archive/2008/02/19/shell-style-drag-and-drop-in-net-wpf-and-winforms.aspx
using System;
using System.Drawing;
using System.Windows.Forms;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace updateSystemDotNet.Administration.Core.DragDrop {
	using ComIDataObject = IDataObject;

	public static class SwfDropTargetHelperExtensions {
		/// <summary>
		/// Notifies the DragDropHelper that the specified Control received
		/// a DragEnter event.
		/// </summary>
		/// <param name="dropHelper">The DragDropHelper instance to notify.</param>
		/// <param name="control">The Control the received the DragEnter event.</param>
		/// <param name="data">The DataObject containing a drag image.</param>
		/// <param name="cursorOffset">The current cursor's offset relative to the window.</param>
		/// <param name="effect">The accepted drag drop effect.</param>
		public static void DragEnter(this IDropTargetHelper dropHelper, Control control, System.Windows.Forms.IDataObject data,
		                             Point cursorOffset, DragDropEffects effect) {
			IntPtr controlHandle = IntPtr.Zero;
			if (control != null)
				controlHandle = control.Handle;
			Win32Point pt = cursorOffset.ToWin32Point();
			dropHelper.DragEnter(controlHandle, (ComIDataObject) data, ref pt, (int) effect);
		}

		/// <summary>
		/// Notifies the DragDropHelper that the current Control received
		/// a DragOver event.
		/// </summary>
		/// <param name="dropHelper">The DragDropHelper instance to notify.</param>
		/// <param name="cursorOffset">The current cursor's offset relative to the window.</param>
		/// <param name="effect">The accepted drag drop effect.</param>
		public static void DragOver(this IDropTargetHelper dropHelper, Point cursorOffset, DragDropEffects effect) {
			Win32Point pt = cursorOffset.ToWin32Point();
			dropHelper.DragOver(ref pt, (int) effect);
		}

		/// <summary>
		/// Notifies the DragDropHelper that the current Control received
		/// a Drop event.
		/// </summary>
		/// <param name="dropHelper">The DragDropHelper instance to notify.</param>
		/// <param name="data">The DataObject containing a drag image.</param>
		/// <param name="cursorOffset">The current cursor's offset relative to the window.</param>
		/// <param name="effect">The accepted drag drop effect.</param>
		public static void Drop(this IDropTargetHelper dropHelper, System.Windows.Forms.IDataObject data, Point cursorOffset,
		                        DragDropEffects effect) {
			Win32Point pt = cursorOffset.ToWin32Point();
			dropHelper.Drop((ComIDataObject) data, ref pt, (int) effect);
		}
	}
}