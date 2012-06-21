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
using System.Diagnostics;
using System.Drawing.Design;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.UI.Controls {
	[redirectDefaultLocalization(propertyName = "linkText")]
	internal sealed class linkLabelEx : LinkLabel {

		private string _originalText;
		private readonly Regex _urlEx;

		public linkLabelEx() {
			_urlEx = new Regex(@"\[url=([^\]]+)\]([^\]]+)\[\/url\]");
			base.Text = "LinkLabelEx";
			LinkArea = new LinkArea(0, 0);
			autoOpenLinks = true;
		}

		//Hide Properties which are now only internal available
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text {
			get {
				return base.Text;
			}
			set {
				base.Text = value;
			}
		}
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new LinkArea LinkArea {
			get;
			set;
		}

		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Category("Appearance")]
		[Description("The Text associated with the Control.")]
		[Bindable(true)]
		[DefaultValue("")]
		public string linkText {
			get { return _originalText; }
			set {
				_originalText = value;
				if(!string.IsNullOrEmpty(value))
					parseText();
			}
		}

		[Category("Behavior")]
		[Description("Auto open Links with the default Browser")]
		[DefaultValue(false)]
		public bool autoOpenLinks {
			get;
			set;
		}

		private void parseText() {
			MatchCollection matches = _urlEx.Matches(_originalText);
			Text = _originalText;
			Links.Clear();
			foreach (Match match in matches) {

				if (match.Groups.Count < 3)
					continue;

				string link = match.Groups[1].Value;
				string linkText = match.Groups[2].Value;

				Text = Text.Replace(match.Value, match.Groups[2].Value);

				int linkIndex = Text.IndexOf(linkText, System.StringComparison.Ordinal);
				if (linkIndex == -1)
					continue;

				Links.Add(linkIndex, linkText.Length, link);
			}

		}

		protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e) {
			base.OnLinkClicked(e);

			if (autoOpenLinks && !string.IsNullOrEmpty((string)e.Link.LinkData)) {
				Process.Start((string)e.Link.LinkData);
			}

		}

	}
}