<%@ Page Title="updateSystem.NExT" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Next_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <h2>updateSystem.NExT</h2>
    <div style="text-align: center;">
        <img src="../Images/Next/preview_shot.png" alt="Preview Image"/>
    </div>
    <h3>Um was geht's?</h3>
    <p>
        updateSystem.NExT bietet die Möglichkeit frühe Versionen der kommenden, neuen Version des updateSystem.NET zu testen.
    </p>
    <h3>Was ist neu?</h3>
    <ul>
        <li>
            <strong>Ein FTP Server ist nicht mehr zwingend notwendig</strong><br />
            Mit der neuen Version benötigt man zum Erstellen von Updates nicht mehr zwingend einen FTP-Server. Die Updates werden in jedem Fall erstmal lokal angelegt und können dann beliebig weiter ins Dateisystem verschoben- und/oder per FTP Veröffentlicht werden.
        </li>
        <!--<li>
            <strong>Der updateController unterstützt lokale- und Netzwerkfreigaben</strong><br />
            Im Zuge der Änderungen der Veröffentlichungsmethoden der Administration wird der updateController auch mit UNC-Pfaden kompatibel werden.
        </li> -->
        <li>
            <strong>Verbessertes Interface der Built-In Dialoge des updateControllers</strong><br />
            <img src="../Images/Next/new_updateUI.png" alt="Neue Updateoberfläche" style="padding-top: 10px; padding-bottom:10px;"/>
        </li>
        <li>
            Eine Übersicht aller geplanten und bereits Umgesetzten Änderungen finden Sie in der offiziellen <a href="https://bugs.devs-on.net/Issues/IssueList.aspx?pid=1&m=2" target="_blank">Roadmap</a>.
        </li>
    </ul>
    <h3>Testversion herunterladen</h3>    
    <p>
        Diese Version des updateSystem.NET ist <em>ausschließlich</em> zum Testen gedacht. Auch wenn das elementare Funktionen zum Erstellen und Veröffentlichen von Updates schon implementiert sind, ist von dem produktiven Gebrauch abzuraten.
    </p>
    <p style="text-align: center;">
        <asp:button runat="server" ID="btnDownloadPreview" Width="140" Height="30" 
            Text="Herunterladen" onclick="btnDownloadPreview_Click" />
    
        <asp:Label runat="server" ID="lblDownloads" ></asp:Label> Downloads
    </p>
    <h3>Hinweis</h3>
    <p>
        Einige Features sind noch nicht- bzw. erst Teilweise implementiert. Sie brachen dadurch resultierende Fehler nicht melden, da diese bekannt sind und in späteren Versionen bereits behoben sind.
    </p>
    <h3>Feedback</h3>
    <p>
        Bitte senden Sie jegliches Feedback über das integrierte Formular in der updateSystem.NET Administration.
    </p>
</asp:Content>

