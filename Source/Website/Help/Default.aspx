<%@ Page Title="{appname} - Hilfe" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Help_Default" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter.Net20" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHelpBody" Runat="Server">
	<h2>Hilfethemen für das updateSystem.NET</h2>
	<p>
		Hier finden Sie Hilfe zur Einrichtung und Verwendung des updateSystem.NET.
	</p>
	<h3>Allgemein</h3>
	<ul>
	    <li>
	        <a href="/Help/StepByStep.aspx">Schritt-für-Schritt Anleitung (Veraltet)</a>
	    </li>
	    <li>
	        <a href="/Help/sampleProjects.aspx">Beispielprojekte</a>
	    </li>
	    <li>
	        <a href="/Help/Documentation.aspx">updateController Schnittstellendokumentation</a>
	    </li>
	</ul>
	<h3>Integration in Ihr Projekt</h3>
	<ul>
		<li>
			<a href="Integration/addToProjectWinForms.aspx">Den updateController Ihrem Projekt hinzufügen (Windows Forms)</a>
		</li>
		<li>
			<a href="Integration/addToProjectCode.aspx">Den updateController Ihrem Projekt hinzufügen (Code)</a>
		</li>
	</ul>
	<h3>Möglichkeiten der Updatesuche</h3>
	<ul>
		<li><a href="updateCheck/updateInteractive.aspx">Automatische Updatesuche- und Installation</a></li>
		<li>Updatesuche- und Installation</li>
		<li><a href="updateCheck/updateCheckAsync.aspx">Updatesuche- und Installation (asynchron)</a></li>
		<li><a href="updateCheck/closeApplication.aspx">Die Anwendung vor der Updateinstallation beenden</a></li>
	</ul>
	<h3>Erstellen von Updates</h3>
	<ul>
	    <li>Ein Update erstellen</li>
		<li><a href="Updates/updateActions.aspx">Was sind die updateActions?</a></li>
	</ul>
	<h3>Statistiksetup</h3>
	<ul>
		<li>Einen neuen Statistikserver einrichten</li>
		<li>Einen bestehenden Statistikserver hinzufügen</li>
		<li>Einen Statistikserver aktualisieren</li>
	</ul>
	<h3>Fehlersuche</h3>
	<ul>
	    <li>-</li>
	</ul>
	<h3>Bekannte Fehler und Lösungen</h3>
	<ul>
	    <li><a href="Misc/DotNET40ClientProfile.aspx">"Die Assembly "updateSystemDotNet.Controller", auf die verwiesen wird, konnte nicht aufgelöst werden..."</a></li>
	</ul>
	<p>
		Nicht gefunden wonach Sie gesucht haben? Dann stellen Sie Ihre Frage doch in unserem <a href="https://forum.devs-on.net/default.aspx?g=forum&c=7" target="_blank">Supportforum</a>.
	</p>
</asp:Content>
