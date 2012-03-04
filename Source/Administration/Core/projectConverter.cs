//using System.IO;
//using System.Text;
//using System.Xml;
//using updateSystemDotNet.Core;

//namespace updateSystemDotNet.Administration.Core {
//    /// <summary>Klasse zum Konvertieren von Projektdateien</summary>
//    internal class projectConverter {
//        private string ftpVector1 {
//            get { return "e6LupN7H3XDIZsceFNLjXPKQssXRexT9tfuZtrgmFkvfSN9YbL"; }
//        }

//        private string ftpVector2 {
//            get { return "4pk6XSCcXMYXQukTSI87"; }
//        }

//        private string ftpVector3 {
//            get { return "dkwqlefkmefwokew"; }
//        }

//        /// <summary>Konvertiert ein altes udproj in ein neues udprojx.</summary>
//        /// <returns>Gibt den Pfad zu dem neuen Updateprojekt zurück.</returns>
//        public string Convert(string pathToOldFile) {
//            //Altes Projekt als XML-Datei einlesen
//            var xdocOldProject = new XmlDocument();
//            using (var srProject = new StreamReader(pathToOldFile, Encoding.UTF8)) {
//                xdocOldProject.Load(srProject);
//            }

//            //Neues Projekt erstellen und Dateinamen generieren
//            var newProject = new OldupdateProject();
//            string newFilename = Path.ChangeExtension(pathToOldFile, ".udprojx");

//            //Werte setzen
//            newProject.publicKey = xdocOldProject.SelectSingleNode("Project/publickey").InnerText;
//            newProject.privateKey = xdocOldProject.SelectSingleNode("Project/privatekey").InnerText;
//            newProject.ftpAccount.Hostname = xdocOldProject.SelectSingleNode("Project/ftp_Server").InnerText;
//            newProject.ftpAccount.Port = int.Parse(xdocOldProject.SelectSingleNode("Project/ftp_Port").InnerText);
//            newProject.ftpAccount.Directory = xdocOldProject.SelectSingleNode("Project/ftp_Directory").InnerText;
//            newProject.ftpAccount.Username = xdocOldProject.SelectSingleNode("Project/ftp_User").InnerText;
//            newProject.ftpAccount.Password = Helper.AESDecrypt(
//                xdocOldProject.SelectSingleNode("Project/ftp_Password").InnerText,
//                ftpVector1,
//                ftpVector2,
//                "Sha1",
//                14,
//                ftpVector3,
//                256);

//            string oldConnectionType = xdocOldProject.SelectSingleNode("Project/ftp_transmissionType").InnerText;
//            if (oldConnectionType != "Normal")
//                newProject.ftpAccount.connectionType = ftpConnectionTypes.FtpSslExplicit;

//            //Neues Projekt speichern
//            OldupdateProject.Save(newFilename, newProject);

//            return newFilename;
//        }
//    }
//}