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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace updateSystemDotNet.Setup.Core {
	/// <remarks>
	///   .NET friendly wrapper for the ShellLink class
	/// </remarks>
	internal class ShellShortcut : IDisposable {
		private const int INFOTIPSIZE = 1024;
		private const int MAX_PATH = 260;

		private const int SW_SHOWNORMAL = 1;
		private const int SW_SHOWMINIMIZED = 2;
		private const int SW_SHOWMAXIMIZED = 3;
		private const int SW_SHOWMINNOACTIVE = 7;


#if UNICODE
	private IShellLinkW m_Link;
#else
		private IShellLinkA m_Link;
#endif
		private readonly string m_sPath;

		///
		/// <param name='linkPath'>
		///   Path to new or existing shortcut file (.lnk).
		/// </param>
		///
		public ShellShortcut(string linkPath) {
			IPersistFile pf;

			m_sPath = linkPath;

#if UNICODE
	  m_Link = (IShellLinkW) new ShellLink();
#else
			m_Link = (IShellLinkA) new ShellLink();
#endif

			if (File.Exists(linkPath)) {
				pf = (IPersistFile) m_Link;
				pf.Load(linkPath, 0);
			}
		}

		//
		//  IDisplosable implementation
		//
		public void Dispose() {
			if (m_Link != null) {
				Marshal.ReleaseComObject(m_Link);
				m_Link = null;
			}
		}

		/// <value>
		///   Gets or sets the argument list of the shortcut.
		/// </value>
		public string Arguments {
			get {
				var sb = new StringBuilder(INFOTIPSIZE);
				m_Link.GetArguments(sb, sb.Capacity);
				return sb.ToString();
			}
			set { m_Link.SetArguments(value); }
		}

		/// <value>
		///   Gets or sets a description of the shortcut.
		/// </value>
		public string Description {
			get {
				var sb = new StringBuilder(INFOTIPSIZE);
				m_Link.GetDescription(sb, sb.Capacity);
				return sb.ToString();
			}
			set { m_Link.SetDescription(value); }
		}

		/// <value>
		///   Gets or sets the working directory (aka start in directory) of the shortcut.
		/// </value>
		public string WorkingDirectory {
			get {
				var sb = new StringBuilder(MAX_PATH);
				m_Link.GetWorkingDirectory(sb, sb.Capacity);
				return sb.ToString();
			}
			set { m_Link.SetWorkingDirectory(value); }
		}

		//
		// If Path returns an empty string, the shortcut is associated with
		// a PIDL instead, which can be retrieved with IShellLink.GetIDList().
		// This is beyond the scope of this wrapper class.
		//
		/// <value>
		///   Gets or sets the target path of the shortcut.
		/// </value>
		public string Path {
			get {
#if UNICODE
		WIN32_FIND_DATAW wfd = new WIN32_FIND_DATAW();
#else
				var wfd = new WIN32_FIND_DATAA();
#endif
				var sb = new StringBuilder(MAX_PATH);

				m_Link.GetPath(sb, sb.Capacity, out wfd, SLGP_FLAGS.SLGP_UNCPRIORITY);
				return sb.ToString();
			}
			set { m_Link.SetPath(value); }
		}

		/// <value>
		///   Gets or sets the path of the <see cref="Icon"/> assigned to the shortcut.
		/// </value>
		/// <summary>
		///   <seealso cref="IconIndex"/>
		/// </summary>
		public string IconPath {
			get {
				var sb = new StringBuilder(MAX_PATH);
				int nIconIdx;
				m_Link.GetIconLocation(sb, sb.Capacity, out nIconIdx);
				return sb.ToString();
			}
			set { m_Link.SetIconLocation(value, IconIndex); }
		}

		/// <value>
		///   Gets or sets the index of the <see cref="Icon"/> assigned to the shortcut.
		///   Set to zero when the <see cref="IconPath"/> property specifies a .ICO file.
		/// </value>
		/// <summary>
		///   <seealso cref="IconPath"/>
		/// </summary>
		public int IconIndex {
			get {
				var sb = new StringBuilder(MAX_PATH);
				int nIconIdx;
				m_Link.GetIconLocation(sb, sb.Capacity, out nIconIdx);
				return nIconIdx;
			}
			set { m_Link.SetIconLocation(IconPath, value); }
		}

		/// <value>
		///   Retrieves the Icon of the shortcut as it will appear in Explorer.
		///   Use the <see cref="IconPath"/> and <see cref="IconIndex"/>
		///   properties to change it.
		/// </value>
		public Icon Icon {
			get {
				var sb = new StringBuilder(MAX_PATH);
				int nIconIdx;
				IntPtr hIcon, hInst;
				Icon ico, clone;


				m_Link.GetIconLocation(sb, sb.Capacity, out nIconIdx);
				hInst = Marshal.GetHINSTANCE(GetType().Module);
				hIcon = Native.ExtractIcon(hInst, sb.ToString(), nIconIdx);
				if (hIcon == IntPtr.Zero)
					return null;

				// Return a cloned Icon, because we have to free the original ourselves.
				ico = Icon.FromHandle(hIcon);
				clone = (Icon) ico.Clone();
				ico.Dispose();
				Native.DestroyIcon(hIcon);
				return clone;
			}
		}

		/// <value>
		///   Gets or sets the System.Diagnostics.ProcessWindowStyle value
		///   that decides the initial show state of the shortcut target. Note that
		///   ProcessWindowStyle.Hidden is not a valid property value.
		/// </value>
		public ProcessWindowStyle WindowStyle {
			get {
				int nWS;
				m_Link.GetShowCmd(out nWS);

				switch (nWS) {
					case SW_SHOWMINIMIZED:
					case SW_SHOWMINNOACTIVE:
						return ProcessWindowStyle.Minimized;

					case SW_SHOWMAXIMIZED:
						return ProcessWindowStyle.Maximized;

					default:
						return ProcessWindowStyle.Normal;
				}
			}
			set {
				int nWS;

				switch (value) {
					case ProcessWindowStyle.Normal:
						nWS = SW_SHOWNORMAL;
						break;

					case ProcessWindowStyle.Minimized:
						nWS = SW_SHOWMINNOACTIVE;
						break;

					case ProcessWindowStyle.Maximized:
						nWS = SW_SHOWMAXIMIZED;
						break;

					default: // ProcessWindowStyle.Hidden
						throw new ArgumentException("Unsupported ProcessWindowStyle value.");
				}

				m_Link.SetShowCmd(nWS);
			}
		}

		/// <value>
		///   Gets or sets the hotkey for the shortcut.
		/// </value>
		public Keys Hotkey {
			get {
				short wHotkey;
				int dwHotkey;

				m_Link.GetHotkey(out wHotkey);

				//
				// Convert from IShellLink 16-bit format to Keys enumeration 32-bit value
				// IShellLink: 0xMMVK
				// Keys:  0x00MM00VK        
				//   MM = Modifier (Alt, Control, Shift)
				//   VK = Virtual key code
				//       
				dwHotkey = ((wHotkey & 0xFF00) << 8) | (wHotkey & 0xFF);
				return (Keys) dwHotkey;
			}
			set {
				short wHotkey;

				if ((value & Keys.Modifiers) == 0)
					throw new ArgumentException("Hotkey must include a modifier key.");

				//    
				// Convert from Keys enumeration 32-bit value to IShellLink 16-bit format
				// IShellLink: 0xMMVK
				// Keys:  0x00MM00VK        
				//   MM = Modifier (Alt, Control, Shift)
				//   VK = Virtual key code
				//       
				wHotkey = unchecked((short) (((int) (value & Keys.Modifiers) >> 8) | (int) (value & Keys.KeyCode)));
				m_Link.SetHotkey(wHotkey);
			}
		}

		/// <summary>
		///   Saves the shortcut to disk.
		/// </summary>
		public void Save() {
			var pf = (IPersistFile) m_Link;
			pf.Save(m_sPath, true);
		}

		/// <summary>
		///   Returns a reference to the internal ShellLink object,
		///   which can be used to perform more advanced operations
		///   not supported by this wrapper class, by using the
		///   IShellLink interface directly.
		/// </summary>
		public object ShellLink {
			get { return m_Link; }
		}

		#region Native Win32 API functions

		private class Native {
			[DllImport("shell32.dll", CharSet = CharSet.Auto)]
			public static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

			[DllImport("user32.dll")]
			public static extern bool DestroyIcon(IntPtr hIcon);
		}

		#endregion
	}
}