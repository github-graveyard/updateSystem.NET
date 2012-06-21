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
using System.ComponentModel;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Core.updateActions;
using System.Drawing;
using updateSystemDotNet.Administration.Core.Application;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	[ToolboxItem(false)]
	internal partial class actionEditorBase : UserControl {
		public actionEditorBase() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		#region " Updateaktion "

		/// <summary>Returns the instance from the current action.</summary>
		public actionBase updateAction { get; set; }

		public applicationSession Session { get; set; }

		/// <summary>Initializes the content of the actioneditor.</summary>
		public virtual void initializeActionContent() {
		}

		/// <summary>Performs basic localization of ui-elements.</summary>
		public virtual void initializeLocalization() {
			Session.localizeControl(this);
		}

		#endregion
	}
}