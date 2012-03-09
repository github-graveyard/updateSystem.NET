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
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using ICSharpCode.SharpZipLib.BZip2;
using updateSystemDotNet.Administration.Core.Application;
using updateSystemDotNet.Administration.Core.Publishing;
using System.IO;
using updateSystemDotNet.Administration.UI.updateActionEditor;
using updateSystemDotNet.Core.Types;
using System.Resources;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.Core.Updates {

	/// <summary>Factory für Updates und Updateprojekte</summary>
	internal sealed class updateFactory {

		private readonly string[] _projectStructure;
		private readonly applicationSession _session;

		public updateFactory(applicationSession session) {
			_projectStructure = new[] {"Updates", "Templates"};
			_session = session;
		}

		/// <summary>Erstellt ein neues Updateprojekt.</summary>
		public updateProject createNewProject() {
			var project = new updateProject {
			                                  	projectName = "Neues Updateprojekt",
			                                  	keyPair = rsaKeyPair.Create(),
			                                  	projectId = Guid.NewGuid().ToString(),
			                                  	publishProviderSettings = new List<publishSettings>()
			                                  };
			return project;
		}

		/// <summary>Speichert ein Updateprojekt.</summary>
		/// <param name="projectPath">Das Pfad zur Projektdatei (nicht zum Verzeichnis)</param>
		/// <param name="project">Das zu speichernde Updateprojekt.</param>
		public void saveProject(string projectPath, updateProject project) {

			//Argumente prüfen
			if(string.IsNullOrEmpty(projectPath))
				throw new ArgumentException("projectPath");
			if(project == null)
				throw new ArgumentException("project");

			//Projektverzeichnis ermitteln
			var projectDirectory = new DirectoryInfo(Path.GetDirectoryName(projectPath));
			
			//Überprüfen ob das Projektverzeichnis existiert, wenn nicht erstellen
			if(!projectDirectory.Exists)
				projectDirectory.Create();

			//Projektstruktur erstellen/prüfen
			foreach (var directoryName in _projectStructure)
				if (!Directory.Exists(Path.Combine(projectDirectory.FullName, directoryName)))
					projectDirectory.CreateSubdirectory(directoryName);

			//Projektdatei speichern
			secureSerializer.Serialize(projectPath, project);

		}

		/// <summary>Öffnet ein gespeichertes Updateprojekt.</summary>
		/// <param name="projectPath">Der Pfad zur Projektdatei (nicht zum Verzeichnis)</param>
		public updateProject loadProject(string projectPath) {
			
			//Argument prüfen
			if(string.IsNullOrEmpty(projectPath))
				throw new ArgumentException("projectPath");

			//Projektdatei laden
			var project = secureSerializer.Deserialize<updateProject>(projectPath);
			
			//Anhand der Einstellungen die PublishProvider initialisieren
			foreach(var pblSettings in project.publishProviderSettings)
				project.publishProvider.Add(_session.publishFactory.publishProviderBySettings(pblSettings));
			
			return project;
		}

		/// <summary>Verknüoft ein Updatepaket mit einer Veröffentlichungsschnittstelle.</summary>
		public void linkUpdate(updatePackage update, IPublishProvider provider) {

			//Bereits verlinkte Provider braucht man nicht nochmal verlinken
			if (isUpdateLinked(update, provider))
				return;

			if (!_session.currentProject.linkedPublishProvider.ContainsKey(update.ID))
				_session.currentProject.linkedPublishProvider.Add(update.ID, new List<string>(new[] {provider.Settings.Id}));
			else
				_session.currentProject.linkedPublishProvider[update.ID].Add(provider.Settings.Id);

		}

		/// <summary>Entfernt die Verknüpfung zwischen einem Update und einer Veröffentlichungsschnittstelle.</summary>
		public void unlinkUpdate(updatePackage update, IPublishProvider provider) {
			
			//Ist nicht verlinkt, also gibts auch nichts zum löschen
			if (!isUpdateLinked(update, provider))
				return;

			//Linkeintrag entfernen
			_session.currentProject.linkedPublishProvider[update.ID].Remove(provider.Settings.Id);

		}

		/// <summary>Überprüft ob ein Update mit einer Veröffentlichungsschnittstelle verknüpft ist.</summary>
		public bool isUpdateLinked(updatePackage update, IPublishProvider provider) {

			//Erstmal prüfen ob die LinkListe zum passenden Updatepaket nicht null ist.
			if (!_session.currentProject.linkedPublishProvider.ContainsKey(update.ID) ||
			    _session.currentProject.linkedPublishProvider[update.ID] == null)
				return false;

			//Und jetzt prüfen ob die ID des Providers schon in der LinkListe vorhanden ist.
			return _session.currentProject.linkedPublishProvider[update.ID].Contains(provider.Settings.Id);
		}

		/// <summary>Entfernt ein Updatepaket aus dem Projekt.</summary>
		public void removeUpdatePackage(updatePackage package) {
			
			//Updatepaket löschen
			string packagePath = Path.Combine(Path.Combine(Path.GetDirectoryName(_session.currentProjectPath), "Updates"),
			                                  package.getFilename());
			if(File.Exists(packagePath))
				File.Delete(packagePath);

			//Changelog löschen
			string changelogPath = Path.Combine(Path.Combine(Path.GetDirectoryName(_session.currentProjectPath), "Updates"),
			                                    package.getChangelogFilename());
			if(File.Exists(changelogPath))
				File.Delete(changelogPath);

			//Von allen Providern die Verknüpfung zu diesem Projekt entfernen
			foreach (var provider in _session.currentProject.publishProvider)
				unlinkUpdate(package, provider);

			//Paket aus dem Projekt werfen
			_session.currentProject.updatePackages.Remove(package);

		}

		#region Updatepackage

		public void buildUpdatePackage(updatePackage package, string changesDe, string changesEn) {

			//Argumente prüfen
			if (package == null)
				throw new ArgumentException("package");
			if (string.IsNullOrEmpty(changesDe) && string.IsNullOrEmpty(changesEn))
				throw new ArgumentException("changesDe und changesEn");

			//Prüfen ob das Projekt schon gespeichert wurde (notwendig!)
			if (string.IsNullOrEmpty(_session.currentProjectPath))
				throw new Exception("Das Projekt muss gespeichert werden bevor Updatepakete erstellt werden können.");

			//Lokales Basisverzeichnis für die Aktualisieren bestimmen.
			string updateDirectory = Path.Combine(Path.GetDirectoryName(_session.currentProjectPath), _projectStructure[0]);
			
			//Updatepaket für die Dateien erstellen
			using (var fsUpdatePackage = new FileStream(Path.Combine(updateDirectory, package.getFilename()), FileMode.Create)) {
				using (var writer = new ResourceWriter(fsUpdatePackage)) {

					//Jede Datei ins Paket schreiben und vorher komprimieren
					foreach (var fcAction in package.fileCopyActions)
						foreach (var fileData in fcAction.Files)
							if (File.Exists(fileData.Fullpath))
								writer.AddResourceData(fileData.ID, "fileCopyActionData", compressData(File.ReadAllBytes(fileData.Fullpath)));
					writer.Generate();
				}
			}

			//Paketgröße setzen
			package.packageSize = new FileInfo(Path.Combine(updateDirectory, package.getFilename())).Length;

			string packageHash =
				Convert.ToBase64String(
					SHA512.Create().ComputeHash(File.ReadAllBytes(Path.Combine(updateDirectory, package.getFilename()))));
			package.packageSignature = updateSystemDotNet.Core.RSA.Sign(packageHash, _session.currentProject.keyPair.privateKey);

			//Changelog erstellen und speichern
			XmlDocument xChangelog = createChangelogs(changesDe, changesEn);
			using(var xWriter = new StreamWriter(Path.Combine(updateDirectory,package.getChangelogFilename()), false,Encoding.UTF8)) {
				xChangelog.Save(xWriter);
			}
		}

		/// <summary>Komprimiert eine ByteArray Daten mit dem BZip2 Algorithmus aus dem SharpZipLib.</summary>
		/// <param name="inData">Das Bytearray mit Daten welches komprimiert werden soll.</param>
		/// <returns>Das komprimierte Bytearray.</returns>
		private byte[] compressData(byte[] inData) {
			using (var inStream = new MemoryStream(inData)) {
				using (var outStream = new MemoryStream()) {
					BZip2.Compress(inStream, outStream, 1024);
					return outStream.ToArray();
				}
			}
		}
		private byte[] decompressData(byte[] input) {
			using (var inStream = new MemoryStream(input)) {
				using (var outStream = new MemoryStream()) {
					BZip2.Decompress(inStream, outStream);
					return outStream.ToArray();
				}
			}
		}

		/// <summary>Erstellt ein XMLDocument im alten Format mit den Änderungen jeweils in Deutsch und in Englisch.</summary>
		private XmlDocument createChangelogs(string changelogDe, string changelogEn) {
			var document = new XmlDocument();

			//Dokumentenkopf erstellen
			document.AppendChild(document.CreateDocumentFragment());
			document.AppendChild(
				document.CreateComment(string.Format("Created with updateSystem.NET Version {0}",
													 Assembly.GetExecutingAssembly().GetName().Version)));
			document.AppendChild(
				document.CreateComment(string.Format("Copyright (c) 2007 - {0} Maximilian Krauss", DateTime.Now.Year)));

			XmlNode xRoot = document.CreateElement("updateSystemDotNet.Changelog");
			XmlNode xItems = document.CreateElement("Items");

			XmlNode germanChanges = document.CreateElement("Item");
			germanChanges.AppendChild(createTextElement(document, "Type", string.Empty));
			germanChanges.AppendChild(createTextElement(document, "Developer", string.Empty));
			germanChanges.AppendChild(createTextElement(document, "Language", "Deutsch"));
			germanChanges.AppendChild(createTextElement(document, "Change", changelogDe));
			xItems.AppendChild(germanChanges);

			XmlNode englishChanges = document.CreateElement("Item");
			englishChanges.AppendChild(createTextElement(document, "Type", string.Empty));
			englishChanges.AppendChild(createTextElement(document, "Developer", string.Empty));
			englishChanges.AppendChild(createTextElement(document, "Language", "English"));
			englishChanges.AppendChild(createTextElement(document, "Change", changelogEn));
			xItems.AppendChild(englishChanges);

			xRoot.AppendChild(xItems);
			document.AppendChild(xRoot);

			return document;
		}

		private XmlNode createTextElement(XmlDocument document, string name, string text) {
			XmlNode node = document.CreateElement(name);
			node.InnerText = text;
			return node;
		}

		public prepareEditPackageResult prepareEditUpdatePackage(updatePackage package) {

			var result = new prepareEditPackageResult();

			//Temporäres Verzeichnis für die Updatedaten erstellen
			string tempPackagePath = Path.Combine(Environment.GetEnvironmentVariable("tmp"), package.ID);
			result.tempPackagePath = tempPackagePath;
			result.updatePackage = package;

			if (!Directory.Exists(tempPackagePath))
				Directory.CreateDirectory(tempPackagePath);

			//Pfad zum Updatepaket ermitteln
			string packagePath = Path.Combine(Path.Combine(_session.currentProjectDirectory, "Updates"), package.getFilename());
			if (!File.Exists(packagePath))
				throw new FileNotFoundException("Das Updatepaket konnte nicht gefunden werden.", packagePath);

			//Updatepaket öffnen
			using(var fsPackage = File.OpenRead(packagePath)) {
				using(var packageReader = new ResourceReader(fsPackage)) {

					//Dateien entpacken und im Tempverzeichnis abspeichern
					foreach (var copyAction in package.fileCopyActions) {
						foreach (var file in copyAction.Files) {
							string newFilename = string.Format("{0}.{1}", file.ID, file.Filename);
							using(var fsFileOut = new FileStream(Path.Combine(tempPackagePath, newFilename), FileMode.Create)) {
								byte[] resourceData;
								string tempType; //ungenutzt aber trotzdem notwendig
								packageReader.GetResourceData(file.ID, out tempType, out resourceData);
								byte[] decompressedData = decompressData(resourceData);
								fsFileOut.Write(decompressedData, 0, decompressedData.Length);
							}

							//Neuen Dateinamen in Updatepaket übernehmen
							file.Fullpath = Path.Combine(tempPackagePath, newFilename);
						}
					}
				}
			}

			//Changelog lesen
			string changelogPath = Path.Combine(Path.Combine(_session.currentProjectDirectory, "Updates"),
			                                    package.getChangelogFilename());
			if(!File.Exists(changelogPath))
				throw new FileNotFoundException("Der Changelog konnte nicht gefunden werden", changelogPath);
			
			using(var fsChangelog = new StreamReader(changelogPath, Encoding.UTF8)) {
				var xmlChangelog = new XmlDocument();
				xmlChangelog.Load(fsChangelog);

				XmlNodeList changelogItems = xmlChangelog.SelectNodes("updateSystemDotNet.Changelog/Items/Item");
				if(changelogItems == null)
					throw new InvalidOperationException("Es konnte im Changelog keine Änderungseinträge gefunden werden.");

				if (changelogItems.Count >= 1 && changelogItems[0].SelectSingleNode("Change") != null)
					result.changelogGerman = changelogItems[0].SelectSingleNode("Change").InnerText;
				if (changelogItems.Count >= 2 && changelogItems[1].SelectSingleNode("Change") != null)
					result.changelogEnglish = changelogItems[1].SelectSingleNode("Change").InnerText;

			}

			return result;
		}

		public void cleanupEditUpdatePackage(prepareEditPackageResult prepareResult) {
			
			//Temporäre Daten löschen
			if (Directory.Exists(prepareResult.tempPackagePath))
				Directory.Delete(prepareResult.tempPackagePath, true);

		}

		#endregion

		#region Updateaktionen

		/// <summary>Lädt alle updateActions aus dem updateController und gibt diese als Liste zurück.</summary>
		/// <returns>Gibt eine Auflistung von allen updateActions aus dem updateController zurück.</returns>
		public Dictionary<actionBase, administrationEditorAttribute> availableUpdateActions() {
			var updateActions = new Dictionary<actionBase, administrationEditorAttribute>();

			//Controllerassembly laden
			Assembly asmController = Assembly.Load("updateSystemDotNet.Controller");
			//Basistyp festlegen nach welchem gesucht werden soll
			Type baseType = asmController.GetType("updateSystemDotNet.Core.updateActions.actionBase");

			foreach (Type tClass in asmController.GetTypes()) {
				if (tClass.IsAbstract) //Abstrakte Klassen ignorieren
					continue;

				if ((tClass.BaseType != null && tClass.BaseType == baseType) ||
					(tClass.BaseType != null && tClass.BaseType.BaseType != null && tClass.BaseType.BaseType == baseType)) {
					object[] attributes = tClass.GetCustomAttributes(typeof(administrationEditorAttribute), true);
					if (attributes.Length > 0) {
						var action = (actionBase)Activator.CreateInstance(tClass);
						action.ID = Guid.NewGuid().ToString();
						updateActions.Add(
							action,
							(attributes[0] as administrationEditorAttribute));
					}
				}
			}

			return updateActions;
		}

		/// <summary>Lädt das ToolBox-Image der jeweiligen updateAction aus dem updateController-Assembly.</summary>
		/// <param name="imageName">Der Name des Bildes (ohne Endung) welches ausgelesen werden soll.</param>
		public Image toolboxImage(string imageName) {
			Assembly controllerAssembly = Assembly.Load("updateSystemDotNet.Controller");
			var manager = new ResourceManager("updateSystemDotNet.Properties.Resources", controllerAssembly);
			object image = manager.GetObject(imageName);
			if (imageName != null)
				return (Bitmap) image;

			return null;
		}

		/// <summary>Gibt den zu einer bestimmten updateAction dazugehörigen actionEditor zurück.</summary>
		/// <param name="editorFullname">Der komplette Name des actionEditors</param>
		public actionEditorBase getActionEditor(string editorFullname) {
			if (string.IsNullOrEmpty(editorFullname)) {
				return new defaultActionEditor();
			}
			string assemblyName = Assembly.GetExecutingAssembly().FullName;
			var instance = (actionEditorBase)Activator.CreateInstance(assemblyName, editorFullname).Unwrap();
			instance.Session = _session;
			return instance;
		}

		/// <summary>Erstellt aus dem Type einer updateAction eine neue Instanz.</summary>
		public KeyValuePair<actionBase, administrationEditorAttribute> createNewInstance(Type instanceType) {
			var newInstance = (actionBase)Activator.CreateInstance(instanceType);
			newInstance.ID = Guid.NewGuid().ToString();
			var atrb =
				(administrationEditorAttribute)instanceType.GetCustomAttributes(typeof(administrationEditorAttribute), true)[0];
			return new KeyValuePair<actionBase, administrationEditorAttribute>(newInstance, atrb);
		}

		/// <summary>Fügt einem Updatepaket eine beliebige Updateaction hinzu.</summary>
		/// <param name="action">Die updateAction die hinzugefügt werden soll.</param>
		/// <param name="package">Das Updatepaket in welche die updateAction hinzugefügt werden soll.</param>
		/// <returns>Gibt True zurück wenn die updateAction erfolgreich hinzugefügt wurde, andernfalls False.</returns>
		public bool addActionToPackage(actionBase action, updatePackage package) {
			foreach (PropertyInfo property in package.GetType().GetProperties()) {
				if (!property.Name.ToLower().Contains(action.GetType().Name.ToLower())) continue;
			
				object instance = property.GetValue(package, null);
				MethodInfo mInfo = instance.GetType().GetMethod("Add");
				mInfo.Invoke(instance, new object[] {action});
				return true;
			}
			return false;
		}

		/// <summary>Ermittelt aus einer ID die dazugehörige updateAction aus einem bestimmten Updatepaket.</summary>
		public KeyValuePair<actionBase, administrationEditorAttribute> findActionById(string id, updatePackage package) {
			foreach (PropertyInfo property in package.GetType().GetProperties()) {
				if (!property.Name.ToLower().Contains("actions")) continue;

				Type propertyType = property.PropertyType;
				if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (List<>)) {
					//Anzahl aktionen in der Liste auslesen
					object instance = property.GetValue(package, null);
					var count = (int) instance.GetType().GetProperty("Count").GetValue(instance, null);

					//Alle aktionen auslesen und ID vergleichen
					if (count > 0) {
						for (int i = 0; i < count; i++) {
							var action = (actionBase) instance.GetType().GetProperty("Item").GetValue(instance, new object[] {i});

							if (action == null)
								continue;

							if (action.ID.Equals(id)) {
								return new KeyValuePair<actionBase, administrationEditorAttribute>(
									action,
									action.GetType().GetCustomAttributes(typeof (administrationEditorAttribute), true)[0] as
									administrationEditorAttribute);
							}
						}
					}
				}
			}
			throw new Exception(string.Format("Die Aktion mit der ID '{0}' konnte im Updatepaket nicht gefunden werden.", id));
		}

		#endregion

	}
}
