using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace updateSystemDotNet.Core.Types {
	/// <summary>
	/// Sicherer XML-Container welcher neben einem Datenblock auch einen Signaturblock enthält
	/// </summary>
	public class SecureContainer {
		private string m_content = string.Empty;
		private string m_signature = string.Empty;

		/// <summary>
		/// Der Datenblock
		/// </summary>
		public string Content {
			get { return m_content; }
			set { m_content = value; }
		}

		/// <summary>
		/// Die digitale Signatur des Datenblocks
		/// </summary>
		public string Signature {
			get { return m_signature; }
			set { m_signature = value; }
		}

		/// <summary>
		/// Byte Array welches das sichere XML-Dokument enthält
		/// </summary>
		/// <param name="Data"></param>
		public void Load(byte[] Data) {
			using (var msData = new MemoryStream(Data)) {
				using (var srData = new StreamReader(msData, Encoding.UTF8)) {
					var document = new XmlDocument();
					document.Load(srData);

					m_content = document.SelectSingleNode("updateSystemDotNet").SelectSingleNode("Content").InnerText;
					m_signature = document.SelectSingleNode("updateSystemDotNet").SelectSingleNode("Signature").InnerText;
				}
			}
			//System.Xml.XmlTextReader xR = new System.Xml.XmlTextReader(new System.IO.MemoryStream(Data));
			//while (xR.Read())
			//{
			//    if (xR.Name == "Content" && m_content == string.Empty)
			//    {
			//        xR.Read();
			//        m_content = xR.Value;
			//    }
			//    if (xR.Name == "Signature" && m_signature == string.Empty)
			//    {
			//        xR.Read();
			//        m_signature = xR.Value;
			//    }
			//}
			//xR.Close();
		}

		/// <summary>
		/// Speichert die Daten in einem Byte Array
		/// </summary>
		/// <returns></returns>
		public byte[] Save() {
			using (var memS = new MemoryStream()) {
				using (var swData = new StreamWriter(memS, Encoding.UTF8)) {
					var document = new XmlDocument();
					document.AppendChild(document.CreateDocumentFragment());
					document.AppendChild(
						document.CreateComment(string.Format("Erstellt mit dem updateSystem.Net Designer Version {0}",
						                                     Assembly.GetEntryAssembly().GetName().Version)));
					document.AppendChild(
						document.CreateComment(string.Format("Copyright (c) 2007 - {0} Maximilian Krauss", DateTime.Now.Year.ToString())));
					document.AppendChild(document.CreateComment("DO NOT MODIFY THIS FILE BY YOURSELF!"));
					document.AppendChild(document.CreateComment("DIESE DATEI DARF NICHT VERÄNDERT WERDEN!"));

					XmlNode rootNode = document.CreateElement("updateSystemDotNet");

					XmlNode xContent = document.CreateElement("Content");
					xContent.InnerText = m_content;
					rootNode.AppendChild(xContent);

					XmlNode xSignature = document.CreateElement("Signature");
					xSignature.InnerText = m_signature;
					rootNode.AppendChild(xSignature);

					document.AppendChild(rootNode);
					document.Save(swData);
					swData.Flush();
					//System.Xml.XmlTextWriter xT = new System.Xml.XmlTextWriter(memS, System.Text.Encoding.UTF8);
					//xT.WriteStartDocument();
					//xT.WriteComment(string.Format("Copyright (c) {0} Maximilian Krauss", DateTime.Now.Year.ToString()));
					//xT.WriteComment(string.Format("Created with updateSystemDotNet Version {0}", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()));
					//xT.WriteStartElement("SecureContainer");
					//xT.WriteStartElement("Data");
					//xT.WriteStartElement("Content");
					//xT.WriteString(m_content);
					//xT.WriteEndElement();
					//xT.WriteStartElement("Signature");
					//xT.WriteString(m_signature);
					//xT.WriteEndElement();
					//xT.WriteEndElement();
					//xT.WriteEndElement();
					//xT.WriteEndDocument();
					//xT.Close();
				}
				return memS.ToArray();
			}
		}
	}
}