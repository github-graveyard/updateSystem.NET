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
using System.Threading;
using System.Windows.Forms;

namespace updateSystemDotNet.Administration.Core.Application {
	internal sealed partial class applicationSession {

		private const string LOCALIZATION_FILE_PATH = "updateSystemDotNet.Administration.Administration";
		private const string LOCALIZATION_NOT_FOUND = "TRANSLATION FOR {0} NOT FOUND!";
		private const string SECTION_NAME_DIALOGS = "Dialogs";
		internal const string SECTION_NAME_PAGES = "Pages";
		private const string SECTION_NAME_MENUS = "Menus";
		private const string SECTION_NAME_MESSAGES = "Messages";
		private const string DEFAULT_LOCALIZATION_PROPERTY_NAME = "Text";
		
		private string _currentCulture;
		private string _dialogTitleAppendix;
		private List<Type> _localizableControls;

		/// <summary>Gets direct access to the Localizationfile. For Translation use getLocalizedString(key) instead.</summary>
		public Localization.localizationFile localizationFile { get; private set; }

		private void initializeLocalization() {
			localizationFile.Load(LOCALIZATION_FILE_PATH);
			_currentCulture = Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2);
			_dialogTitleAppendix = applicationName;
			_localizableControls = new List<Type>(new[] {
			                                            	typeof (Button),
			                                            	typeof (CheckBox),
			                                            	typeof (RadioButton),
			                                            	typeof (Label),
			                                            	typeof (GroupBox)
			                                            });
		}

		/// <summary>Returns a localized String based on the selected Language.</summary>
		public string getLocalizedString(string key) {
			return getLocalizedString(key, _currentCulture, false);
		}

		/// <summary>Returns a localized String based on the selected Language.</summary>
		/// <param name="key">The Key in the Localizationfile</param>
		/// <param name="returnEmptyString">If true this Method will return an empty string if the key not exists.</param>
		public string getLocalizedString(string key, bool returnEmptyString) {
			return getLocalizedString(key, _currentCulture, returnEmptyString);
		}

		/// <summary>Returns a localized String based on the language specified in <param name="language">language</param></summary>
		/// <param name="key">The Key in the Localizationfile</param>
		/// <param name="language">The Culture-Id</param>
		/// <param name="returnEmptyString">If true this Method will return an empty string if the key not exists.</param>
		public string getLocalizedString(string key, string language, bool returnEmptyString) {
			var localizedString = localizationFile[key, language];
			if (returnEmptyString)
				return localizedString;
			
			return string.IsNullOrEmpty(localizedString) ? string.Format(LOCALIZATION_NOT_FOUND, key) : localizedString;
		}
		/// <summary>Returns a localized String for a specific Control</summary>
		public string getLocalizedString(Control control) {
			var parent = getParent(control);
			return getLocalizedString(string.Format("{0}.{1}.{2}.Text",
			                                        derivesFrom<Form>(parent.GetType())
			                                        	? SECTION_NAME_DIALOGS
			                                        	: SECTION_NAME_PAGES,
			                                        parent.Name,
			                                        control.Name));
		}

		public void localizeForm(Form form) {
			form.Text = string.Format("{0} - {1}",
			                          getLocalizedString(string.Format("{0}.{1}.Title", SECTION_NAME_DIALOGS, form.Name), _currentCulture, false),
			                          _dialogTitleAppendix);
			localizeControls(form.Controls);
		}
		public void localizeControls(Control.ControlCollection controls) {
			foreach(Control control in controls)
				localizeControl(control);
		}
		public void localizeControl(Control control) {
			//Check if the Control is localizable
			if (isLocalizable(control)) {

				//Determine ParentControl (Form/Usercontrol/WhatEver)
				Control parentContainer = getParent(control);

				if (parentContainer == null)
					throw new InvalidOperationException("Could not determine Parent which is required for Localization.");

				string localizedText = localizationFile[string.Format("{0}.{1}.{2}.Text",
				                                                      derivesFrom<Form>(parentContainer.GetType())
				                                                      	? SECTION_NAME_DIALOGS
				                                                      	: SECTION_NAME_PAGES,
				                                                      parentContainer.Name,
				                                                      control.Name)];

				//If there is no direct Localization available, try to find a global localization
				if (string.IsNullOrEmpty(localizedText))
					localizedText = localizationFile[string.Format("Dialogs.Global.{0}.Text", control.Name)];

				string defaultLocalizationProperty = getDefaultLocalizationProperty(control);
				localizedText = string.IsNullOrEmpty(localizedText)
				                	? string.Format(LOCALIZATION_NOT_FOUND, control.Name)
				                	: localizedText;

				if (defaultLocalizationProperty == DEFAULT_LOCALIZATION_PROPERTY_NAME)
					control.Text = localizedText;
				else
					control.GetType().GetProperty(defaultLocalizationProperty).SetValue(control, localizedText, null);
			}
			//Localize Childcontrols
			if (control.Controls.Count > 0)
				localizeControls(control.Controls);
		}

		public void localizeMenuStrip(ToolStrip menu) {
			foreach (ToolStripItem item in menu.Items)
				localizeMenuItem(item, menu.Name);
		}
		private void localizeMenuItem(ToolStripItem item, string menuName) {
			item.Text =
				localizationFile[string.Format("{0}.{1}.{2}.Text", SECTION_NAME_MENUS, menuName, item.Name), _currentCulture];
			if(item is ToolStripMenuItem)
				foreach(ToolStripItem subitem in (item as ToolStripMenuItem).DropDownItems)
					localizeMenuItem(subitem, menuName);
		}

		public string localizeMessage(string key) {
			return localizeMessage(key, null);
		}
		public string localizeMessage(string key, Control parent) {
			return localizationFile[string.Format("{0}.{1}.{2}",
			                                      SECTION_NAME_MESSAGES,
			                                      parent == null ? "Global" : parent.Name,
			                                      key), _currentCulture];
		}

		private bool isLocalizable(Control control) {
			for (Type ctrlType = control.GetType(); ctrlType != null; ctrlType = ctrlType.BaseType)
				if (_localizableControls.Contains(ctrlType))
					return true;

			return false;
		}

		private Control getParent(Control control) {
			Control parentContainer = null;
			for (Control parent = control.Parent; (parent != null); parent = parent.Parent) {
				parentContainer = parent;

				/*
				 This tweak is required when localizing-methods are called after the Control
				 is added to the mainform because the parent will then always be the mainform not the page.
				 */
				if(derivesFrom<UI.mainFormPages.basePage>(parentContainer.GetType()))
					return parentContainer;
			}
			return parentContainer;
		}

		private string getDefaultLocalizationProperty(Control control) {
			object[] attributes = control.GetType().GetCustomAttributes(typeof (redirectDefaultLocalizationAttribute), true);
			return attributes.Length > 0
			       	? (attributes[0] as redirectDefaultLocalizationAttribute).propertyName
			       	: DEFAULT_LOCALIZATION_PROPERTY_NAME;
		}

	}
}