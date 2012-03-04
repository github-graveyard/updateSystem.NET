using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace updateSystemDotNet.Setup.Core {
	/// <summary>
	/// Represents the thumbnail progress bar state.
	/// </summary>
	internal enum taskBarProgressState {
		/// <summary>
		/// No progress is displayed.
		/// </summary>
		NoProgress = 0,
		/// <summary>
		/// The progress is indeterminate (marquee).
		/// </summary>
		Indeterminate = 0x1,
		/// <summary>
		/// Normal progress is displayed.
		/// </summary>
		Normal = 0x2,
		/// <summary>
		/// An error occurred (red).
		/// </summary>
		Error = 0x4,
		/// <summary>
		/// The operation is paused (yellow).
		/// </summary>
		Paused = 0x8
	}

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
			catch {
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
			get {
				if (_instance == null)
					_instance = new taskBarManager();
				return _instance;
			}
		}

		private bool isSevenOrGreater {
			get { return (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1); }
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
				if (isSevenOrGreater) TaskbarList.SetProgressState(_mainWndHandle, state);
			}
		}

		/// <summary>
		/// Setzt den Fortschritt im TaskBarButton.
		/// </summary>
		/// <param name="currentValue">Die aktuelle Wert.</param>
		/// <param name="maxValue">Der maximal Wert.</param>
		public void setTaskBarProgressValue(ulong currentValue, ulong maxValue) {
			if (_mainWndHandle != IntPtr.Zero) {
				if (isSevenOrGreater) TaskbarList.SetProgressValue(_mainWndHandle, currentValue, maxValue);
			}
		}
	}
}