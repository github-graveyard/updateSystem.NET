//using System;
//using System.IO;
//using System.Reflection;
//using System.Security.Cryptography;
//using System.Text;
//using System.Xml.Serialization;
//using updateSystemDotNet.Administration.Core.Statistics;
//using updateSystemDotNet.Core.Types;

//namespace updateSystemDotNet.Administration.Core {
	
//    [Serializable]
//    [XmlRoot("updateProject")]
//    public sealed class OldupdateProject {
//        private statisticServerBase _staServerInstance;

//        /// <summary>Initialisiert eine neue Instanz von <see cref="OldupdateProject"/>.</summary>
//        public OldupdateProject() {
//            ftpAccount = new ftpAccount();
//        }

//        /// <summary>Beinhaltet die Zugangsinformationen für den Ftp-Account.</summary>
//        public ftpAccount ftpAccount { get; set; }

//        /// <summary>Gibt die Version der Projektdatei zurück.</summary>
//        public double projectFileVersion { get; set; }

//        /// <summary>Gibt den öffentlichen Schlüssel des Projektes zurück oder legt diesen fest.</summary>
//        public string publicKey { get; set; }

//        /// <summary>Gibt den privaten Schlüssel des Projektes zurück oder legt diesen fest.</summary>
//        public string privateKey { get; set; }

//        /// <summary>Gibt an ob die Version neuer Updatepakete aus einer anderen Assembly genutzt werden soll.</summary>
//        public bool useTargetAssemblyVersion { get; set; }

//        /// <summary>Gibt den Pfad zu der Datei zurück aus welcher die Versionsnummer für neue Updatepakete bezogen werden soll oder legt diese fest.</summary>
//        public string targetAssemblyVersionPath { get; set; }

//        /// <summary>Bietet Zugriff auf die Serverkonfiguration</summary>
//        /// <remarks>Diese Eigenschaft kann null sein.</remarks>
//        [XmlIgnore]
//        internal updateConfiguration Configuration { get; set; }

//        /// <summary>Gibt den Pfad des Projektes zurück oder legt diesen fest.</summary>
//        [XmlIgnore]
//        internal string projectPath { get; set; }

//        /// <summary>Gibt den mit dem Projekt assoziierten Statistikserver zurück.</summary>
//        [XmlIgnore]
//        internal statisticServerBase statisticServer {
//            get {
//                if (_staServerInstance == null) {
//                    //Instanz erstellen
//                    if (Configuration.statisticServer != null) {
//                        statisticServerTypeEx serverConfiguration =
//                            statisticServerTypeEx.FromStatisticServerType(Configuration.statisticServer);
//                        if (applicationBase.Instance.Settings.containsStatisticServerConfiguration(Configuration.statisticServer.Id)) {
//                            serverConfiguration =
//                                applicationBase.Instance.Settings.statisticServerConfiguration(Configuration.statisticServer.Id);
//                        }
//                        switch (Configuration.statisticServer.serverType) {
//                            case statisticServerTypes.AspNet:
//                                _staServerInstance = new statisticServerAsp(serverConfiguration);
//                                break;
//                            case statisticServerTypes.Php:
//                                _staServerInstance = new statisticServerPhp(serverConfiguration);
//                                break;
//                        }
//                    }
//                }
//                return _staServerInstance;
//            }
//        }

//        #region " Load / Save "

//        private static readonly aesEncryption _aes = new aesEncryption();

//        private static readonly byte[] _projEntropy = new byte[] {
//                                                                    3, 2, 55, 2, 4, 11, 4, 87, 1, 24, 61,
//                                                                    (byte) Assembly.GetExecutingAssembly().GetName().Version.Major
//                                                                 };

//        /// <summary>Lädt ein Projekt aus einer Datei.</summary>
//        /// <param name="filename">Der Pfad zu der Projektdatei welche geladen werden soll.</param>
//        public static OldupdateProject Load(string filename) {
//            if (string.IsNullOrEmpty(filename))
//                throw new ArgumentException("filename");

//            byte[] encodedProject = File.ReadAllBytes(filename);
//            byte[] decodedProject = _aes.decodeData(encodedProject, _projEntropy);
//            using (var msProject = new MemoryStream(decodedProject)) {
//                using (var srProject = new StreamReader(msProject, Encoding.UTF8)) {
//                    var serializer = new XmlSerializer(typeof (OldupdateProject));
//                    var instance = (OldupdateProject) serializer.Deserialize(srProject);
//                    instance.projectPath = filename;
//                    return instance;
//                }
//            }
//        }

//        /// <summary>Speichert eine Instanz von einer Projektdatei.</summary>
//        /// <param name="filename">Der Pfad unter welchem das Projekt gespeichert werden soll.</param>
//        /// <param name="instance">Die Instanz des Projektes welches gespeichert werden soll.</param>
//        public static void Save(string filename, OldupdateProject instance) {
//            if (string.IsNullOrEmpty(filename))
//                throw new ArgumentException("filename");
//            if (instance == null)
//                throw new ArgumentException("instance");

//            byte[] plainData = null;
//            using (var msData = new MemoryStream()) {
//                using (var swProject = new StreamWriter(msData, Encoding.UTF8)) {
//                    var serializer = new XmlSerializer(typeof (OldupdateProject));
//                    serializer.Serialize(swProject, instance);
//                    plainData = msData.ToArray();
//                }
//            }
//            byte[] encodedData = _aes.encodeData(plainData, _projEntropy);
//            File.WriteAllBytes(filename, encodedData);
//        }

//        #endregion

//        /// <summary>Erstellt eine neue Instanz der Projektdatei.</summary>
//        /// <returns>Gibt eine neue Instanz von <see cref="updateProject"/> zurück.</returns>
//        public static OldupdateProject Create() {
//            var project = new OldupdateProject();
//            project.projectFileVersion = Strings.projectVersion;

//            //Updatekonfiguration erzeugen
//            project.Configuration = new updateConfiguration();

//            //Neue Schlüssel erzeugen
//            var rsa = new RSACryptoServiceProvider(4096);
//            project.publicKey = rsa.ToXmlString(false);
//            project.privateKey = rsa.ToXmlString(true);

//            return project;
//        }
//    }
//}