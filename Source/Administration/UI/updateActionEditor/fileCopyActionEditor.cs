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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core;
using updateSystemDotNet.Administration.Core.DragDrop;
using updateSystemDotNet.Administration.Properties;
using updateSystemDotNet.Administration.UI.Controls;
using updateSystemDotNet.Administration.UI.Dialogs;
using updateSystemDotNet.Core.Types;
using updateSystemDotNet.Core.updateActions;

namespace updateSystemDotNet.Administration.UI.updateActionEditor {
	internal partial class fileCopyActionEditor : actionEditorBase {
		private const string folderImageName = "59214abd-bd76-4faa-b257-89c6c6540e0c";
		private readonly Directories _directoryHelper = new Directories();
		private readonly MD5 _md5 = MD5.Create();
		private fileCopyAction _action;
		//Der Name von dem ImageKey von Verzeichnissen bekommt deshalb eine Guid damit es später nicht zu Problemen kommt

		private ContextMenu ctxFolder;

		public fileCopyActionEditor() {
			InitializeComponent();
			initializeContextMenus();
			imglFiles.Images.Add(folderImageName, Resources.folder);
			tsbtnDelete.Click += delegate { removeSelected(); };
			tvwFiles.KeyDown += tvwFiles_KeyDown;
			tvwFiles.AfterSelect += tvwFiles_AfterSelect;

			tvwFiles.DragEnter += tvwFiles_DragEnter;
			tvwFiles.DragOver += tvwFiles_DragOver;
			tvwFiles.DragLeave += tvwFiles_DragLeave;
			tvwFiles.DragDrop += tvwFiles_DragDrop;

			//Stammverzeichnisse hinzufügen
			foreach (Directories.DirectoryItem directory in _directoryHelper.GetDirectories()) {
				TreeNode dirNode = createBaseNode(directory.ToString(), folderImageName);
				dirNode.Name = directory.Value;
				dirNode.ContextMenu = ctxFolder;
				tvwFiles.Nodes.Add(dirNode);
			}

			//Ersten TreeNode auswählen
			tvwFiles.SelectedNode = tvwFiles.Nodes[0];
			tsFiles.Renderer = new nativeRenderer(ToolbarTheme.Toolbar);
		}

		private void tvwFiles_AfterSelect(object sender, TreeViewEventArgs e) {
			tsbtnDelete.Enabled = (e.Node != null && e.Node.Level > 0);
		}

