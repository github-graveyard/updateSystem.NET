<%@ Page Title="{appname} - FTP loggen" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="logFtp.aspx.cs" Inherits="Help_Troubleshooting_logFtp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
    <h2>Die FTP-Kommunikation aufzeichnen</h2>
    <p>
        Wenn Sie mit der updateSystem.NET Administration anhaltende Probleme mit der Verbindung über FTP haben, dann gibt es die Möglichkeit die Verbindungsdaten zu protokolieren.
    </p>
    <p>
        Um das loggen zu aktivieren muss die <em>updateSystemDotNet.Administration.exe</em> mit dem Parameter <em>/log</em> gestartet werden. Dafür können Sie z.B. eine neue Verknüpfung auf die Datei erstellen und in deren Eigenschaften unter <em>Verknüpfung/Ziel</em> den Parameter hinzufügen:
    </p>
    <p class="content_center">
        <img src="/Images/Help/Troubleshooting/administratin_log_shortcut.png" alt="Verknüpfung - Log" />
    </p>
    <p>
        Danach werden alle ausgehenden und eingehenden FTP-Befehle in der Datei <em>administration_ftp.log</em> auf Ihrem Desktop gespeichert.<br />
        Diese Datei enthällt <strong>keine</strong> Passwörter, dafür URL/IP und den Port des FTP-Servers, das Verzeichnis in welchem die Updates gespeichert werden und den Benutzernamen.
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>

