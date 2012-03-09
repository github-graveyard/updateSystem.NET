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