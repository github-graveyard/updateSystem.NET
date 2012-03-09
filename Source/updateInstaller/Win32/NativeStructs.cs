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

namespace updateSystemDotNet.Updater.Win32 {
	internal static class NativeStructs {
		#region Nested type: PROCESS_INFORMATION

		[StructLayout(LayoutKind.Sequential)]
		internal struct PROCESS_INFORMATION {
			public IntPtr hProcess;
			public IntPtr hThread;
			public uint dwProcessId;
			public uint dwThreadId;
		}

		#endregion

		#region Nested type: WINTRUST_DATA

		[StructLayout(LayoutKind.Sequential)]
		internal unsafe struct WINTRUST_DATA {
			internal uint cbStruct;
			internal IntPtr pPolicyCallbackData;
			internal IntPtr pSIPClientData;
			internal uint dwUIChoice;
			internal uint fdwRevocationChecks;
			internal uint dwUnionChoice;
			internal void* pInfo; // pFile, pCatalog, pBlob, pSgnr, or pCert
			internal uint dwStateAction;
			internal IntPtr hWVTStateData;
			internal IntPtr pwszURLReference;
			internal uint dwProvFlags;
			internal uint dwUIContext;
		}

		#endregion

		#region Nested type: WINTRUST_FILE_INFO

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal unsafe struct WINTRUST_FILE_INFO {
			internal uint cbStruct;
			internal char* pcwszFilePath;
			internal IntPtr hFile;
		}

		#endregion
	}
}