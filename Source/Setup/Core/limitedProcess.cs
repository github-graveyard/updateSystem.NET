#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace updateSystemDotNet.Setup.Core {
	internal static class limitedProcess {
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern IntPtr GetShellWindow();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CloseHandle(IntPtr hObject);

		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern bool CreateProcessWithTokenW(IntPtr hToken, uint dwLogonFlags, string lpApplicationName,
		                                                   string lpCommandLine, uint dwCreationFlags, IntPtr lpEnvironment,
		                                                   string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo,
		                                                   out PROCESS_INFORMATION lpProcessInformation);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool DuplicateTokenEx(
			IntPtr hExistingToken,
			uint dwDesiredAccess,
			IntPtr lpTokenAttributes,
			int ImpersonationLevel,
			int TokenType,
			out IntPtr phNewToken);

		[DllImport("shell32.dll")]
		private static extern bool IsUserAnAdmin();

		public static void Start(string filename) {
			Start(filename, null);
		}

		public static void Start(string filename, string arguments) {
			bool processCreated = false;

			if (Environment.OSVersion.Version.Major >= 6 && IsUserAnAdmin()) {
				//Get window handle representing the desktop shell.  This might not work if there is no shell window, or when
				//using a custom shell.  Also note that we're assuming that the shell is not running elevated.
				IntPtr hShellWnd = GetShellWindow();
				if (hShellWnd == IntPtr.Zero) {
					MessageBox.Show("Unable to locate shell window; you might be using a custom shell");
					return;
				}

				//Get the ID of the desktop shell process.
				int dwShellPID;
				GetWindowThreadProcessId(hShellWnd, out dwShellPID);
				if (dwShellPID != 0) {
					//Open the desktop shell process in order to get the process token.
					// PROCESS_QUERY_INFORMATION = 0x00000400
					IntPtr hShellProcess = OpenProcess(0x0400, false, dwShellPID);

					if (hShellProcess != IntPtr.Zero) {
						IntPtr hShellProcessToken;

						//Get the process token of the desktop shell.

						//TOKEN_DUPLICATE = 0x0002
						if (OpenProcessToken(hShellProcess, 0x2, out hShellProcessToken)) {
							IntPtr hPrimaryToken;
							//Duplicate the shell's process token to get a primary token.

							//TOKEN_QUERY = 0x0008
							//TOKEN_ASSIGN_PRIMARY = 0x0001
							//TOKEN_DUPLICATE = 0x0002
							//TOKEN_ADJUST_DEFAULT = 0x0080
							//TOKEN_ADJUST_SESSIONID = 0x0100;
							const uint dwTokenRights = 0x0008 | 0x0001 | 0x0002 | 0x0080 | 0x0100;
							//SecurityImpersonation = 2
							//TokenPrimary = 1
							if (DuplicateTokenEx(hShellProcessToken, dwTokenRights, IntPtr.Zero, 2, 1, out hPrimaryToken)) {
								//Start the target process with the new token.
								PROCESS_INFORMATION pi;

								var si = new STARTUPINFO();
								si.cb = Marshal.SizeOf(si);

								// build the arguments string
								if (string.IsNullOrEmpty(arguments))
									arguments = filename;
								else
									arguments = filename + " " + arguments;

								processCreated = CreateProcessWithTokenW(hPrimaryToken, 0, filename, arguments, 0, IntPtr.Zero, null, ref si,
								                                         out pi);

								if (processCreated) {
									//return Process.GetProcessById(pi.dwProcessId);
									CloseHandle(pi.hProcess);
									CloseHandle(pi.hThread);
								}

								if (hPrimaryToken != IntPtr.Zero)
									CloseHandle(hPrimaryToken);
							}

							if (hShellProcessToken != IntPtr.Zero)
								CloseHandle(hShellProcessToken);
						}

						if (hShellProcess != IntPtr.Zero)
							CloseHandle(hShellProcess);
					}
				}
			}

			// the process failed to be created for any number of reasons
			// just create it using the regular method
			if (!processCreated) {
				Process.Start(filename, arguments);
			}
		}

		#region Nested type: PROCESS_INFORMATION

		[StructLayout(LayoutKind.Sequential)]
		private struct PROCESS_INFORMATION {
			public readonly IntPtr hProcess;
			public readonly IntPtr hThread;
			public readonly uint dwProcessId;
			public readonly uint dwThreadId;
		}

		#endregion

		#region Nested type: STARTUPINFO

		[StructLayout(LayoutKind.Sequential)]
		private struct STARTUPINFO {
			public int cb;
			public readonly String lpReserved;
			public readonly String lpDesktop;
			public readonly String lpTitle;
			public readonly uint dwX;
			public readonly uint dwY;
			public readonly uint dwXSize;
			public readonly uint dwYSize;
			public readonly uint dwXCountChars;
			public readonly uint dwYCountChars;
			public readonly uint dwFillAttribute;
			public readonly uint dwFlags;
			public readonly short wShowWindow;
			public readonly short cbReserved2;
			public readonly IntPtr lpReserved2;
			public readonly IntPtr hStdInput;
			public readonly IntPtr hStdOutput;
			public readonly IntPtr hStdError;
		}

		#endregion
	}
}