using System;
using System.Collections.Generic;
using System.Web;

public static class MasterDefinition
{
	/// <summary>Eine Liste mit Dateinamen die nicht heruntergeladen werden dürfen</summary>
	public static List<string> blockedFiles { get { return new List<string>(new string[] { "downloads.xml" }); } }
	public static string mailAddressHtml { get { return "<a href=\"mailto:mail@maximiliankrauss.net\">mail@maximiliankrauss.net</a>"; } }
	public static string setupFileName { get { return "updateSystem.NET.Setup.exe"; } }
	public static string oldSetupFileName { get { return "updateSystem.NET.1.1.90.Setup.exe"; } }
	public static string previewFilename { get { return "updateSystem.NET_preview.zip"; } }
	public static string pageName { get { return "updateSystem.NET BETA"; } }

	public static string samplesCSharp { get { return "Example_CSharp.zip"; } }
	public static string samplesVB { get { return "Example_VB.zip"; } }

	public static string Documentation { get { return "updateSystemDotNet.Controller.Doku.zip"; } }

	public static bool showGlobalNotification { get { return true; } }
	//public static string globalNotificationText { get { return "<strong>18.09.2011:</strong> <a href=\"/Download/\">Erste Betaversion vom updateSystem.NET 1.6 veröffentlicht.</a>"; } }
	public static string globalNotificationText { get { return "<strong>Achtung:</strong> Diese Version befindet sich noch in der Entwicklung und sollte nicht produktiv genutzt werden."; } }

	public static Version webVersion { get { return new Version(2, 1, 0, 0); } }

}