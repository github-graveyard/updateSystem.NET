/*
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://kraussz.com> eMail: max@kraussz.com
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using System.Collections;
using System.IO;
using System;
using System.Reflection;

namespace updateSystemDotNet.Localization {
	internal sealed class localizationFile {

		private const char _keyIxSeperator = '	';
		private const char _lineSeperator = '¶';
		private readonly Encoding _encoding = Encoding.UTF8;

		private readonly Hashtable _content = new Hashtable();
		private string _language = string.Empty;

		//---------------
		//Enable this, if the App goes Live and contains only the compressed Resourcefile.
		private const bool USE_COMPRESSED_LANGUAGE_FILE = false;
		//---------------

		public ReadOnlyCollection<string> AllKeys {
			get {
				List<string> keys = new List<string>(_content.Count);
				foreach (string key in _content.Keys) {
					if (!key.StartsWith("."))
						continue;

					string locKey = key.Substring(key.IndexOf('.') + 1);
					if (!keys.Contains(locKey))
						keys.Add(locKey);
				}
				keys.Sort();
				return new ReadOnlyCollection<string>(keys);
			}
		}
		public ReadOnlyCollection<string> Languages {
			get {
				List<string> languages = new List<string>(_content.Count);
				foreach (string key in _content.Keys) {
					string langkey = key.Substring(0, key.IndexOf('.'));
					if (!languages.Contains(langkey))
						languages.Add(langkey);
				}
				languages.Sort();
				return new ReadOnlyCollection<string>(languages);
			}
		}
		public string Language {
			get { return _language; }
			set { _language = value; }
		}

		public string this[string key, string language, bool noFallback] {
			get {
				if (noFallback)
					return (string)(_content[string.Format("{0}.{1}", language, key)] ?? string.Empty);

				string value = (string)(_content[string.Format("{0}.{1}", language, key)] ?? string.Empty);
				return !string.IsNullOrEmpty(value) ? value : (string)_content["." + key];
			}
		}
		public string this[string key, string language] {
			get { return this[key, language, false]; }
		}
		public string this[string key] {
			get { return this[key, _language, false]; }
		}

		private void Load(Stream stream) {
			_content.Clear();

			using (StreamReader reader = new StreamReader(stream, _encoding)) {
				while (!reader.EndOfStream) {
					string line = reader.ReadLine();
					if(string.IsNullOrEmpty(line.Trim()))
						continue;
						
					int keyIx = line.IndexOf(_keyIxSeperator);
					string key = line.Substring(0, keyIx);
					string value = line.Substring(keyIx + 1);
					value = value.Replace(_lineSeperator.ToString(CultureInfo.InvariantCulture), Environment.NewLine);
					_content.Add(key, value);
				}
			}
		}

		public void Load(string resourcePath) {
#pragma warning disable 162
			string resourceName = string.Format( "{0}.{1}", resourcePath ,  USE_COMPRESSED_LANGUAGE_FILE ? "loc.gz" : "loc");
#pragma warning restore 162
			Stream locStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
			if (locStream == null)
				throw new InvalidOperationException(string.Format("Could not load Localizationfile! \"{0}\"", resourcePath));

			if (USE_COMPRESSED_LANGUAGE_FILE)
#pragma warning disable 162
				locStream = new GZipStream(locStream, CompressionMode.Decompress);
#pragma warning restore 162

			Load(locStream);
			locStream.Dispose();
		}
		public void Load() {
			object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (localizationFilenameAttribute), true);
			if(attributes.Length>0)
				Load((attributes[0] as localizationFilenameAttribute).Filename);
			else
				throw new Exception("Could not find localizationFilenameAttribute");
		}

		/* Backup. Maybe I need this in the future...
		 * private void loadFromFile(string filename) {
			using (var fs = File.Open(filename, FileMode.Open)) {
				Stream stream = fs;
				if (filename.EndsWith(".loc.gz"))
					stream = new GZipStream(stream, CompressionMode.Decompress);
				Load(stream);
				stream.Dispose();
			}
		}*/
	}
}