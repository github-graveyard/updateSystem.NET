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
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal partial class settingPage : basePage {

		private const int vertScrollbarWidthAddition = 20;

		public settingPage() {
			InitializeComponent();
			Id = Guid.NewGuid().ToString();
			pageSymbol = Core.resourceHelper.getImage("settings.png");
			displayOrder = 200;
		}

		/// <summary>Lädt alle Einstellungsblöcke für das Updateprojekt.</summary>
		private void initializeContentSubPages() {

			var settingSubBasePages = new SortedList<int, settingSubPages.settingSubBasePage>();
			flpSettings.Controls.Clear();
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {

				if (type.BaseType == null || type.BaseType != typeof (settingSubPages.settingSubBasePage))
					continue;

				var instance = (settingSubPages.settingSubBasePage) Activator.CreateInstance(type);
				instance.Session = Session;
				instance.initializeData();
				settingSubBasePages.Add(instance.displayOrder, instance);
			}

			//Einstellungsblöcke hinzufügen
			foreach (var kv in settingSubBasePages) {
				var settingsGroup = new groupBoxEx {
													Name = kv.Value.Name,
				                                   	Size = kv.Value.Size,
				                                   	Width = flpSettings.Width - (SystemInformation.VerticalScrollBarWidth + vertScrollbarWidthAddition),
				                                   	Text = kv.Value.Title
				                                   };
				kv.Value.Location = new Point(12,18);
				kv.Value.Width = settingsGroup.ClientSize.Width - 12;
				kv.Value.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
				settingsGroup.Height = kv.Value.Height + 18;
				settingsGroup.Controls.Add(kv.Value);
				flpSettings.Controls.Add(settingsGroup);
			}

		}

		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged(e);

			if (flpSettings != null)
				foreach (Control control in flpSettings.Controls)
					control.Width = flpSettings.Width - (SystemInformation.VerticalScrollBarWidth + vertScrollbarWidthAddition);

		}

		public override void initializeData() {
			initializeContentSubPages();
		}

	}
}
