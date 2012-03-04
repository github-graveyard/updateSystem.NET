using System;

namespace updateSystemDotNet.Updater.Win32 {
	internal static class NativeConstants {
		#region CDCONTROLSTATE enum

		public enum CDCONTROLSTATE {
			CDCS_INACTIVE = 0x00000000,
			CDCS_ENABLED = 0x00000001,
			CDCS_VISIBLE = 0x00000002
		}

		#endregion

		#region FDAP enum

		public enum FDAP {
			FDAP_BOTTOM = 0x00000000,
			FDAP_TOP = 0x00000001,
		}

		#endregion

		#region FDE_OVERWRITE_RESPONSE enum

		public enum FDE_OVERWRITE_RESPONSE {
			FDEOR_DEFAULT = 0x00000000,
			FDEOR_ACCEPT = 0x00000001,
			FDEOR_REFUSE = 0x00000002
		}

		#endregion

		#region FDE_SHAREVIOLATION_RESPONSE enum

		public enum FDE_SHAREVIOLATION_RESPONSE {
			FDESVR_DEFAULT = 0x00000000,
			FDESVR_ACCEPT = 0x00000001,
			FDESVR_REFUSE = 0x00000002
		}

		#endregion

		#region FFFP_MODE enum

		public enum FFFP_MODE {
			FFFP_EXACTMATCH,
			FFFP_NEARESTPARENTMATCH
		}

		#endregion

		#region FOF enum

		public enum FOF
			: uint {
			FOF_MULTIDESTFILES = 0x0001,
			FOF_CONFIRMMOUSE = 0x0002,
			FOF_SILENT = 0x0004, // don't display progress UI (confirm prompts may be displayed still)
			FOF_RENAMEONCOLLISION = 0x0008, // automatically rename the source files to avoid the collisions
			FOF_NOCONFIRMATION = 0x0010,
			// don't display confirmation UI, assume "yes" for cases that can be bypassed, "no" for those that can not
			FOF_WANTMAPPINGHANDLE = 0x0020, // Fill in SHFILEOPSTRUCT.hNameMappings
			// Must be freed using SHFreeNameMappings
			FOF_ALLOWUNDO = 0x0040, // enable undo including Recycle behavior for IFileOperation::Delete()
			FOF_FILESONLY = 0x0080, // only operate on the files (non folders), both files and folders are assumed without this
			FOF_SIMPLEPROGRESS = 0x0100, // means don't show names of files
			FOF_NOCONFIRMMKDIR = 0x0200,
			// don't dispplay confirmatino UI before making any needed directories, assume "Yes" in these cases
			FOF_NOERRORUI = 0x0400, // don't put up error UI, other UI may be displayed, progress, confirmations
			FOF_NOCOPYSECURITYATTRIBS = 0x0800, // dont copy file security attributes (ACLs)
			FOF_NORECURSION = 0x1000, // don't recurse into directories for operations that would recurse
			FOF_NO_CONNECTED_ELEMENTS = 0x2000,
			// don't operate on connected elements ("xxx_files" folders that go with .htm files)
			FOF_WANTNUKEWARNING = 0x4000,
			// during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
			FOF_NORECURSEREPARSE = 0x8000,
			// deprecated; the operations engine always does the right thing on FolderLink objects (symlinks, reparse points, folder shortcuts)

			FOF_NO_UI = (FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR), // don't display any UI at all

			FOFX_NOSKIPJUNCTIONS = 0x00010000, // Don't avoid binding to junctions (like Task folder, Recycle-Bin)
			FOFX_PREFERHARDLINK = 0x00020000, // Create hard link if possible
			FOFX_SHOWELEVATIONPROMPT = 0x00040000, // Show elevation prompts when error UI is disabled (use with FOF_NOERRORUI)
			FOFX_EARLYFAILURE = 0x00100000,
			// Fail operation as soon as a single error occurs rather than trying to process other items (applies only when using FOF_NOERRORUI)
			FOFX_PRESERVEFILEEXTENSIONS = 0x00200000, // Rename collisions preserve file extns (use with FOF_RENAMEONCOLLISION)
			FOFX_KEEPNEWERFILE = 0x00400000, // Keep newer file on naming conflicts
			FOFX_NOCOPYHOOKS = 0x00800000, // Don't use copy hooks
			FOFX_NOMINIMIZEBOX = 0x01000000, // Don't allow minimizing the progress dialog
			FOFX_MOVEACLSACROSSVOLUMES = 0x02000000, // Copy security information when performing a cross-volume move operation
			FOFX_DONTDISPLAYSOURCEPATH = 0x04000000, // Don't display the path of source file in progress dialog
			FOFX_DONTDISPLAYDESTPATH = 0x08000000, // Don't display the path of destination file in progress dialog
			}

