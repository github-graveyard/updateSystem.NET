using System;
using System.Runtime.InteropServices;
using System.Security;

namespace updateSystemDotNet.Updater.Win32 {
	[SuppressUnmanagedCodeSecurity]
	internal static class SafeNativeMethods {
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool CloseHandle(IntPtr hObject);

		[DllImport("user32.dll", SetLastError = false)]
		internal static extern uint GetWindowThreadProcessId(
			IntPtr hWnd,
			out uint lpdwProcessId);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern IntPtr FindWindowW(
			[MarshalAs(UnmanagedType.LPWStr)] string lpClassName,
			[MarshalAs(UnmanagedType.LPWStr)] string lpWindowName);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern IntPtr FindWindowExW(
			IntPtr hwndParent,
			IntPtr hwndChildAfter,
			[MarshalAs(UnmanagedType.LPWStr)] string lpszClass,
			[MarshalAs(UnmanagedType.LPWStr)] string lpszWindow);


		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern IntPtr GlobalFree(IntPtr hMem);
	}
}