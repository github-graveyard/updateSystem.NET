<%@ Page Title="{appname} - Dokumentation" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="Documentation.aspx.cs" Inherits="Help_Documentation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
    <h2>Schnittstellendokumentation</h2>
    <p>
        Hier können Sie sich die Schnittstellendokumentation des updateControllers herunterladen, welche eine Beschreibung aller öffentlichen Klassen, Methoden und Eigenschaften enthält.
    </p>
    <p>
        <asp:LinkButton CssClass="download_zip" Text="Herunterladen" runat="server" 
            ID="lnkDownload" onclick="lnkDownload_Click"></asp:LinkButton>
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>