		#endregion

		#region FOS enum

		[Flags]
		public enum FOS : uint {
			FOS_OVERWRITEPROMPT = 0x00000002,
			FOS_STRICTFILETYPES = 0x00000004,
			FOS_NOCHANGEDIR = 0x00000008,
			FOS_PICKFOLDERS = 0x00000020,
			FOS_FORCEFILESYSTEM = 0x00000040, // Ensure that items returned are filesystem items.
			FOS_ALLNONSTORAGEITEMS = 0x00000080, // Allow choosing items that have no storage.
			FOS_NOVALIDATE = 0x00000100,
			FOS_ALLOWMULTISELECT = 0x00000200,
			FOS_PATHMUSTEXIST = 0x00000800,
			FOS_FILEMUSTEXIST = 0x00001000,
			FOS_CREATEPROMPT = 0x00002000,
			FOS_SHAREAWARE = 0x00004000,
			FOS_NOREADONLYRETURN = 0x00008000,
			FOS_NOTESTFILECREATE = 0x00010000,
			FOS_HIDEMRUPLACES = 0x00020000,
			FOS_HIDEPINNEDPLACES = 0x00040000,
			FOS_NODEREFERENCELINKS = 0x00100000,
			FOS_DONTADDTORECENT = 0x02000000,
			FOS_FORCESHOWHIDDEN = 0x10000000,
			FOS_DEFAULTNOMINIMODE = 0x20000000
		}

		#endregion

		#region KF_CATEGORY enum

		public enum KF_CATEGORY {
			KF_CATEGORY_VIRTUAL = 0x00000001,
			KF_CATEGORY_FIXED = 0x00000002,
			KF_CATEGORY_COMMON = 0x00000003,
			KF_CATEGORY_PERUSER = 0x00000004
		}

		#endregion

		#region KF_DEFINITION_FLAGS enum

		[Flags]
		public enum KF_DEFINITION_FLAGS {
			KFDF_PERSONALIZE = 0x00000001,
			KFDF_LOCAL_REDIRECT_ONLY = 0x00000002,
			KFDF_ROAMABLE = 0x00000004,
		}

		#endregion

		#region SECURITY_IMPERSONATION_LEVEL enum

		public enum SECURITY_IMPERSONATION_LEVEL {
			SecurityAnonymous = 0,
			SecurityIdentification = 1,
			SecurityImpersonation = 2,
			SecurityDelegation = 3
		}

		#endregion

		#region SFGAO enum

		[Flags]
		public enum SFGAO : uint {
			SFGAO_CANCOPY = DROPEFFECT_COPY, // Objects can be copied (0x1)
			SFGAO_CANMOVE = DROPEFFECT_MOVE, // Objects can be moved (0x2)
			SFGAO_CANLINK = DROPEFFECT_LINK, // Objects can be linked (0x4)
			SFGAO_STORAGE = 0x00000008, // supports BindToObject(IID_IStorage)
			SFGAO_CANRENAME = 0x00000010, // Objects can be renamed
			SFGAO_CANDELETE = 0x00000020, // Objects can be deleted
			SFGAO_HASPROPSHEET = 0x00000040, // Objects have property sheets
			SFGAO_DROPTARGET = 0x00000100, // Objects are drop target
			SFGAO_CAPABILITYMASK = 0x00000177,
			SFGAO_ENCRYPTED = 0x00002000, // Object is encrypted (use alt color)
			SFGAO_ISSLOW = 0x00004000, // 'Slow' object
			SFGAO_GHOSTED = 0x00008000, // Ghosted icon
			SFGAO_LINK = 0x00010000, // Shortcut (link)
			SFGAO_SHARE = 0x00020000, // Shared
			SFGAO_READONLY = 0x00040000, // Read-only
			SFGAO_HIDDEN = 0x00080000, // Hidden object
			SFGAO_DISPLAYATTRMASK = 0x000FC000,
			SFGAO_FILESYSANCESTOR = 0x10000000, // May contain children with SFGAO_FILESYSTEM
			SFGAO_FOLDER = 0x20000000, // Support BindToObject(IID_IShellFolder)
			SFGAO_FILESYSTEM = 0x40000000, // Is a win32 file system object (file/folder/root)
			SFGAO_HASSUBFOLDER = 0x80000000, // May contain children with SFGAO_FOLDER (may be slow)
			SFGAO_CONTENTSMASK = 0x80000000,
			SFGAO_VALIDATE = 0x01000000, // Invalidate cached information (may be slow)
			SFGAO_REMOVABLE = 0x02000000, // Is this removeable media?
			SFGAO_COMPRESSED = 0x04000000, // Object is compressed (use alt color)
			SFGAO_BROWSABLE = 0x08000000, // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
			SFGAO_NONENUMERATED = 0x00100000, // Is a non-enumerated object (should be hidden)
			SFGAO_NEWCONTENT = 0x00200000, // Should show bold in explorer tree
			SFGAO_STREAM = 0x00400000, // Supports BindToObject(IID_IStream)
			SFGAO_CANMONIKER = 0x00400000, // Obsolete
			SFGAO_HASSTORAGE = 0x00400000, // Obsolete
			SFGAO_STORAGEANCESTOR = 0x00800000, // May contain children with SFGAO_STORAGE or SFGAO_STREAM
			SFGAO_STORAGECAPMASK = 0x70C50008, // For determining storage capabilities, ie for open/save semantics
			SFGAO_PKEYSFGAOMASK = 0x81044010
			// Attributes that are masked out for PKEY_SFGAOFlags because they are considered to cause slow calculations or lack context (SFGAO_VALIDATE | SFGAO_ISSLOW | SFGAO_HASSUBFOLDER and others)
		}

