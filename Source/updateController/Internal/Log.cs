using System;
using System.IO;
using System.Reflection;
using System.Text;
using updateSystemDotNet.Core;

namespace updateSystemDotNet.Internal {
	internal class Log {
		private static Log _instance;
		private readonly string _logDirectory;
		private readonly string _logPath;

		private Log() //Singleton pattern
		{
			_logDirectory = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "updateSystem.Net.Logs");
			_logPath = Path.Combine(
				_logDirectory,
				string.Format("{0}_{1}_{2}.update.log", DateTime.Now.ToString("HH_mm_ss__dd_MM_yyyy"),
				              new Random(Environment.TickCount).Next(34567, 999999).ToString(),
				              Assembly.GetExecutingAssembly().GetName().Name));

			if (!Directory.Exists(_logDirectory)) {
				Directory.CreateDirectory(_logDirectory);
			}

			//Header mit Systeminformationen etc. schreiben
			writeHeader();
		}

		public bool Enabled { get; set; }

		public static Log Instance {
			get {
				if (_instance == null) {
					_instance = new Log();
				}
				return _instance;
			}
		}

		private void writeHeader() {
			writeEntry("------------------------------------");
			writeEntry("Environment Information");
			writeKeyValue("OS Version", Environment.OSVersion.VersionString);
			writeKeyValue("Architecture", Helper.GetArchitecture().ToString());
			writeKeyValue("CLR Version", Environment.Version.ToString());
			writeKeyValue("Assembly Version", Assembly.GetExecutingAssembly().FullName);
			writeKeyValue("Host", Assembly.GetEntryAssembly().FullName);
			writeEntry("------------------------------------");
		}

		private void write(string dataString) {
			try {
				if (!Enabled) {
					return;
				}
				using (var writer = new StreamWriter(
					_logPath,
					true,
					Encoding.UTF8)) {
					writer.WriteLine("{0}\t{1}",
					                 DateTime.Now.ToString(),
					                 dataString);
					writer.Flush();
				}
			}
			catch {
				// Tjoah, wohin mit der Exception wenn das schreiben fehl schlägt? Erstmal ignorieren ...
			}
		}

		public void writeKeyValue(string key, string value) {
			write(string.Format("{0}: {1}", key, value));
		}

		public void writeEntry(string message) {
			write(message);
		}

		public void writeEntry(string message, string modul) {
			write(string.Format("[{0}] {1}", modul, message));
		}

		public void writeException(Exception ex) {
			write(ex.ToString());
		}
	}
}