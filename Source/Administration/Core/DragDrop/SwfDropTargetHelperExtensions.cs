/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
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