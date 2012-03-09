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