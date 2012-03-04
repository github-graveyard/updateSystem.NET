using System;
using System.Runtime.InteropServices;

namespace updateSystemDotNet.Internal {
	internal sealed class WinTrust {
		private const string WINTRUST_ACTION_GENERIC_VERIFY_V2 = "{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}";
		private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

		private WinTrust() {
		}

		[DllImport("wintrust.dll", ExactSpelling = true, SetLastError = false, CharSet = CharSet.Unicode)]
		private static extern WinVerifyTrustResult WinVerifyTrust(
			[In] IntPtr hwnd,
			[In] [MarshalAs(UnmanagedType.LPStruct)] Guid pgActionID,
			[In] WinTrustData pWVTData
			);

		// call WinTrust.WinVerifyTrust() to check embedded file signature
		public static bool VerifyEmbeddedSignature(string fileName) {
			var wtd = new WinTrustData(fileName);
			var guidAction = new Guid(WINTRUST_ACTION_GENERIC_VERIFY_V2);
			WinVerifyTrustResult result = WinVerifyTrust(INVALID_HANDLE_VALUE, guidAction, wtd);
			bool ret = (result == WinVerifyTrustResult.Success);
			return ret;
		}

		#region Nested type: WinTrustDataChoice

		private enum WinTrustDataChoice : uint {
			File = 1,
			Catalog = 2,
			Blob = 3,
			Signer = 4,
			Certificate = 5
		}

		#endregion

		#region Nested type: WinTrustDataProvFlags

		[FlagsAttribute]
		private enum WinTrustDataProvFlags : uint {
			UseIe4TrustFlag = 0x00000001,
			NoIe4ChainFlag = 0x00000002,
			NoPolicyUsageFlag = 0x00000004,
			RevocationCheckNone = 0x00000010,
			RevocationCheckEndCert = 0x00000020,
			RevocationCheckChain = 0x00000040,
			RevocationCheckChainExcludeRoot = 0x00000080,
			SaferFlag = 0x00000100,
			HashOnlyFlag = 0x00000200,
			UseDefaultOsverCheck = 0x00000400,
			LifetimeSigningFlag = 0x00000800,
			CacheOnlyUrlRetrieval = 0x00001000 // affects CRL retrieval and AIA retrieval
		}

		#endregion

		#region Nested type: WinTrustDataRevocationChecks

		private enum WinTrustDataRevocationChecks : uint {
			None = 0x00000000,
			WholeChain = 0x00000001
		}

		#endregion

		#region Nested type: WinTrustDataStateAction

		private enum WinTrustDataStateAction : uint {
			Ignore = 0x00000000,
			Verify = 0x00000001,
			Close = 0x00000002,
			AutoCache = 0x00000003,
			AutoCacheFlush = 0x00000004
		}

		#endregion

		#region Nested type: WinTrustDataUIChoice

		private enum WinTrustDataUIChoice : uint {
			All = 1,
			None = 2,
			NoBad = 3,
			NoGood = 4
		}

		#endregion

		#region Nested type: WinTrustDataUIContext

		private enum WinTrustDataUIContext : uint {
			Execute = 0,
			Install = 1
		}

		#endregion

		#region WinTrust structures

		#region Nested type: WinTrustData

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private class WinTrustData {
			private UInt32 StructSize = (UInt32) Marshal.SizeOf(typeof (WinTrustData));
			private IntPtr PolicyCallbackData = IntPtr.Zero;
			private IntPtr SIPClientData = IntPtr.Zero;
			// required: UI choice
			private WinTrustDataUIChoice UIChoice = WinTrustDataUIChoice.None;
			// required: certificate revocation check options
			private WinTrustDataRevocationChecks RevocationChecks = WinTrustDataRevocationChecks.None;
			// required: which structure is being passed in?
			private WinTrustDataChoice UnionChoice = WinTrustDataChoice.File;
			// individual file
			private readonly IntPtr FileInfoPtr;
			private WinTrustDataStateAction StateAction = WinTrustDataStateAction.Ignore;
			private IntPtr StateData = IntPtr.Zero;
			private String URLReference;
			private WinTrustDataProvFlags ProvFlags = WinTrustDataProvFlags.SaferFlag;
			private WinTrustDataUIContext UIContext = WinTrustDataUIContext.Execute;

			// constructor for silent WinTrustDataChoice.File check
			public WinTrustData(String _fileName) {
				var wtfiData = new WinTrustFileInfo(_fileName);
				FileInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof (WinTrustFileInfo)));
				Marshal.StructureToPtr(wtfiData, FileInfoPtr, false);
			}

			~WinTrustData() {
				Marshal.FreeCoTaskMem(FileInfoPtr);
			}
		}

		#endregion

		#region Nested type: WinTrustFileInfo

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private class WinTrustFileInfo {
			private UInt32 StructSize = (UInt32) Marshal.SizeOf(typeof (WinTrustFileInfo));
			private readonly IntPtr pszFilePath; // required, file name to be verified
			private IntPtr hFile = IntPtr.Zero; // optional, open handle to FilePath
			private IntPtr pgKnownSubject = IntPtr.Zero; // optional, subject type if it is known

			public WinTrustFileInfo(String _filePath) {
				pszFilePath = Marshal.StringToCoTaskMemAuto(_filePath);
			}

			~WinTrustFileInfo() {
				Marshal.FreeCoTaskMem(pszFilePath);
			}
		}

		#endregion

		#endregion

		#region Nested type: WinVerifyTrustResult

		private enum WinVerifyTrustResult : uint {
			Success = 0,
			ProviderUnknown = 0x800b0001, // The trust provider is not recognized on this system
			ActionUnknown = 0x800b0002, // The trust provider does not support the specified action
			SubjectFormUnknown = 0x800b0003, // The trust provider does not support the form specified for the subject
			SubjectNotTrusted = 0x800b0004 // The subject failed the specified verification action
		}

		#endregion
	}
}