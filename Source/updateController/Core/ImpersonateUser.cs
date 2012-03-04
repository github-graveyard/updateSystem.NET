//using System;
//using System.Runtime.InteropServices;
//using System.Security.Permissions;
//using System.Security.Principal;

//namespace updateSystemDotNet.Core
//{
//    /// <summary>
//    /// Klasse welche Funktionen zur Impersonifikation bereitstellt
//    /// </summary>
//    internal class ImpersonateUser
//    {
//        [DllImport("advapi32.dll", SetLastError = true)]
//        private static extern bool LogonUser(
//            String lpszUsername,
//            String lpszDomain,
//            String lpszPassword,
//            int dwLogonType,
//            int dwLogonProvider,
//            ref IntPtr phToken);

//        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
//        private extern static bool CloseHandle(IntPtr handle);

//        private static IntPtr tokenHandle = new IntPtr(0);
//        private static WindowsImpersonationContext impersonatedUser;

//        /// <summary>
//        /// Ändert temporär den Benutzer welcher den Prozess ausführt
//        /// </summary>
//        /// <param name="domainName">Der Name der Domain</param>
//        /// <param name="userName">Der Benutzername</param>
//        /// <param name="password">Das Passwort</param>
//        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
//        public void Impersonate(string domainName, string userName, string password)
//        {
//            try
//            {

//                // Use the unmanaged LogonUser function to get the user token for
//                // the specified user, domain, and password.
//                const int LOGON32_PROVIDER_DEFAULT = 0;
//                // Passing this parameter causes LogonUser to create a primary token.
//                const int LOGON32_LOGON_INTERACTIVE = 2;
//                tokenHandle = IntPtr.Zero;

//                // ---- Step - 1
//                // Call LogonUser to obtain a handle to an access token.
//                bool returnValue = LogonUser(
//                    userName,
//                    domainName,
//                    password,
//                    LOGON32_LOGON_INTERACTIVE,
//                    LOGON32_PROVIDER_DEFAULT,
//                    ref tokenHandle);         // tokenHandle - new security token

//                if (false == returnValue)
//                {
//                    int ret = Marshal.GetLastWin32Error();
//                    Console.WriteLine("LogonUser call failed with error code : " +
//                        ret);
//                    throw new System.ComponentModel.Win32Exception(ret);
//                }

//                // ---- Step - 2
//                WindowsIdentity newId = new WindowsIdentity(tokenHandle);

//                // ---- Step - 3
//                impersonatedUser = newId.Impersonate();

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Exception occurred. " + ex.Message);
//            }
//        }

//        // Stops impersonation
//        /// <summary>
//        /// Macht die Impersonifizierung rückgängig.
//        /// </summary>
//        public void Undo()
//        {
//            impersonatedUser.Undo();
//            // Free the tokens.
//            if (tokenHandle != IntPtr.Zero)
//                CloseHandle(tokenHandle);
//        }
//    }
//}

