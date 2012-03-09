#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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
			                                        	Name = "Neue Veröffentlichungsschnittstelle"
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

				_availableProvider.Add(
					type,
					(publishProviderDescriptionAttribute) descriptionAttributes[0]);
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
