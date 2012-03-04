<%@ Page Title="{appname} - Hilfe - Zum Projekt hinzufügen (WinForms)" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="addToProjectWinForms.aspx.cs" Inherits="Help_Integration_addToProjectWinForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
	<h2>updateController auf einem Formular platzieren</h2>
	<ul>
		<li>
			<strong>Vorbereitung</strong><br />
			Sie benötigen in Ihrer ToolBox im VisualStudio die updateController-Komponente. Diese wird bei der Installation nicht automatisch hinzugefügt, so dass Sie dies einmalig selber tuen müssen.<br />
			Der einfachste Weg ist die <em>updateSystemDotNet.Controller.dll</em> aus dem Ordner <em>Deploy</em>  im Programmverzeichnis des updateSystem.NET (üblicher Weise <em>C:\Program Files\updateSystem.NET\</em>) via Drag&Drop in die ToolBox des VisualStudio zu ziehen.
		</li>
		<li>
			<strong>Schritt 1: Platzieren Sie ein updateController-Objekt auf Ihrer Form</strong><br />
			Ziehen Sie das Objekt <em>updateController</em> aus der ToolBox auf die Form im Visual Studio Designer, auf welche Sie die Updatesuche implementieren möchten.
		</li>
		<li>
			<strong>Schritt 2: Kopieren Sie die Projekteinstellungen</strong><br />
			Sie können die essentiel für die Updatesuche benötigten Informationen halbwegs automatisch aus der Administration in Ihr Projekt kopieren.<br />
			Dafür öffnen Sie Ihr Projekt mit der updateSystem.NET Administration, wählen auf der Übersichtsseite "Projekteinstellungen kopieren", lassen in dem erscheinenden Dialog die erste Option <em>WindowsForms Designer</em> aktiviert und folgen dann den Anweisungen zum Kopieren der Einstellungen.
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>