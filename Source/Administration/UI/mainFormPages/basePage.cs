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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	
	[ToolboxItem(false)]
	internal class basePage : UserControl {

		#region Events

		#endregion

		#region Private Fields

		private TreeNode _node;
		private Controls.mainInstructionsLabel _lblTitle;

		#endregion

		public basePage() {
			base.Font = SystemFonts.MessageBoxFont;
			toolStripButtons = new List<ToolStripItem>();
			initializeComponents();
		}

		private void initializeComponents() {
			_lblTitle = new mainInstructionsLabel() {
			                      	Location = new Point(0, 0),
			                      	Text = "#no title set#"
			                      };
			Controls.Add(_lblTitle);
			_lblTitle.AutoSize = true;
			subPages = new List<baseSubPage>();
		}

		#region Properties

		/// <summary>Gibt die aktuelle Anwendungssession zurück oder legt diese fest.</summary>
		public applicationSession Session { get; set; }

		/// <summary>Gibt das Symbolzurück welches im TreeView angezeigt werden soll oder legt dieses fest.</summary>
		public Image pageSymbol { get; protected set; }

		/// <summary>Gibt den Namen zurück der im TreeView für diese Seite angezeigt werden soll oder legt diesen fest.</summary>
		public string pageName { get; set; }

		/// <summary>Gibt eine GUID zurück welche die Page eindeutig identifiziert oder legt diese fest.</summary>
		public string Id { get; protected set; }

		/// <summary>Gibt die Seite zurück die angezeigt werden soll, wenn <see cref="canShowPage"/> False zurück gibt.</summary>
		public basePage fallbackPage { get; protected set; }

		/// <summary>Gibt die Anzeigereihenfolge wieder oder legt diese fest.</summary>
		public int displayOrder { get; protected set; }

		/// <summary>Gibt den Titel zurück der auf der Seite angezeigt werden soll.</summary>
		public string Title { get { return _lblTitle.Text; } set { _lblTitle.Text = value; } }

		/// <summary>Gibt zurück ob die Seite in der Navigation verborgen werden soll.</summary>
		public virtual bool hideFromNavigation { get { return false; } }

		//ToolStrip
		/// <summary>Gibt an oder legt fest, ob diese Seite den ToolStrip der Hauptseite erweitert.</summary>
		public bool extendsToolStrip { get; set; }

		/// <summary>Gibt eine Auflistung mit Toolstrip-Buttons zurück die in die Toolbar der Hauptform eingefügt werden sollen.</summary>
		public List<ToolStripItem> toolStripButtons { get; protected set; }

		/// <summary>Gibt den Node zurück um die Seite im TreeView der Hauptnavigation darstellen zu können.</summary>
		public virtual TreeNode Node {
			get {
				return _node ?? (_node = new TreeNode {
				                                      	Text =
				                                      		Session.getLocalizedString(string.Format("{0}.{1}.nodeName.Text",
				                                      		                                         applicationSession.SECTION_NAME_PAGES, Name)),
				                                      	ImageKey = Id,
				                                      	SelectedImageKey = Id,
				                                      	Tag = GetType()
				                                      });
			}
		}

		protected List<baseSubPage> subPages { get; set; }

		#endregion

		#region Virtual Methods

		/// <summary>Indicates if that Page should display in the Main-TreeView.</summary>
		/// <returns>Returns true if the Page should display, otherwise false.</returns>
		public virtual bool canShowPage() {
			return true;
		}

		/// <summary>Initializes all the Content on this Page.</summary>
		/// <remarks>You can use the Session-Object, at this Point it is already assigned to the Session-Property.</remarks>
		public virtual void initializeData() {
		}

		/// <summary>Initializes Subpages, if there are any..</summary>
		public virtual void initializeSubPages() {
		}

		/// <summary>Initializes additional Buttons that should display in the Toolbar of MainForm.</summary>
		protected virtual void initializeToolStripButtons() {
		}

		/// <summary>Performs basic Localization and can be overwritten to localize specific Controls</summary>
		public virtual void initializeLocalization() {
			Session.localizeControl(this);
		}

		#endregion

		#region Public Methods

		// still to come...

		#endregion

		#region Protected Methods

		/// <summary>Erstellt eine neue Subpage</summary>
		/// <param name="argument">Das der Subpage zu übergebende Argument.</param>
		/// <typeparam name="T">Der Type aus dem eine neue Subpage erstellt werden soll.</typeparam>
		protected T createSubPage<T>(object argument) where T : baseSubPage {
			var instance = Activator.CreateInstance<T>();
			instance.Session = Session;
			instance.Argument = argument;
			instance.parentPage = this;

			if (instance.pageSymbol != null && !Node.TreeView.ImageList.Images.ContainsKey(instance.Id)) {
				Node.TreeView.ImageList.Images.Add(instance.Id, instance.pageSymbol);
			}

			return instance;
		}

		/// <summary>Speichert die Breiten der Columnheader.</summary>
		protected void saveColumnHeaderSizes(ListView listView) {
			foreach(ColumnHeader header in listView.Columns) {
				if (string.IsNullOrEmpty(header.Text))
					throw new InvalidOperationException(string.Format("header.Text ist null (ListView: {0} Header-Index: {1}",
					                                                  listView.Name, header.Index));

				string headerKey = generateColumnHash(listView, header);
				if (Session.Settings.columnSizes.ContainsKey(headerKey))
					Session.Settings.columnSizes[headerKey] = header.Width;
				else
					Session.Settings.columnSizes.Add(headerKey, header.Width);
			}
		}

		/// <summary>Stellt die gespeicherten Breiten der ColumnHeader wieder her.</summary>
		protected void restoreColumnHeaderSizes(ListView listView) {
			foreach(ColumnHeader header in listView.Columns) {
				if (string.IsNullOrEmpty(header.Text))
					throw new InvalidOperationException(string.Format("header.Text ist null (ListView: {0} Header-Index: {1}",
					                                                  listView.Name, header.Index));

				string headerKey = generateColumnHash(listView, header);
				if (Session.Settings.columnSizes.ContainsKey(headerKey))
					header.Width = Session.Settings.columnSizes[headerKey];
			}
		}

		/// <summary>Erstellt einen neuen, vorkonfigurierten ToolStripButton.</summary>
		protected ToolStripButton createToolStripButton(string text) {
			return createToolStripButton(text, string.Empty);
		}

		/// <summary>Erstellt einen neuen, vorkonfigurierten ToolStripButton.</summary>
		protected ToolStripButton createToolStripButton(string text, string tooltip) {
			var tsBtn = new ToolStripButton(text) {
			                                      	DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
			                                      	AutoToolTip = (!string.IsNullOrEmpty(tooltip)),
			                                      	ToolTipText = tooltip,
			                                      	Tag = this
			                                      };
			toolStripButtons.Add(tsBtn);
			return tsBtn;
		}

		#endregion

		#region Private Methods

		private string generateColumnHash(ListView listView, ColumnHeader header) {
			return string.Format("{0}_{1}", listView.Name, header.Text);
		}

		#endregion

	}
}