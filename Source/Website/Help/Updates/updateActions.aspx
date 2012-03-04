<%@ Page Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="updateActions.aspx.cs" Inherits="Help_Updates_updateActions" Title="{appname} - Hilfe - updateActions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
    <h2>Was sind die updateActions?</h2>
    <p>
        <img style="float:right; margin-left:20px;" src="/Images/Help/Updates/updateActions.png" alt="updateActions" />
        Im updateSystem.NET gibt es sogenannte updateActions welche das Herzstück eines jeden Updatepaketes darstellen.
    </p>
    <p> 
        Die einzelnen Aktionen, wie zum Beispiel das Kopieren oder Ersetzen von Dateien oder das Beenden/Starten von Diensten, können frei in Anzahl und Reihenfolge in dem Updatepaket platziert werden. <br />
        Dadurch lässt sich der komplette Updatevorgang frei nach Ihren Anforderungen zusammenstellen.    
    </p>
    <h3>Verwendung</h3>
    <p>
        Um eine updateAction Ihrem Updatepaket hinzuzufügen, wählen Sie in dem Dialog zum Erstellen eines neuen Updatepaketes aus der Navigation den Punkt <em>Aktionen</em> aus.<br />
        Dort finden Sie dann in Gruppen aufgeteilt alle verfügbaren Updateaktionen (Bild rechts). Suchen Sie sich dort die gewünschte Aktion aus und ziehen Sie diese dann via Drag and Drop aus der Liste in die Navigation links. Alternativ führt ein Doppelklick auf eine Aktion ebenfalls zum hinzufügen der selektierten Aktion und zum sofortigen Öffnen der Aktionseinstellungen.
    </p>
    <p>
        Alle updateActions besitzen individuelle Einstellungsmöglichkeiten welche Sie durch einen Klick in der Navigation auf die entsprechende, hinzugefügte Aktion bearbeiten können.
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>