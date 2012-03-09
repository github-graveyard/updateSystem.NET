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
using System.Text;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace updateSystemDotNet.Setup.Core {
	// IShellLink.Resolve fFlags
	[Flags]
	internal enum SLR_FLAGS {
		SLR_NO_UI = 0x1,
		SLR_ANY_MATCH = 0x2,
		SLR_UPDATE = 0x4,
		SLR_NOUPDATE = 0x8,
		SLR_NOSEARCH = 0x10,
		SLR_NOTRACK = 0x20,
		SLR_NOLINKINFO = 0x40,
		SLR_INVOKE_MSI = 0x80
	}

	// IShellLink.GetPath fFlags
	[Flags]
	internal enum SLGP_FLAGS {
		SLGP_SHORTPATH = 0x1,
		SLGP_UNCPRIORITY = 0x2,
		SLGP_RAWPATH = 0x4
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal struct WIN32_FIND_DATAA {
		public int dwFileAttributes;
		public FILETIME ftCreationTime;
		public FILETIME ftLastAccessTime;
		public FILETIME ftLastWriteTime;
		public int nFileSizeHigh;
		public int nFileSizeLow;
		public int dwReserved0;
		public int dwReserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] public string cFileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)] public string cAlternateFileName;
		private const int MAX_PATH = 260;
	}

	[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct WIN32_FIND_DATAW {
		public int dwFileAttributes;
		public FILETIME ftCreationTime;
		public FILETIME ftLastAccessTime;
		public FILETIME ftLastWriteTime;
		public int nFileSizeHigh;
		public int nFileSizeLow;
		public int dwReserved0;
		public int dwReserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] public string cFileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)] public string cAlternateFileName;
		private const int MAX_PATH = 260;
	}

	[
		ComImport,
		InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
		Guid("0000010B-0000-0000-C000-000000000046")
	]
	internal interface IPersistFile {
		#region Methods inherited from IPersist

		void GetClassID(
			out Guid pClassID);

		#endregion

		[PreserveSig]
		int IsDirty();

		void Load(
			[MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
			int dwMode);

		void Save(
			[MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
			[MarshalAs(UnmanagedType.Bool)] bool fRemember);

		void SaveCompleted(
			[MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

		void GetCurFile(
			out IntPtr ppszFileName);
	}

	[
		ComImport,
		InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
		Guid("000214EE-0000-0000-C000-000000000046")
	]
	internal interface IShellLinkA {
		void GetPath(
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszFile,
			int cchMaxPath,
			out WIN32_FIND_DATAA pfd,
			SLGP_FLAGS fFlags);

		void GetIDList(
			out IntPtr ppidl);

		void SetIDList(
			IntPtr pidl);

		void GetDescription(
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszName,
			int cchMaxName);

		void SetDescription(
			[MarshalAs(UnmanagedType.LPStr)] string pszName);

		void GetWorkingDirectory(
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszDir,
			int cchMaxPath);

		void SetWorkingDirectory(
			[MarshalAs(UnmanagedType.LPStr)] string pszDir);

		void GetArguments(
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszArgs,
			int cchMaxPath);

		void SetArguments(
			[MarshalAs(UnmanagedType.LPStr)] string pszArgs);

		void GetHotkey(
			out short pwHotkey);

		void SetHotkey(
			short wHotkey);

		void GetShowCmd(
			out int piShowCmd);

		void SetShowCmd(
			int iShowCmd);

		void GetIconLocation(
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszIconPath,
			int cchIconPath,
			out int piIcon);

		void SetIconLocation(
			[MarshalAs(UnmanagedType.LPStr)] string pszIconPath,
			int iIcon);

		void SetRelativePath(
			[MarshalAs(UnmanagedType.LPStr)] string pszPathRel,
			int dwReserved);

		void Resolve(
			IntPtr hwnd,
			SLR_FLAGS fFlags);

		void SetPath(
			[MarshalAs(UnmanagedType.LPStr)] string pszFile);
	}

	[
		ComImport,
		InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
		Guid("000214F9-0000-0000-C000-000000000046")
	]
	internal interface IShellLinkW {
		void GetPath(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
			int cchMaxPath,
			out WIN32_FIND_DATAW pfd,
			SLGP_FLAGS fFlags);

		void GetIDList(
			out IntPtr ppidl);

		void SetIDList(
			IntPtr pidl);

		void GetDescription(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
			int cchMaxName);

		void SetDescription(
			[MarshalAs(UnmanagedType.LPWStr)] string pszName);

		void GetWorkingDirectory(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
			int cchMaxPath);

		void SetWorkingDirectory(
			[MarshalAs(UnmanagedType.LPWStr)] string pszDir);

		void GetArguments(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
			int cchMaxPath);

		void SetArguments(
			[MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

		void GetHotkey(
			out short pwHotkey);

		void SetHotkey(
			short wHotkey);

		void GetShowCmd(
			out int piShowCmd);

		void SetShowCmd(
			int iShowCmd);

		void GetIconLocation(
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
			int cchIconPath,
			out int piIcon);

		void SetIconLocation(
			[MarshalAs(UnmanagedType.LPWStr)] string pszIconPath,
			int iIcon);

		void SetRelativePath(
			[MarshalAs(UnmanagedType.LPWStr)] string pszPathRel,
			int dwReserved);

		void Resolve(
			IntPtr hwnd,
			SLR_FLAGS fFlags);

		void SetPath(
			[MarshalAs(UnmanagedType.LPWStr)] string pszFile);
	}


	[
		ComImport,
		Guid("00021401-0000-0000-C000-000000000046")
	]
	internal class ShellLink // : IPersistFile, IShellLinkA, IShellLinkW 
	{
	}
}