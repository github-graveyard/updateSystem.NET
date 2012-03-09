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
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace updateSystemDotNet.Updater.Win32 {
	internal static class Security {
		public static int ExecRequireNonAdmin(IWin32Window parent, string exePath, string args, out IntPtr hProcess) {
			int nError = NativeConstants.ERROR_SUCCESS;
			string commandLine = "\"" + exePath + "\"" + (args == null ? "" : (" " + args));

			string dir;

			try {
				dir = Path.GetDirectoryName(exePath);
			}

			catch (Exception) {
				dir = null;
			}

			IntPtr hWndShell = IntPtr.Zero;
			IntPtr hShellProcess = IntPtr.Zero;
			IntPtr hShellProcessToken = IntPtr.Zero;
			IntPtr hTokenCopy = IntPtr.Zero;
			IntPtr bstrExePath = IntPtr.Zero;
			IntPtr bstrCommandLine = IntPtr.Zero;
			IntPtr bstrDir = IntPtr.Zero;
			var procInfo = new NativeStructs.PROCESS_INFORMATION();

			try {
				hWndShell = SafeNativeMethods.FindWindowW("Progman", null);
				if (hWndShell == IntPtr.Zero) {
					NativeMethods.ThrowOnWin32Error("FindWindowW() returned NULL");
				}

				uint dwPID;
				uint dwThreadId = SafeNativeMethods.GetWindowThreadProcessId(hWndShell, out dwPID);
				if (0 == dwPID) {
					NativeMethods.ThrowOnWin32Error("GetWindowThreadProcessId returned 0", NativeErrors.ERROR_FILE_NOT_FOUND);
				}

				hShellProcess = NativeMethods.OpenProcess(NativeConstants.PROCESS_QUERY_INFORMATION, false, dwPID);
				if (IntPtr.Zero == hShellProcess) {
					NativeMethods.ThrowOnWin32Error("OpenProcess() returned NULL");
				}

				bool optResult = NativeMethods.OpenProcessToken(
					hShellProcess,
					NativeConstants.TOKEN_ASSIGN_PRIMARY | NativeConstants.TOKEN_DUPLICATE | NativeConstants.TOKEN_QUERY,
					out hShellProcessToken);

				if (!optResult) {
					NativeMethods.ThrowOnWin32Error("OpenProcessToken() returned FALSE");
				}

				bool dteResult = NativeMethods.DuplicateTokenEx(
					hShellProcessToken,
					NativeConstants.MAXIMUM_ALLOWED,
					IntPtr.Zero,
					NativeConstants.SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation,
					NativeConstants.TOKEN_TYPE.TokenPrimary,
					out hTokenCopy);

				if (!dteResult) {
					NativeMethods.ThrowOnWin32Error("DuplicateTokenEx() returned FALSE");
				}

				bstrExePath = Marshal.StringToBSTR(exePath);
				bstrCommandLine = Marshal.StringToBSTR(commandLine);
				bstrDir = Marshal.StringToBSTR(dir);

				bool cpwtResult = NativeMethods.CreateProcessWithTokenW(
					hTokenCopy,
					0,
					bstrExePath,
					bstrCommandLine,
					0,
					IntPtr.Zero,
					bstrDir,
					IntPtr.Zero,
					out procInfo);

				if (cpwtResult) {
					hProcess = procInfo.hProcess;
					procInfo.hProcess = IntPtr.Zero;
					nError = NativeConstants.ERROR_SUCCESS;
				}
				else {
					hProcess = IntPtr.Zero;
					nError = Marshal.GetLastWin32Error();
				}
			}

			catch (Win32Exception ex) {
				nError = ex.ErrorCode;
				hProcess = IntPtr.Zero;
			}

			finally {
				if (bstrExePath != IntPtr.Zero) {
					Marshal.FreeBSTR(bstrExePath);
					bstrExePath = IntPtr.Zero;
				}

				if (bstrCommandLine != IntPtr.Zero) {
					Marshal.FreeBSTR(bstrCommandLine);
					bstrCommandLine = IntPtr.Zero;
				}

				if (bstrDir != IntPtr.Zero) {
					Marshal.FreeBSTR(bstrDir);
					bstrDir = IntPtr.Zero;
				}

				if (hShellProcess != IntPtr.Zero) {
					SafeNativeMethods.CloseHandle(hShellProcess);
					hShellProcess = IntPtr.Zero;
				}

				if (hShellProcessToken != IntPtr.Zero) {
					SafeNativeMethods.CloseHandle(hShellProcessToken);
					hShellProcessToken = IntPtr.Zero;
				}

				if (hTokenCopy != IntPtr.Zero) {
					SafeNativeMethods.CloseHandle(hTokenCopy);
					hTokenCopy = IntPtr.Zero;
				}

				if (procInfo.hThread != IntPtr.Zero) {
					SafeNativeMethods.CloseHandle(procInfo.hThread);
					procInfo.hThread = IntPtr.Zero;
				}

				if (procInfo.hProcess != IntPtr.Zero) {
					SafeNativeMethods.CloseHandle(procInfo.hProcess);
					procInfo.hProcess = IntPtr.Zero;
				}
			}

			return nError;
		}

		/// <summary>
		/// Verifies that a file has a valid digital signature.
		/// </summary>
		/// <param name="owner">The parent/owner window for any UI that may be shown.</param>
		/// <param name="fileName">The path to the file to be validate.</param>
		/// <param name="showNegativeUI">Whether or not to show a UI in the case that the signature can not be found or validated.</param>
		/// <param name="showPositiveUI">Whether or not to show a UI in the case that the signature is successfully found and validated.</param>
		/// <returns>true if the file has a digital signature that validates up to a trusted root, or false otherwise</returns>
		public static bool VerifySignedFile(IWin32Window owner, string fileName, bool showNegativeUI, bool showPositiveUI) {
			unsafe {
				fixed (char* szFileName = fileName) {
					Guid pgActionID = NativeConstants.WINTRUST_ACTION_GENERIC_VERIFY_V2;

					var fileInfo = new NativeStructs.WINTRUST_FILE_INFO();
					fileInfo.cbStruct = (uint) sizeof (NativeStructs.WINTRUST_FILE_INFO);
					fileInfo.pcwszFilePath = szFileName;

					var wintrustData = new NativeStructs.WINTRUST_DATA();
					wintrustData.cbStruct = (uint) sizeof (NativeStructs.WINTRUST_DATA);

					if (!showNegativeUI && !showPositiveUI) {
						wintrustData.dwUIChoice = NativeConstants.WTD_UI_NONE;
					}
					else if (!showNegativeUI && showPositiveUI) {
						wintrustData.dwUIChoice = NativeConstants.WTD_UI_NOBAD;
					}
					else if (showNegativeUI && !showPositiveUI) {
						wintrustData.dwUIChoice = NativeConstants.WTD_UI_NOGOOD;
					}
					else // if (showNegativeUI && showPositiveUI)
					{
						wintrustData.dwUIChoice = NativeConstants.WTD_UI_ALL;
					}

					wintrustData.fdwRevocationChecks = NativeConstants.WTD_REVOKE_WHOLECHAIN;
					wintrustData.dwUnionChoice = NativeConstants.WTD_CHOICE_FILE;
					wintrustData.pInfo = &fileInfo;

					IntPtr handle;

					if (owner == null) {
						handle = IntPtr.Zero;
					}
					else {
						handle = owner.Handle;
					}

					int result = NativeMethods.WinVerifyTrust(handle, ref pgActionID, ref wintrustData);

					GC.KeepAlive(owner);
					return result >= 0;
				}
			}
		}
	}
}