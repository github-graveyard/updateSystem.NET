<%@ Page Title="{appname} - Hilfe - Automatische Updatesuche- und Installation" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="updateInteractive.aspx.cs" Inherits="Help_updateCheck_updateInteractive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
	<h2>Automatische Updatesuche und Installation</h2>
	<p>
		Die einfachste Methode um nach Updates zu suchen, diese dem Benutzer anzuzeigen, herunterzuladen und zu installieren ist der Aufruf der Methode <span class="dotnetMethod">updateInteractive</span> des updateControllers.
	</p>
	<p>
	    Diese Methode ruft alle Dialoge selbstständig auf und startet nach dem Download direkt den Updatevorgang.
	</p>
	<h3>Siehe auch..</h3>
	<ul>
		<li><a href="/Help/updateCheck/closeApplication.aspx">Die Anwendung vor der Updateinstallation beenden</a></li>
		<li><a href="/Help/sampleProjects.aspx">Beispielprojekte in VB.NET und C#</a></li>
	</ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>