using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Resources;
using System.IO.Compression;

namespace setupDataBuilder {
	
	//Hilfsprogramm zum Erstellen von Datendateien für das Programmsetup

	class Program {
		static void Main(string[] args) {

			string dataDirectory = args[0];
			string targetFile = args[1];

			XmlDocument map = new XmlDocument();
			XmlNode xFilesNode = map.CreateElement("Files");
			ResourceWriter writer = new ResourceWriter(targetFile);

			foreach (string file in Directory.GetFiles(dataDirectory, "*", SearchOption.AllDirectories)) {

				XmlNode xFile = map.CreateElement("File");
				string id = Guid.NewGuid().ToString();
				string targetDirectory = Path.GetDirectoryName(file).Replace(dataDirectory, "");
				if (targetDirectory.StartsWith("\\"))
					targetDirectory = targetDirectory.Substring(1);

				xFile.AppendChild(createNode(map, "Id", id));
				xFile.AppendChild(createNode(map, "Directory", targetDirectory)); ;
				xFile.AppendChild(createNode(map, "Filename", Path.GetFileName(file)));
				xFilesNode.AppendChild(xFile);

				writer.AddResourceData(id, "setupData", Compress(File.ReadAllBytes(file)));
				
			}

			map.AppendChild(xFilesNode);
			using (MemoryStream msData = new MemoryStream()) {
				using (StreamWriter sw = new StreamWriter(msData, Encoding.UTF8)) {
					map.Save(sw);
					writer.AddResourceData("map", "setupData", msData.ToArray());
				}
			}

			writer.Generate();
			writer.Dispose();
		}

		private static byte[] Compress(byte[] raw) {
			using (MemoryStream memory = new MemoryStream()) {
				using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress, true)) {
					gzip.Write(raw, 0, raw.Length);
				}
				return memory.ToArray();
			}
		}


		private static XmlNode createNode(XmlDocument doc, string name, string value) {
			XmlNode node = doc.CreateElement(name);
			node.InnerText = value;
			return node;
		}

	}
}
