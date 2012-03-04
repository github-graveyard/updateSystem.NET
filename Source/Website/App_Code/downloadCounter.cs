using System.Xml;
using System.IO;

public class downloadCounter
{
	private readonly string _serverPath;
	private const string _downloadFilename = "Downloads.xml";

	public downloadCounter(string serverpath) {
		_serverPath = serverpath;
	}

	public void increaseDownloadCounter(string id) {
		XmlDocument data = getDownloadData();

		if (data != null) { // Überprüfen ob die Datendatei schon angelegt wurde.

			XmlNode dataNode = data.SelectSingleNode("Downloads/" + id);
			if (dataNode != null) { //Die Datei wurde bereits mindestens einmal heruntergeladen.
				int currentDownloads = int.Parse(dataNode.InnerText);
				dataNode.InnerText = (currentDownloads + 1).ToString();
			}
			else { //Neuen Node anlegen
				XmlNode appNode = data.CreateElement(id);
				appNode.InnerText = "1";
				data.SelectSingleNode("Downloads").AppendChild(appNode);
			}
			//Daten speichern
			using (StreamWriter writer = new StreamWriter(Path.Combine(_serverPath, _downloadFilename), false, System.Text.Encoding.UTF8)) {
				data.Save(writer);
			}
		}
		else { //Das komplette Dokument muss erstellt werden
			data = new XmlDocument();
			XmlNode rootNode = data.CreateElement("Downloads");

			XmlNode appNode = data.CreateElement(id);
			appNode.InnerText = "1";
			rootNode.AppendChild(appNode);

			data.AppendChild(rootNode);
			using (StreamWriter writer = new StreamWriter(Path.Combine(_serverPath, _downloadFilename), false, System.Text.Encoding.UTF8)) {
				data.Save(writer);
			}
		}
	}

	public string getDownloadCounter(string id) {
		XmlDocument downloadData = getDownloadData();

		//"0" zurückgeben wenn:
		if (downloadData == null || // Die Downloaddatei nicht exisitiert
		   downloadData.SelectSingleNode("Downloads/" + id) == null) { //Für die ID noch kein Eintrag angelegt wurde.
			return "0";
		}
		else {
			return downloadData.SelectSingleNode("Downloads/" + id).InnerText;
		}
	}

	XmlDocument getDownloadData() {

		if (File.Exists(Path.Combine(_serverPath, _downloadFilename))) {
			using (FileStream fsXml = File.OpenRead(Path.Combine(_serverPath, _downloadFilename))) {
				XmlDocument doc = new XmlDocument();
				doc.Load(fsXml);
				return doc;
			}
		}
		else {
			return null;
		}

	}

}