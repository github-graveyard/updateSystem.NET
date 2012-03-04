using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace updateSystemDotNet.Updater.Win32 {
	internal static class NativeMethods {
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenProcess(
			uint dwDesiredAccess,
			[MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
			uint dwProcessId);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenProcessToken(
			IntPtr ProcessHandle,
			uint DesiredAccess,
			out IntPtr TokenHandle);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateTokenEx(
			IntPtr hExistingToken,
			uint dwDesiredAccess,
			IntPtr lpTokenAttributes,
			NativeConstants.SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
			NativeConstants.TOKEN_TYPE TokenType,
			out IntPtr phNewToken);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateProcessWithTokenW(
			IntPtr hToken,
			uint dwLogonFlags,
			IntPtr lpApplicationName,
			IntPtr lpCommandLine,
			uint dwCreationFlags,
			IntPtr lpEnvironment,
			IntPtr lpCurrentDirectory,
			IntPtr lpStartupInfo,
			out NativeStructs.PROCESS_INFORMATION lpProcessInfo);

		[DllImport("Wintrust.dll", PreserveSig = true, SetLastError = false)]
		internal static extern int WinVerifyTrust(
			IntPtr hWnd,
			ref Guid pgActionID,
			ref NativeStructs.WINTRUST_DATA pWinTrustData
			);


		internal static void ThrowOnWin32Error(string message) {
			int lastWin32Error = Marshal.GetLastWin32Error();
			ThrowOnWin32Error(message, lastWin32Error);
		}

		internal static void ThrowOnWin32Error(string message, NativeErrors lastWin32Error) {
			ThrowOnWin32Error(message, (int) lastWin32Error);
		}

		internal static void ThrowOnWin32Error(string message, int lastWin32Error) {
			if (lastWin32Error != NativeConstants.ERROR_SUCCESS) {
				string exMessageFormat = "{0} ({1}, {2})";
				string exMessage = string.Format(exMessageFormat, message, lastWin32Error,
				                                 ((NativeErrors) lastWin32Error).ToString());

				throw new Win32Exception(lastWin32Error, exMessage);
			}
		}
	}
}