		#endregion

		#region SIATTRIBFLAGS enum

		public enum SIATTRIBFLAGS {
			SIATTRIBFLAGS_AND = 0x00000001, // if multiple items and the attirbutes together.
			SIATTRIBFLAGS_OR = 0x00000002, // if multiple items or the attributes together.
			SIATTRIBFLAGS_APPCOMPAT = 0x00000003, // Call GetAttributes directly on the ShellFolder for multiple attributes
		}

		#endregion

		#region SIGDN enum

		public enum SIGDN : uint {
			SIGDN_NORMALDISPLAY = 0x00000000, // SHGDN_NORMAL
			SIGDN_PARENTRELATIVEPARSING = 0x80018001, // SHGDN_INFOLDER | SHGDN_FORPARSING
			SIGDN_DESKTOPABSOLUTEPARSING = 0x80028000, // SHGDN_FORPARSING
			SIGDN_PARENTRELATIVEEDITING = 0x80031001, // SHGDN_INFOLDER | SHGDN_FOREDITING
			SIGDN_DESKTOPABSOLUTEEDITING = 0x8004c000, // SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
			SIGDN_FILESYSPATH = 0x80058000, // SHGDN_FORPARSING
			SIGDN_URL = 0x80068000, // SHGDN_FORPARSING
			SIGDN_PARENTRELATIVEFORADDRESSBAR = 0x8007c001, // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
			SIGDN_PARENTRELATIVE = 0x80080001 // SHGDN_INFOLDER
		}

		#endregion

		#region STATFLAG enum

		public enum STATFLAG
			: uint {
			STATFLAG_DEFAULT = 0,
			STATFLAG_NONAME = 1,
			STATFLAG_NOOPEN = 2
			}

		#endregion

		#region STGC enum

		[Flags]
		public enum STGC
			: uint {
			STGC_DEFAULT = 0,
			STGC_OVERWRITE = 1,
			STGC_ONLYIFCURRENT = 2,
			STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,
			STGC_CONSOLIDATE = 8
			}

		#endregion

		#region STGTY enum

		public enum STGTY
			: uint {
			STGTY_STORAGE = 1,
			STGTY_STREAM = 2,
			STGTY_LOCKBYTES = 3,
			STGTY_PROPERTY = 4
			}

		#endregion

		#region TOKEN_TYPE enum

		public enum TOKEN_TYPE {
			TokenPrimary = 1,
			TokenImpersonation = 2
		}

		#endregion

		public const uint TOKEN_ASSIGN_PRIMARY = 0x0001;
		public const uint TOKEN_DUPLICATE = 0x0002;
		public const uint TOKEN_IMPERSONATE = 0x0004;
		public const uint TOKEN_QUERY = 0x0008;
		public const uint TOKEN_QUERY_SOURCE = 0x0010;
		public const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
		public const uint TOKEN_ADJUST_GROUPS = 0x0040;
		public const uint TOKEN_ADJUST_DEFAULT = 0x0080;
		public const uint TOKEN_ADJUST_SESSIONID = 0x0100;

