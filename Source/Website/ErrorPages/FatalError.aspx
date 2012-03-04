<%@ Page Title="{appname} - Serverfehler" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="FatalError.aspx.cs" Inherits="ErrorPages_FatalError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Aw Snap, ein Serverfehler!</h2>
	<p>Ohje, hier ist etwas komplett Schiefgegangen.</p>
	<p>Bitte versuchen Sie den Vorgang erneut auszuführen, wenn der Fehler weiterhin auftritt, teilen Sie bitte dem Entwickler dieses Problem
	über die folgende E-Mailadresse mit:<br />
	<%= MasterDefinition.mailAddressHtml %> </p>
	<h3>Fehlermeldung</h3>
	<p><asp:Label runat="server" ID="lblMessage" Text="Nicht verfügbar"></asp:Label></p>
	<h3>Stacktrace</h3>
	<p><asp:Label runat="server" ID="lblStackTrace" Text="Nicht verfügbar"></asp:Label></p>
</asp:Content>