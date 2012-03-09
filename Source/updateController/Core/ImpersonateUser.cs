/*
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