		public const uint TOKEN_ALL_ACCESS_P =
			STANDARD_RIGHTS_REQUIRED |
			TOKEN_ASSIGN_PRIMARY |
			TOKEN_DUPLICATE |
			TOKEN_IMPERSONATE |
			TOKEN_QUERY |
			TOKEN_QUERY_SOURCE |
			TOKEN_ADJUST_PRIVILEGES |
			TOKEN_ADJUST_GROUPS |
			TOKEN_ADJUST_DEFAULT;

		public const uint TOKEN_ALL_ACCESS = TOKEN_ALL_ACCESS_P | TOKEN_ADJUST_SESSIONID;
		public const uint TOKEN_READ = STANDARD_RIGHTS_READ | TOKEN_QUERY;

		public const uint TOKEN_WRITE =
			STANDARD_RIGHTS_WRITE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT;

		public const uint TOKEN_EXECUTE = STANDARD_RIGHTS_EXECUTE;

		public const uint MAXIMUM_ALLOWED = 0x02000000;

		public const uint PROCESS_TERMINATE = 0x0001;
		public const uint PROCESS_CREATE_THREAD = 0x0002;
		public const uint PROCESS_SET_SESSIONID = 0x0004;
		public const uint PROCESS_VM_OPERATION = 0x0008;
		public const uint PROCESS_VM_READ = 0x0010;
		public const uint PROCESS_VM_WRITE = 0x0020;
		public const uint PROCESS_DUP_HANDLE = 0x0040;
		public const uint PROCESS_CREATE_PROCESS = 0x0080;
		public const uint PROCESS_SET_QUOTA = 0x0100;
		public const uint PROCESS_SET_INFORMATION = 0x0200;
		public const uint PROCESS_QUERY_INFORMATION = 0x0400;
		public const uint PROCESS_SUSPEND_RESUME = 0x0800;
		public const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
		public const uint PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFFF;

		public const uint PF_NX_ENABLED = 12;
		public const uint PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
		public const uint PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
		public const uint PF_SSE3_INSTRUCTIONS_AVAILABLE = 13;

		public const uint CF_ENHMETAFILE = 14;

		public const string IID_IOleWindow = "00000114-0000-0000-C000-000000000046";
		public const string IID_IModalWindow = "b4db1657-70d7-485e-8e3e-6fcb5a5c1802";
		public const string IID_IFileDialog = "42f85136-db7e-439c-85f1-e4075d135fc8";
		public const string IID_IFileOpenDialog = "d57c7288-d4ad-4768-be02-9d969532d960";
		public const string IID_IFileSaveDialog = "84bccd23-5fde-4cdb-aea4-af64b83d78ab";
		public const string IID_IFileDialogEvents = "973510DB-7D7F-452B-8975-74A85828D354";
		public const string IID_IFileDialogControlEvents = "36116642-D713-4b97-9B83-7484A9D00433";
		public const string IID_IFileDialogCustomize = "8016b7b3-3d49-4504-a0aa-2a37494e606f";
		public const string IID_IShellItem = "43826D1E-E718-42EE-BC55-A1E261C37BFE";
		public const string IID_IShellItemArray = "B63EA76D-1F85-456F-A19C-48159EFA858B";
		public const string IID_IKnownFolder = "38521333-6A87-46A7-AE10-0F16706816C3";
		public const string IID_IKnownFolderManager = "44BEAAEC-24F4-4E90-B3F0-23D258FBB146";
		public const string IID_IPropertyStore = "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99";

		public const string IID_ISequentialStream = "0c733a30-2a1c-11ce-ade5-00aa0044773d";
		public const string IID_IStream = "0000000C-0000-0000-C000-000000000046";

		public const string IID_IFileOperation = "947aab5f-0a5c-4c13-b4d6-4bf7836fc9f8";
		public const string IID_IFileOperationProgressSink = "04b0f1a7-9490-44bc-96e1-4296a31252e2";

		public const string CLSID_FileOpenDialog = "DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7";
		public const string CLSID_FileSaveDialog = "C0B4E2F3-BA21-4773-8DBA-335EC946EB8B";
		public const string CLSID_KnownFolderManager = "4df0c730-df9d-4ae3-9153-aa6b82e9795a";
		public const string CLSID_FileOperation = "3ad05575-8857-4850-9277-11b85bdb8e09";

		public const uint DROPEFFECT_COPY = 1;
		public const uint DROPEFFECT_MOVE = 2;
		public const uint DROPEFFECT_LINK = 4;

		public const int ERROR_SUCCESS = 0;
		public const int ERROR_ALREADY_EXISTS = 183;
		public const int ERROR_CANCELLED = 1223;
		public const int ERROR_IO_PENDING = 0x3e5;
		public const int ERROR_NO_MORE_ITEMS = 259;
		public const int ERROR_TIMEOUT = 1460;

