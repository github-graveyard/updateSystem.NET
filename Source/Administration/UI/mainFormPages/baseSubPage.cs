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
namespace updateSystemDotNet.Administration.UI.mainFormPages {
	internal class baseSubPage : basePage {

		/// <summary>Ein Argument mit spezifischen Daten welches der Page mitgegeben wird.</summary>
		public object Argument { get; set; }

		/// <summary>Die Page von welcher diese Angezeigt wird.</summary>
		public basePage parentPage { get; set; }

		public override bool hideFromNavigation {
			get { return true; }
		}

		public override System.Windows.Forms.TreeNode Node {
			get {
				base.Node.ImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.SelectedImageKey = (pageSymbol == null ? parentPage.Id : Id);
				base.Node.Tag = this;
				return base.Node;
			}
		}

	}
}