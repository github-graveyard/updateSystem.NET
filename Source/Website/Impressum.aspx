<%@ Page Title="{appname} - Impressum" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="Impressum.aspx.cs" Inherits="Impressum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Inhaltlich Verantwortlicher gem. § 10 Absatz 3 MDStV:</h2>
	<p>
		<strong>Maximilian Krau&szlig;</strong><br />
		Ossietzkystr. 8<br />
		D-13187 Berlin
	</p>
	<p>
		E-Mail: <%= MasterDefinition.mailAddressHtml %>
	</p>
	<p>
		Alle auf dieser Website genannten Produktnamen, Produktbezeichnungen und Logos sind eingetragene Warenzeichen und Eigentum der jeweiligen Rechteinhaber.
	</p>
	<h3>Danke:</h3>
	<ul>
		<li>Das updateSystem.NET (Anwendung und Website) nutzt das Fugue Icons Package von <a href="http://p.yusukekamiyamane.com/" target="_blank">Yusuke Kamiyamane</a>, lizenziert unter der <a href="http://creativecommons.org/licenses/by/3.0/" target="_blank">Creative Commons Attribution 3.0 license</a></li>
		<li>Alle Screenshots wurden mit <a href="http://shotty.devs-on.net">Shotty</a> erstellt. Dem besten Werkzeug zum Erstellen und Upload qualitativ Hochwertiger Screenshots.</li>
		<li>This web site uses Actipro CodeHighlighter (http://www.CodeHighlighter.com).</li>
	</ul>
</asp:Content>