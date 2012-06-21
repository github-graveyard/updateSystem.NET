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
using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml;

namespace updateSystemDotNet.Setup.Core {
	internal sealed class setupPackage {
		private readonly setupContext _context;

		public setupPackage(setupContext currentContext) {
			_context = currentContext;
		}

		public event EventHandler<ProgressChangedEventArgs> fileProgressChanged;

		public void copyFiles() {
			using (
				var msData =
					(UnmanagedMemoryStream)
					Assembly.GetExecutingAssembly().GetManifestResourceStream("updateSystemDotNet.Setup.setup.package")) {
				using (var resReader = new ResourceReader(msData)) {
					//Dateimap einlesen
					var xmlMap = new XmlDocument();
					byte[] mapData = null;
					string tempString;
					resReader.GetResourceData("map", out tempString, out mapData);
					using (var msMap = new MemoryStream(mapData)) {
						using (var srMap = new StreamReader(msMap, Encoding.UTF8)) {
							xmlMap.Load(srMap);
						}
					}

					int totalFiles = (xmlMap.SelectNodes("Files/File").Count);
					int currentFile = 0;

					//Dateien verarbeiten
					foreach (XmlNode fileNode in xmlMap.SelectNodes("Files/File")) {
						byte[] compressedFileData = null;
						resReader.GetResourceData(fileNode.SelectSingleNode("Id").InnerText, out tempString, out compressedFileData);
						writeCompressedFile(
							compressedFileData,
							fileNode.SelectSingleNode("Directory").InnerText,
							fileNode.SelectSingleNode("Filename").InnerText);

						currentFile++;
						if (fileProgressChanged != null)
							fileProgressChanged(this, new ProgressChangedEventArgs(Percent(currentFile, totalFiles), null));
					}
				}
			}
		}

		private void writeCompressedFile(byte[] compressedData, string destination, string filename) {
			//Prüfen ob Zielverzeichnis existiert
			string completeDirectory = _context.installationDirectory;
			bool isRoot = true;
			if (!string.IsNullOrEmpty(destination) && destination != "\\") {
				completeDirectory = Path.Combine(_context.installationDirectory, destination);
				isRoot = false;
			}
			if (!Directory.Exists(completeDirectory))
				Directory.CreateDirectory(completeDirectory);

			File.WriteAllBytes(Path.Combine(completeDirectory, filename), Decompress(compressedData));

			if (isRoot && (filename.EndsWith(".dll") || filename.EndsWith(".exe"))) {
				nativeImages.Install(Path.Combine(completeDirectory, filename));
			}
		}

		private byte[] Decompress(byte[] gzip) {
			using (var stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress)) {
				const int size = 4096;
				var buffer = new byte[size];
				using (var memory = new MemoryStream()) {
					int count = 0;
					do {
						count = stream.Read(buffer, 0, size);
						if (count > 0) {
							memory.Write(buffer, 0, count);
						}
					} while (count > 0);
					return memory.ToArray();
				}
			}
		}

		private int Percent(long CurrVal, long MaxVal) {
			try {
				return (int) (((CurrVal/((double) MaxVal))*100.0));
			}
			catch {
				return 100;
			}
		}
	}
}