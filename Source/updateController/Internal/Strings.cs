namespace updateSystemDotNet.Internal {
	internal class Strings {
		/// <summary>
		/// Der Titel der in Nachrichtenfelder etc angezeigt werden soll
		/// </summary>
		public const string AppTitle = "updateSystem.NET";

		/// <summary>
		/// Der Registry-Path an welchem die Orte der PoolAssemblies gespeichert werden mit HKCU
		/// </summary>
		public const string CompleteAppRegHive = @"HKEY_CURRENT_USER\Software\updateSystem.NET\LastUpdateChecks\";

		/// <summary>
		/// Der Registry-Path an welchem die Orte der PoolAssemblies gespeichert werden ohne HKCU
		/// </summary>
		public const string AppRegHive = @"Software\updateSystem.NET\LastUpdateChecks\";
	}
}