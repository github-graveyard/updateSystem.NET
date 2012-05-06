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
using System.Reflection;
using updateSystemDotNet.Administration.Core.Application;
using System.Collections.Generic;

namespace updateSystemDotNet.Administration.Core.Publishing {

	/// <summary>Factoryklasse zum Erstellen und Verwalten der unterschiedlichen Factoryprovider.</summary>
	internal sealed class publishFactory {
		private readonly applicationSession _session;
		private Dictionary<Type, publishProviderDescriptionAttribute> _availableProvider;       

		/// <summary>Initialisiert eine neue Instanz der PublishFactory.</summary>
		public publishFactory(applicationSession session) {
			_session = session;
		}

		/// <summary>Gibt anhand der gespeicherten Settings den passenden Provider zurück.</summary>
		public IPublishProvider publishProviderBySettings(publishSettings settings) {
			if (settings == null)
				throw new ArgumentException("settings");

			foreach(var type in Assembly.GetExecutingAssembly().GetTypes()) {
				
				//Alle Typen die nicht von publishBase erben ignorieren
				if(type.BaseType != typeof(publishBase))
					continue;

				var instance = (IPublishProvider)Activator.CreateInstance(type);
				if(instance.Id == settings.parentId) {
					//Passenden Provider gefunden, notwendige Eigenschaften Setzen und Instanz zurückgeben.
					instance.Session = _session;
					instance.Settings = settings;
					return instance;
				}
			}
			throw new publishFactoryException(string.Format("Für die ID {0} konnte kein publishProvider ermittelt werden.",
			                                                settings.parentId));
		}

		/// <summary>Erstellt aus einem publishType eine neue Instanz</summary>
		public IPublishProvider publishProviderByType(Type t) {
			var instance = (IPublishProvider)Activator.CreateInstance(t);
			instance.Session = _session;
			instance.Settings = new publishSettings {
			                                        	Id = Guid.NewGuid().ToString(),
			                                        	parentId = instance.Id,
			                                        	Name = "New Publishinterface"
			                                        };
			return instance;
		}

		private void loadProvider() {
			_availableProvider = new Dictionary<Type, publishProviderDescriptionAttribute>();
			foreach(var type in Assembly.GetExecutingAssembly().GetTypes()) {
				
				if(type.BaseType != typeof(publishBase))
					continue;

				var descriptionAttributes = type.GetCustomAttributes(typeof (publishProviderDescriptionAttribute), true);
				if (descriptionAttributes.Length == 0)
					continue;

				var providerDescription = (descriptionAttributes[0] as publishProviderDescriptionAttribute);
				providerDescription.Name = _session.getLocalizedString(providerDescription.Name);
				providerDescription.Description = _session.getLocalizedString(providerDescription.Description);

				_availableProvider.Add(
					type,
					providerDescription);
			}
		}

		public Dictionary<Type, publishProviderDescriptionAttribute> availableProvider {
			get {
				if (_availableProvider == null)
					loadProvider();
				return _availableProvider;
			}
		}

	}

}
