﻿/**
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
namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	internal partial class sspGeneral : settingSubBasePage {
		public sspGeneral() {
			InitializeComponent();
		}
		public override void initializeData() {
			chkNativeImage.Checked = Session.currentProject.generateNativeImages;
			chkServicePackIsDefault.Checked = Session.currentProject.setServicePackAsDefault;
		}
		private void chkNativeImage_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.generateNativeImages = chkNativeImage.Checked;
		}

		private void chkServicePackIsDefault_CheckedChanged(object sender, System.EventArgs e) {
			Session.currentProject.setServicePackAsDefault = chkServicePackIsDefault.Checked;
		}
	}
}
