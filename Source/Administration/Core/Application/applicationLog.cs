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

		/// <summary>Initializes the Log and Write some basic Computerinformation.</summary>
		private void initializeLogSession() {
			writeLogInternal(logLevel.Info, "Application started");
			logDepthIncrease();

			//Environmentvariables
			writeKeyValue("Version (Application)", Assembly.GetExecutingAssembly().GetName().Version.ToString());
			writeKeyValue("Version (OS)", Environment.OSVersion.VersionString);
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

		/// <summary>Exists the Logsession</summary>
		public void finalizeLogSession() {
			logDepthReset();
			writeLogInternal(logLevel.Info, string.Format("Application exited\r\n{0}", _seperator));
		}

		/// <summary>Increases Indentation.</summary>
		public void logDepthIncrease() {
			_logDepth++;
		}
		/// <summary>Decreases Indentation.</summary>
		public void logDepthDecrease() {
			if (_logDepth > 0)
				_logDepth--;
		}
		/// <summary>Resets the Indentation.</summary>
		public void logDepthReset() {
			_logDepth = 0;
		}

		/// <summary>Create Tabs based on Indentation.</summary>
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

			//Do nothing if logging is turned off
			if (!_session.Settings.enableLogging)
				return;

			//Create Logdirectory
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