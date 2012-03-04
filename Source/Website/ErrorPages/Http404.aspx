<%@ Page Title="{appname} - Seite nicht gefunden" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="Http404.aspx.cs" Inherits="ErrorPages_Http404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Aw Snap! Ein HTTP 404 Error wurde gefunden!</h2>
	<p>
		Die Seite welche Sie aufrufen wollten wurde entweder gelöscht oder verschoben.
	</p>
	<h3>Wonach Sie evtl. gesucht haben könnten:</h3>
	<ul>
		<li><a href="/Help/">Hilfe bei der Verwendung des updateSystem.NET</a></li>
		<li><a href="/Download/">Das updateSystem.NET herunterladen</a></li>
	</ul>
	<h3>Sie haben nicht gefunden wonach Sie gesucht haben?</h3>
	<p>
		Falls Sie immernoch nicht gefunden haben, wonach Sie gesucht haben setzen Sie sich bitte direkt per eMail mit mir in Verbindung, ich helfe gern sofern Ihre Frage noch nicht in den <a href="/FAQ.aspx">F.A.Q.</a> beantwortet wurde:
	</p>
	<p>
		<a href="mailto:mail@maximiliankrauss.net">mail@maximiliankrauss.net</a>
	</p>
</asp:Content>