		public const int WM_USER = 0x400;

		public const uint WTD_UI_ALL = 1;
		public const uint WTD_UI_NONE = 2;
		public const uint WTD_UI_NOBAD = 3;
		public const uint WTD_UI_NOGOOD = 4;

		public const uint WTD_REVOKE_NONE = 0;
		public const uint WTD_REVOKE_WHOLECHAIN = 1;

		public const uint WTD_CHOICE_FILE = 1;
		public const uint WTD_CHOICE_CATALOG = 2;
		public const uint WTD_CHOICE_BLOB = 3;
		public const uint WTD_CHOICE_SIGNER = 4;
		public const uint WTD_CHOICE_CERT = 5;

		public const uint WTD_STATEACTION_IGNORE = 0;
		public const uint WTD_STATEACTION_VERIFY = 1;
		public const uint WTD_STATEACTION_CLOSE = 2;
		public const uint WTD_STATEACTION_AUTO_CACHE = 3;
		public const uint WTD_STATEACTION_AUTO_CACHE_FLUSH = 4;

		public const uint WTD_PROV_FLAGS_MASK = 0x0000FFFF;
		public const uint WTD_USE_IE4_TRUST_FLAG = 0x00000001;
		public const uint WTD_NO_IE4_CHAIN_FLAG = 0x00000002;
		public const uint WTD_NO_POLICY_USAGE_FLAG = 0x00000004;
		public const uint WTD_REVOCATION_CHECK_NONE = 0x00000010;
		public const uint WTD_REVOCATION_CHECK_END_CERT = 0x00000020;
		public const uint WTD_REVOCATION_CHECK_CHAIN = 0x00000040;
		public const uint WTD_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT = 0x00000080;
		public const uint WTD_SAFER_FLAG = 0x00000100;
		public const uint WTD_HASH_ONLY_FLAG = 0x00000200;
		public const uint WTD_USE_DEFAULT_OSVER_CHECK = 0x00000400;
		public const uint WTD_LIFETIME_SIGNING_FLAG = 0x00000800;
		public const uint WTD_CACHE_ONLY_URL_RETRIEVAL = 0x00001000;

		public const uint FILE_SHARE_READ = 0x00000001;
		public const uint FILE_SHARE_WRITE = 0x00000002;
		public const uint FILE_SHARE_DELETE = 0x00000004;

		public const uint FILE_READ_DATA = 0x0001;
		public const uint FILE_LIST_DIRECTORY = 0x0001;
		public const uint FILE_WRITE_DATA = 0x0002;
		public const uint FILE_ADD_FILE = 0x0002;
		public const uint FILE_APPEND_DATA = 0x0004;
		public const uint FILE_ADD_SUBDIRECTORY = 0x0004;
		public const uint FILE_CREATE_PIPE_INSTANCE = 0x0004;

		public const uint FILE_READ_EA = 0x0008;
		public const uint FILE_WRITE_EA = 0x0010;
		public const uint FILE_EXECUTE = 0x0020;
		public const uint FILE_TRAVERSE = 0x0020;
		public const uint FILE_DELETE_CHILD = 0x0040;
		public const uint FILE_READ_ATTRIBUTES = 0x0080;
		public const uint FILE_WRITE_ATTRIBUTES = 0x0100;
		public const uint FILE_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x1FF);

		public const uint FILE_GENERIC_READ =
			(STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE);

		public const uint FILE_GENERIC_WRITE =
			(STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE);

		public const uint FILE_GENERIC_EXECUTE = (STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE);

		public const uint READ_CONTROL = 0x00020000;
		public const uint SYNCHRONIZE = 0x00100000;
		public const uint STANDARD_RIGHTS_READ = READ_CONTROL;
		public const uint STANDARD_RIGHTS_WRITE = READ_CONTROL;
		public const uint STANDARD_RIGHTS_EXECUTE = READ_CONTROL;
		public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;

		public static Guid BHID_Stream {
			get { return new Guid(0x1cebb3ab, 0x7c10, 0x499a, 0xa4, 0x17, 0x92, 0xca, 0x16, 0xc4, 0xcb, 0x83); }
		}

		public static Guid WINTRUST_ACTION_GENERIC_VERIFY_V2 {
			get { return new Guid(0xaac56b, 0xcd44, 0x11d0, 0x8c, 0xc2, 0x0, 0xc0, 0x4f, 0xc2, 0x95, 0xee); }
		}
	}
}