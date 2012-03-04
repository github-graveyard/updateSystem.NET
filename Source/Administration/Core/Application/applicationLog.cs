using System.IO;
using System;
using System.Text;
using System.Reflection;
namespace updateSystemDotNet.Administration.Core.Application {
	
	internal enum logLevel {
		Info,
		Warning,
		Error
	}
	
	internal sealed class applicationLog {

		private readonly string _logDirectory;
		private readonly string _logSessionFilename;
		private readonly string _seperator;
		private readonly applicationSession _session;
		private int _logDepth;

		public applicationLog(applicationSession session) {
			_session = session;
			_seperator = new string('=', 60);
			_logDirectory =
				Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "updateSystem.NET"),
				             "Logs");

			if (!Directory.Exists(_logDirectory))
				Directory.CreateDirectory(_logDirectory);

			_logSessionFilename = string.Format("[{0}] Administration.log", DateTime.Now.ToString("dd.MM.yyyy"));
			initializeLogSession();
		}

		public string logDirectory { get { return _logDirectory; } }

		/// <summary>Initialisiert die Logdatei und schreibt in diese Informationen über Version und Betriebssystem.</summary>
		private void initializeLogSession() {
			writeLogInternal(logLevel.Info, "Anwendung gestartet");
			logDepthIncrease();

			//Umgebungsinformationen
			writeKeyValue("Version (Anwendung)", Assembly.GetExecutingAssembly().GetName().Version.ToString());
			writeKeyValue("Version (Betriebssystem)", Environment.OSVersion.VersionString);
			writeKeyValue("Plattform",
			              ((Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") ?? string.Empty).Contains("64")
			               	? "64-Bit"
			               	: "32-Bit"));
			logDepthDecrease();
		}

		public void writeKeyValue(string key, string value) {
			writeKeyValue(logLevel.Info, key, value);
		}
		public void writeKeyValue(logLevel level, string key, string value) {
			writeLogInternal(level, string.Format("{0}: {1}", key, value));
		}

		public void writeState(string state) {
			writeState(logLevel.Info, state);
		}
		public void writeState(logLevel level, string state) {
			writeLogInternal(level, state);
		}
		public void writeException(Exception exception) {
			var sbExceptionStack = new StringBuilder();
			for (var exc = exception; exc != null; exc = exc.InnerException)
				sbExceptionStack.AppendLine(exc.ToString());
			writeLogInternal(logLevel.Error, sbExceptionStack.ToString());
		}

		/// <summary>Beendet die Logsession</summary>
		public void finalizeLogSession() {
			logDepthReset();
			writeLogInternal(logLevel.Info, string.Format("Anwendung beendet\r\n{0}", _seperator));
		}

		/// <summary>Erhöht die Einrückung der Logeinträge.</summary>
		public void logDepthIncrease() {
			_logDepth++;
		}
		/// <summary>Verringert die Einrückung der Logeinträge.</summary>
		public void logDepthDecrease() {
			if (_logDepth > 0)
				_logDepth--;
		}
		/// <summary>Setzt die Einrückung der Logeinträge wieder auf 0 zurück.</summary>
		public void logDepthReset() {
			_logDepth = 0;
		}

		/// <summary>Erstellt abhängig aus der Logtiefe einen String aus Tabs.</summary>
		private string logDepthSpace {
			get {
				if (_logDepth == 0)
					return string.Empty;
				
				var sbDepth = new StringBuilder();
				for (var i = 0; i < _logDepth; i++)
					sbDepth.Append("\t");
				return sbDepth.ToString();
			}
		}

		private void writeLogInternal(logLevel level, string message) {

			//Nichts machen wenn die Logfunktion ausgestellt ist
			if (!_session.Settings.enableLogging)
				return;

			//Logverzeichnis erstellen
			if (!Directory.Exists(_logDirectory))
				Directory.CreateDirectory(_logDirectory);

			using(var writer = new StreamWriter(Path.Combine(_logDirectory, _logSessionFilename), true, Encoding.UTF8)) {
				writer.WriteLine(string.Format("[{0}] [{1}] {2}{3}", new object[] {
				                                                                  	DateTime.Now.ToString(),
				                                                                  	level,
				                                                                  	logDepthSpace,
				                                                                  	message
				                                                                  }));
				writer.Flush();
			}
		}

	}
}