		private void tvwFiles_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete)
				removeSelected();
		}

		/// <summary>Initialisiert die ContextMenus für die Datei- und Verzeichnis TreeNodes.</summary>
		private void initializeContextMenus() {
			ctxFolder = new ContextMenu();
			ctxFolder.MenuItems.Add("Verzeichnis erstellen", delegate { createNewFolder(); });
		}

		/// <summary>Öffnet den Dialog zum Erstellen eines neuen Verzeichnisses und fügt dieses dem aktuell ausgewählten TreeNode hinzu.</summary>
		private void createNewFolder() {
			using (var dialog = new addFolderDialog()) {
				if (dialog.ShowDialog(ParentForm) == DialogResult.OK) {
					//Es soll mehr als ein Verzeichnis angelegt werden
					if (dialog.enteredFolder.IndexOf('\\') != -1) {
						tvwFiles.SelectedNode.Nodes.Add(
							createFolder(dialog.enteredFolder.Split(new[] {"\\"}, StringSplitOptions.RemoveEmptyEntries)));
					}
					else
						tvwFiles.SelectedNode.Nodes.Add(createFolder(dialog.enteredFolder));
				}
			}
		}

		/// <summary>Erstellt einen Basisnode mit festgelegtem Text und und ImageKey.</summary>
		/// <param name="text">Der Text für den TreeNode.</param>
		/// <param name="imagekey">Der ImageKey</param>
		private TreeNode createBaseNode(string text, string imagekey) {
			var node = new TreeNode(text);
			node.ImageKey = imagekey;
			node.SelectedImageKey = imagekey;
			return node;
		}

		/// <summary>Erstellt einen neuen FileType.</summary>
		/// <param name="path">Der vollständige Pfad zu der Datei.</param>
		/// <param name="destination">Das Zielverzeichnis auf dem Clientsystem.</param>
		/// <returns>Gibt den neuen FileType zurück.</returns>
		private FileType createNewFileType(string path, string destination) {
			var newType = new FileType {
			                           	ID = Guid.NewGuid().ToString(),
			                           	Fullpath = path,
			                           	fileVersion = FileVersionInfo.GetVersionInfo(path).ProductVersion,
			                           	copyFlag = fileCopyFlags.AlwaysOverwrite,
			                           	Filename = Path.GetFileName(path),
			                           	Destination = convertFriendlyToInternal(destination)
			                           };

			byte[] hash = null;
			using (FileStream fsFile = File.OpenRead(path)) {
				hash = _md5.ComputeHash(fsFile);
			}
			newType.Hash = Convert.ToBase64String(hash);
			return newType;
		}

		/// <summary>Gibt die TreeNode zurück welche das derzeit ausgewählte Verzeichnis repräsentiert.</summary>
		public TreeNode selectedDirectory() {
			if (tvwFiles.SelectedNode.Tag == null && tvwFiles.SelectedNode.ImageKey == folderImageName)
				return tvwFiles.SelectedNode;
			else
				return tvwFiles.SelectedNode.Parent;
		}

		/// <summary>Konvertiert einen Benutzerfreundlichen Pfad in einen für das updateSystem.Net lesbaren.</summary>
		/// <param name="path">Der Pfad der konvertiert werden soll.</param>
		/// <returns>Gibt den konvertierten Pfad zurück.</returns>
		public string convertFriendlyToInternal(string path) {
			foreach (Directories.DirectoryItem dirItem in _directoryHelper.GetDirectories()) {
				path = path.Replace(dirItem.ToString(), dirItem.Value);
			}
			return path;
		}

		/// <summary>
		/// Fügt eine Datei in das TreeView ein.
		/// </summary>
		/// <param name="filetype"></param>
		public void insertFile(FileType filetype) {
			/*if (!System.IO.File.Exists(filetype.Fullpath)) {
				removeListItem(filetype.ID);
				return;
			}*/

			string path = filetype.Destination;
			string[] directoryParts = path.Split(new[] {@"\"}, StringSplitOptions.RemoveEmptyEntries);

			TreeNode rootNode = tvwFiles.Nodes[directoryParts[0]];
			TreeNode workingNode = rootNode;

			//Erstelle Verzeichnisstrukur
			if (directoryParts.Length > 1) {
				for (int i = 1; i < directoryParts.Length; i++) {
					if (!nodeExists(directoryParts[i], workingNode)) {
						workingNode.Nodes.Add(createFolder(directoryParts[i]));
					}
					workingNode = workingNode.Nodes[directoryParts[i]];
				}
			}

			//Dateinode erstellen
			TreeNode nodeFile = createBaseNode(filetype.Filename, filetype.ID);

			if (File.Exists(filetype.Fullpath))
				imglFiles.Images.Add(filetype.ID,
				                     graphicUtils.shrinkImage(Icon.ExtractAssociatedIcon(filetype.Fullpath).ToBitmap(),
				                                              new Size(16, 16)));
			else
				imglFiles.Images.Add(filetype.ID, graphicUtils.shrinkImage(SystemIcons.Error.ToBitmap(), new Size(16, 16)));

			nodeFile.Tag = filetype;
			nodeFile.Name = filetype.Filename;
			//nodeFile.ContextMenuStrip = ctxFile;
			if (!nodeExists(filetype.Filename, workingNode)) {
				workingNode.Nodes.Add(nodeFile);
				//workingNode.ExpandAll();
			}
		}

		/// <summary>Überprüft ob ein Eintrag bereits in einer TreeViewNode existiert.</summary>
		/// <param name="name">Der Name des Eintrags nachdem gesucht werden soll.</param>
		/// <param name="node">Die TreeViewNode die durchsucht werden soll.</param>
		/// <returns>Gibt true zurück wenn der Eintrag gefunden wurde, andernfalls false.</returns>
		public bool nodeExists(string name, TreeNode node) {
			foreach (TreeNode tNode in node.Nodes) {
				if (tNode.Name.Equals(name)) {
					return true;
				}
			}
			return false;
		}

		/// <summary>Erstellt ein neues Verzeichnis im TreeView.</summary>
		/// <param name="folderParts">Ein Stringarray welche eine mehrschichtige Verzeichnisstruktur darstellt.</param>
		private TreeNode createFolder(string[] folderParts) {
			TreeNode newFolderRoot = createFolder(folderParts[0]);
			TreeNode currentNode = null;
			for (int i = 1; i < folderParts.Length; i++) {
				if (currentNode != null) {
					currentNode.Nodes.Add(createFolder(folderParts[i]));
					currentNode = currentNode.Nodes[0];
				}
				else {
					currentNode = createFolder(folderParts[i]);
					newFolderRoot.Nodes.Add(currentNode);
				}
			}

			return newFolderRoot;
		}

		/// <summary>Erstellt ein neues Verzeichnis im TreeView.</summary>
		/// <param name="folderName">Der Name des neuen Verzeichnisses.</param>
		/// <returns>Gibt einen TreeNode mit dem neuen Verzeichnis zurück.</returns>
		private TreeNode createFolder(string folderName) {
			return createFolder(folderName, folderName);
		}

		/// <summary>Erstellt ein neues Verzeichnis im TreeView.</summary>
		/// <param name="folderName">Der Name des neuen Verzeichnisses.</param>
		/// <param name="folderKey">Der Schlüssel des neuen Verzeichnisses.</param>
		/// <returns>Gibt einen TreeNode mit dem neuen Verzeichnis zurück.</returns>
		private TreeNode createFolder(string folderName, string folderKey) {
			TreeNode trFolder = createBaseNode(folderName, folderImageName);
			trFolder.ExpandAll();
			trFolder.Name = folderKey;
			trFolder.ContextMenu = ctxFolder;

			return trFolder;
		}

		public override void initializeActionContent() {
			_action = (fileCopyAction) updateAction;
			foreach (FileType fType in _action.Files) {
				insertFile(fType);
			}
		}

		private void tsbtnAddFiles_Click(object sender, EventArgs e) {
			using (var dialog = new OpenFileDialog()) {
				dialog.Filter = "Alle Dateien|*.*";
				dialog.Multiselect = true;
				if (dialog.ShowDialog(this) == DialogResult.OK) {
					foreach (string file in dialog.FileNames) {
						FileType newFileType = createNewFileType(file, selectedDirectory().FullPath);
						_action.Files.Add(newFileType);
						insertFile(newFileType);
					}
				}
			}
		}

		private void tsbtnAddFolder_Click(object sender, EventArgs e) {
			using (var dialog = new FolderBrowserDialog()) {
				dialog.Description =
					"Wählen Sie einen Ordner welchen Sie mitsamt aller Unterordner zu dem Updatepaket hinzufügen möchten:";
				dialog.ShowNewFolderButton = false;
				if (dialog.ShowDialog(this) == DialogResult.OK) {
					foreach (string file in Directory.GetFiles(dialog.SelectedPath, "*", SearchOption.AllDirectories)) {
						//Relativen Pfad für den Clienten ermitteln
						string destinationPath = Path.GetDirectoryName(file).Replace(dialog.SelectedPath, "");
						if (!destinationPath.StartsWith("\\"))
							destinationPath = "\\" + destinationPath;
						destinationPath = convertFriendlyToInternal(selectedDirectory().FullPath) + destinationPath;

						//Neuen Dateityp erstellen
						FileType fType = createNewFileType(file, destinationPath);
						_action.Files.Add(fType);
						insertFile(fType);
					}
				}
			}
		}

		private void removeSelected() {
			//Nichts oder den Rootnode selektiert?
			if (tvwFiles.SelectedNode == null ||
			    tvwFiles.SelectedNode.Level == 0)
				return;

			TreeNode selectedNode = tvwFiles.SelectedNode;
			if (selectedNode.Tag is FileType) {
				//Es soll eine Datei gelöscht werden
				_action.Files.Remove(selectedNode.Tag as FileType);
				tvwFiles.Nodes.Remove(selectedNode);
			}
			else {
				//Es soll ein Ordner gelöscht werden

				//Alle FileTypes aus dem aktuellen und dessen Unterordnern ermitteln
				var obsoleteFileTypes = new List<FileType>();
				determineObsoleteFileTypes(obsoleteFileTypes, selectedNode);
				foreach (FileType obsFile in obsoleteFileTypes) {
					_action.Files.Remove(obsFile);
				}
				tvwFiles.Nodes.Remove(selectedNode);
			}
		}

		private void determineObsoleteFileTypes(List<FileType> list, TreeNode root) {
			foreach (TreeNode node in root.Nodes) {
				if (node.Tag != null && node.Tag is FileType) // Datei
					list.Add(node.Tag as FileType);
				else {
					//Ordner
					determineObsoleteFileTypes(list, node);
				}
			}
		}

		#region " DragDrop Stuff "

		private TreeNode previousDragOver;

		protected override void OnDragEnter(DragEventArgs drgevent) {
			DropTargetHelper.DragEnter(this, drgevent.Data, new Point(drgevent.X, drgevent.Y), DragDropEffects.None);
			base.OnDragEnter(drgevent);
		}

		protected override void OnDragOver(DragEventArgs drgevent) {
			DropTargetHelper.DragOver(new Point(drgevent.X, drgevent.Y), DragDropEffects.None);
			base.OnDragOver(drgevent);
		}

		protected override void OnDragLeave(EventArgs e) {
			DropTargetHelper.DragLeave(this);
			base.OnDragLeave(e);
		}

		protected override void OnDragDrop(DragEventArgs drgevent) {
			DropTargetHelper.Drop(drgevent.Data, new Point(drgevent.X, drgevent.Y), DragDropEffects.None);
			base.OnDragDrop(drgevent);
		}

		private void tvwFiles_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = e.AllowedEffect & DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
			DropTargetHelper.Drop(e.Data, new Point(e.X, e.Y), e.Effect);

			TreeNode nodeAt = tvwFiles.GetNodeAt(tvwFiles.PointToClient(new Point(e.X, e.Y)));
			if (e.Effect == DragDropEffects.Copy && nodeAt != null)
				AcceptFileDrop(nodeAt, e.Data);
		}

		private void AcceptFileDrop(TreeNode nodeAt, IDataObject data) {
			if (data.GetDataPresent(DataFormats.FileDrop)) {
				var dropData = data.GetData(DataFormats.FileDrop) as string[];
				if (dropData != null) {
					var newFiles = new List<FileType>();
					TreeNode dropNode = (nodeAt.Tag is FileType ? nodeAt.Parent : nodeAt);

					if (dropData.Length == 1) {
						//Entweder eine Datei oder ein Ordner

						if (File.Exists(dropData[0])) {
							//Genau eine Datei
							//Datei hinzufügen
							newFiles.Add(
								createNewFileType(dropData[0],
								                  convertFriendlyToInternal((nodeAt.Tag is FileType ? nodeAt.Parent.FullPath : nodeAt.FullPath))));
						}
						else {
							//Genau ein Ordner
							var dirInfo = new DirectoryInfo(dropData[0]);
							string baseDirectory = dropData[0];
							if (dirInfo.Parent != null)
								baseDirectory = dirInfo.Parent.FullName;

							foreach (string directoryObject in Directory.GetFiles(dropData[0], "*", SearchOption.AllDirectories)) {
								string inheritedDestination = Path.GetDirectoryName(directoryObject).Replace(baseDirectory, "");
								if (!inheritedDestination.StartsWith("\\"))
									inheritedDestination = "\\" + inheritedDestination;
								inheritedDestination = convertFriendlyToInternal(dropNode.FullPath) + inheritedDestination;

								newFiles.Add(createNewFileType(directoryObject, inheritedDestination));
							}
						}
					}
					else {
						// Mehrere Datei(en) und/oder Ordner

						foreach (string dropObject in dropData) {
							if (Directory.Exists(dropObject)) {
								//Verzeichnis
								var diRoot = new DirectoryInfo(dropObject);
								string rootDirectory = (diRoot.Parent != null ? diRoot.Parent.FullName : diRoot.FullName);
								foreach (string file in Directory.GetFiles(dropObject, "*", SearchOption.AllDirectories)) {
									string destination = Path.GetDirectoryName(file).Replace(rootDirectory, "");
									if (!destination.StartsWith("\\"))
										destination = "\\" + destination;
									destination = convertFriendlyToInternal(dropNode.FullPath) + destination;
									newFiles.Add(createNewFileType(file, destination));
								}
							}
							else {
								//Datei
								//Datei hinzufügen
								string destination =
									convertFriendlyToInternal((nodeAt.Tag is FileType ? nodeAt.Parent.FullPath : nodeAt.FullPath)) + "\\";
								newFiles.Add(
									createNewFileType(dropObject, destination));
							}
						}
					}

					foreach (FileType ftNew in newFiles) {
						insertFile(ftNew);
						_action.Files.Add(ftNew);
					}
				}
			}
		}


		private void tvwFiles_DragLeave(object sender, EventArgs e) {
			DropTargetHelper.DragLeave(tvwFiles);
			((explorerTreeView) sender).SetInsertionMark(null, explorerTreeView.InsertType.AfterNode);
			previousDragOver = null;
		}

		private void tvwFiles_DragOver(object sender, DragEventArgs e) {
			TreeNode nodeAt = tvwFiles.GetNodeAt(tvwFiles.PointToClient(new Point(e.X, e.Y)));
			bool fileDrop = (e.Data.GetDataPresent(DataFormats.FileDrop));

			if (nodeAt != null || fileDrop) {
				if (nodeAt != null) {
					if (nodeAt != previousDragOver) {
						if (nodeAt.Tag is FileType) {
							tvwFiles.SetInsertionMark(nodeAt.Parent, explorerTreeView.InsertType.InsideNode);
							e.Data.SetDropDescription(DropImageType.Copy, "Zu %1 hinzufügen", nodeAt.Parent.Text);
						}
						else {
							tvwFiles.SetInsertionMark(nodeAt, explorerTreeView.InsertType.InsideNode);
							e.Data.SetDropDescription(DropImageType.Copy, "Zu %1 hinzufügen", nodeAt.Text);
						}
					}
				}
				previousDragOver = nodeAt;
				e.Effect = e.AllowedEffect & DragDropEffects.Copy;
			}
			else {
				e.Effect = DragDropEffects.None;
				tvwFiles.SetInsertionMark(null, explorerTreeView.InsertType.BeforeNode);
				e.Data.DisableDropDescription();
				e.Effect = DragDropEffects.None;
				DropTargetHelper.DragOver(new Point(e.X, e.Y), e.Effect);
				previousDragOver = null;
			}
			DropTargetHelper.DragOver(new Point(e.X, e.Y), e.Effect);
		}

		private void tvwFiles_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = e.AllowedEffect & DragDropEffects.Copy;
				DropTargetHelper.DragEnter(tvwFiles, e.Data, new Point(e.X, e.Y), e.Effect, "Copy to %1", "Here");
			}
			else {
				e.Effect = DragDropEffects.None;
				DropTargetHelper.DragEnter(tvwFiles, e.Data, new Point(e.X, e.Y), e.Effect);
			}
		}

		#endregion
	}
}