using System.Reflection;
using System.Resources;
using System.Threading;

namespace updateSystemDotNet.Updater {
	/// <summary>
	/// Klasse zur Verwaltung von Sprachen
	/// </summary>
	internal class Language {
		private static ResourceManager res_man;

		/// <summary>
		/// Initialisiert den ResourceManager zum auslesen der Sprache
		/// </summary>
		/// <param name="language">Die Sprache die ausgelesen werden soll</param>
		public static void Set_Language(Languages language) {
			switch (language) {
				case Languages.Auto:
					if (Thread.CurrentThread.CurrentCulture.Name.StartsWith("de")) {
						res_man = new ResourceManager("updateSystemDotNet.Updater.Localization.language.deu",
						                              Assembly.GetExecutingAssembly());
					}
					else {
						res_man = new ResourceManager("updateSystemDotNet.Updater.Localization.language.eng",
						                              Assembly.GetExecutingAssembly());
					}
					break;
				case Languages.Deutsch:
					res_man = new ResourceManager("updateSystemDotNet.Updater.Localization.language.deu",
					                              Assembly.GetExecutingAssembly());
					break;
				case Languages.English:
					res_man = new ResourceManager("updateSystemDotNet.Updater.Localization.language.eng",
					                              Assembly.GetExecutingAssembly());
					break;
			}
		}

		/// <summary>
		/// Gibt den entsprechenden String anhand der festgelegten Sprache wieder
		/// </summary>
		/// <param name="ID">Die ID zu welcher der passende Languagestring zurückgegeben werden soll</param>
		/// <returns></returns>
		public static string GetString(string ID) {
			try {
				if (res_man == null)
					Set_Language(Languages.Auto);

				return res_man.GetString(ID);
			}
			catch {
				return "Unkown translation:" + ID;
			}
		}
	}
}