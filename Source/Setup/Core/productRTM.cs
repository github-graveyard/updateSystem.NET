/**
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
using System.Reflection;

namespace updateSystemDotNet.Setup.Core {
	internal class productRTM : IProduct {
		#region IProduct Members

		public string mainExecutable {
			get { return "updateSystemDotNet.Administration.exe"; }
		}

		public string setupName {
			get { return "uninstall.exe"; }
		}

		public string Contact {
			get { return "mail@maximiliankrauss.net"; }
		}

		public virtual Version currentVersion {
			get {
				if (ProgramsAndFeaturesHelper.isInstalled(this))
					return ProgramsAndFeaturesHelper.getCurrentVersion(this);
				else
					return newVersion;
			}
		}

		public string Description {
			get { return "Updatelösung für .NET Entwickler"; }
		}

		public virtual Version newVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version; }
		}

		public virtual string Product {
			get { return "updateSystem.NET"; }
		}

		public string Publisher {
			get { return "Maximilian Krauss"; }
		}

		public virtual string supportUrl {
			get { return "http://updatesystem.net"; }
		}

		public virtual string applicationID {
			get { return "8d7ea403-65fb-4276-8ada-3b39f0fe2461"; }
		}

		#endregion
	}
}