<%@ Page Title="{appname} - Hilfe - Zum Projekt hinzufügen (Code)" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="addToProjectCode.aspx.cs" Inherits="Help_Integration_addToProjectCode" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter.Net20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
	<h2>updateController im Programmcode benutzen</h2>
	<h3>Referenz hinzufügen</h3>
	<p>
		Als erstes benötigen Sie einen Verweis auf den updateController. Öffnen Sie den Dialog zum Hinzufügen von Verweisen (s. Screenshot) und wählen Sie dort aus dem Ordner <em>Deploy</em> im Programmverzeichnis des updateSystem.NET die Datei <em>updateSystemDotNet.Controller.dll</em> aus.
	</p>
	<p>
		<img src="/Images/Help/Integration/addReference.png" alt="Verweis hinzufügen" />
	</p>

	<h3>Ein Objekt vom updateController erzeugen</h3>
	<p>
		Auch hier hilft Ihnen die updateSystem.NET Administration. Öffnen Sie Ihr Updateprojekt und wählen Sie auf der Übersichtsseite "Projekteinstellungen kopieren".<br />
		In dem neuen Dialog wählen Sie als Zielumgebung die Programmiersprache aus, in welcher Sie Ihr Projekt umgesetzt haben (C# oder VB.NET) und können dann den automatisch generierten und vorkonfigurierten Quellcode in Ihr Projekt kopieren.
	</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
	<h3>Beispielquelltext</h3>
    <pre><CH:CodeHighlighter runat="server" ID="CssCodeHighlighter" LanguageKey="C#">//updateController Objekt initialisieren
updateSystemDotNet.updateController updController = new updateSystemDotNet.updateController();
updController.updateUrl = "https://updates.updatesystem.net/test/public/";
updController.projectId = "c82eae0f-bb7f-41ca-afbb-5872936da2e8";
updController.publicKey = "<RSAKeyValue><Modulus>oINe10tbBszLkGHLqlPskR6Xi+v34vVbiA/YdUn2DNfw1cUcdya3PDmkk2MBppfpWQTvqgbloOwS8IOj4dfqgudEkuSl3GmdD0fglEhC70PZhesqu/EVcaqZwlmiIkUA9dJtHXIQaZpbIKkDOsoMrNqyT+PBcOR3L0C35wTrERKcHQywQVjG9m7OWbkqRCIKeA+3nWB+x2p7XAyjdn/rVixQgXI8qXOyLNiGdbqPmzvPy83APstkgeFx1xgoVOsbbkhzavAXMztOcb1+iX8PIb3gQ5d6z3hPmILOuEHn5JklF1GfDFotEnG8QyQvHCP46kBYi26y3dLorLC4V8w8UQChCdYOpRiGPnQtwJZjzsTeVfhx5kEQ30eBUA2jeNO4/skk91GA1ekPfw02dg1isvrUUWpiNh97c1JMEhVrGbM5Ke6BnXY6MD0l6QmgaMsCe3VpkQ5lg1kyNeXnXUMz8t/kPC1Af7IEwryt5zAldJGNikZn2i0IoDEc+F0AeGe1927+v3c7nxZBeObOAohLc6zrvEOb+WnZzaAAdMTqOmSSbM7YbFTHCCzodPN/44DO+TWFXXpkLWJCpQcsjjrzKGy6VznHKWX9xkJeVbfgpt170P47bm2d3fMgpumZp4Yo1iTnLOf6IyKbvXnofxtui6KpJvI2HpHjIoaWAvtgfhU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

//Releasefilter setzen, per Default wird nur nach finalen Versionen gesucht:
updController.releaseFilter.checkForFinal = true;
updController.releaseFilter.checkForBeta = false; //Betaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.
updController.releaseFilter.checkForAlpha = false; //Alphaversionen in die Suche mit einbeziehen? Wenn ja dann auf true setzen.

//Anwendung nach dem Update neustarten?
updController.restartApplication = true;

//Wie soll die lokale Version ermittelt werden?
updController.retrieveHostVersion = true; //Empfohlen, damit wird automatisch die Assemblyversion ermittelt.
//Die Version kann allerdings auch manuell gesetzt werden:
//z.B.: updController.releaseInfo.Version = "1.2.3.4";

//Einfacher Aufruf der Updatesuche:
//updController.updateInteractive();
}</CH:CodeHighlighter></pre>
</asp:Content>

