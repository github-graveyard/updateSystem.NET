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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace updateSystemDotNet.Internal.Designer {
	internal class largeTextEditor : UITypeEditor {
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
			var control = new TextBox();
			control.Multiline = true;
			control.Size = new Size(300, 100);
			control.ScrollBars = ScrollBars.Vertical;
			control.WordWrap = true;
			control.BorderStyle = BorderStyle.None;
			control.Text = (string) value;

			var service = (IWindowsFormsEditorService) context.GetService(typeof (IWindowsFormsEditorService));
			if (service != null) {
				service.DropDownControl(control);
			}

			return control.Text;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
			return UITypeEditorEditStyle.DropDown;
		}
	}
}