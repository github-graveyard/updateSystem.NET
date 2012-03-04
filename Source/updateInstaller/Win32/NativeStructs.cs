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