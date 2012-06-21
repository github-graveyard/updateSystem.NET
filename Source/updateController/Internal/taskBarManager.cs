/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
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
using System.Diagnostics;
using System.Runtime.InteropServices;
using updateSystemDotNet.Core;

namespace updateSystemDotNet.Internal {
	/// <summary>
	/// Klasse zum Verwalten der neuen TaskBar-Funktionalitäten unter Windows 7.
	/// <para>Singleton.</para>
	/// </summary>
	internal class taskBarManager {
		private static taskBarManager _instance;
		private static readonly Object _syncLock = new Object();
		private readonly IntPtr _mainWndHandle;
		private ITaskbarList4 _taskbarList;

		/// <summary>
		/// Initialisiert eine neue Instanz von TaskBarManager
		/// </summary>
		private taskBarManager() {
			try {
				_mainWndHandle = Process.GetCurrentProcess().MainWindowHandle;
			}
			catch (Exception ex) {
				_mainWndHandle = IntPtr.Zero;
				Log.Instance.writeEntry("Could not gather MainWindowHandle.", "Win7TaskBarManager");
				Log.Instance.writeException(ex);
			}
		}

		#region " ITaskBarList "

		[ComImport]
		[GuidAttribute("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
		[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
		private interface ITaskbarList4 {
			// ITaskbarList
			[PreserveSig]
			void HrInit();

			[PreserveSig]
			void AddTab(IntPtr hwnd);

			[PreserveSig]
			void DeleteTab(IntPtr hwnd);

			[PreserveSig]
			void ActivateTab(IntPtr hwnd);

			[PreserveSig]
			void SetActiveAlt(IntPtr hwnd);

			// ITaskbarList2
			[PreserveSig]
			void MarkFullscreenWindow(
				IntPtr hwnd,
				[MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

			// ITaskbarList3
			[PreserveSig]
			void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);

			[PreserveSig]
			void SetProgressState(IntPtr hwnd, taskBarProgressState tbpFlags);

			[PreserveSig]
			void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

			[PreserveSig]
			void UnregisterTab(IntPtr hwndTab);

			[PreserveSig]
			void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

			[PreserveSig]
			void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);

			[PreserveSig]
			void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);

			[PreserveSig]
			void SetOverlayIcon(
				IntPtr hwnd,
				IntPtr hIcon,
				[MarshalAs(UnmanagedType.LPWStr)] string pszDescription);


			[PreserveSig]
			void SetThumbnailTooltip(
				IntPtr hwnd,
				[MarshalAs(UnmanagedType.LPWStr)] string pszTip);
		}

		#endregion

		#region " CTaskBarList "

		[GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
		[ClassInterfaceAttribute(ClassInterfaceType.None)]
		[ComImportAttribute]
		private class CTaskbarList {
		}

		#endregion

		/// <summary>
		/// Gibt die Singleton Instanz des TaskBarManagers zurück.
		/// </summary>
		public static taskBarManager Instance {
			get { return _instance ?? (_instance = new taskBarManager()); }
		}

		private ITaskbarList4 TaskbarList {
			get {
				if (_taskbarList == null) {
					// Create a new instance of ITaskbarList4
					lock (_syncLock) {
						if (_taskbarList == null) {
							_taskbarList = (ITaskbarList4) new CTaskbarList();
							_taskbarList.HrInit();
						}
					}
				}

				return _taskbarList;
			}
		}

		/// <summary>
		/// Setzt den TaskBarState im TaskBarButton.
		/// </summary>
		/// <param name="state">Der Status.</param>
		public void setTaskBarProgressState(taskBarProgressState state) {
			if (_mainWndHandle != IntPtr.Zero) {
				if (Helper.isSevenOrGreater) TaskbarList.SetProgressState(_mainWndHandle, state);
			}
		}

		/// <summary>
		/// Setzt den Fortschritt im TaskBarButton.
		/// </summary>
		/// <param name="currentValue">Die aktuelle Wert.</param>
		/// <param name="maxValue">Der maximal Wert.</param>
		public void setTaskBarProgressValue(ulong currentValue, ulong maxValue) {
			if (_mainWndHandle != IntPtr.Zero) {
				if (Helper.isSevenOrGreater) TaskbarList.SetProgressValue(_mainWndHandle, currentValue, maxValue);
			}
		}
	}
}