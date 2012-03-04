<%@ Page Title="{appname} -> Hilfe -> Die Anwendung vor dem Update beenden" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="closeApplication.aspx.cs" Inherits="Help_updateCheck_closeApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
	<h2>Möglichkeiten die Anwendung vor der Installation der Updates zu beenden</h2>
	<p>
		Wenn Sie Ihre Anwendung aktualisieren möchten, muss diese nach dem Herunterladen der Updatepakete geschlossen werden, damit die Programmdateien auch Ornungsgemäß überschrieben werden können.<br />
		Das updateSystem.NET bzw. der updateController bietet Ihnen zwei Möglichkeit dies komfortabel zu erledigen.
	</p>
	<h3>Das updateInstallerStarted-Event</h3>
	<p>
	    Das Event <span class="dotnetEvent">updateInstallerStarted</span> wird vom updateController ausgelöst, nachdem der Updater gestartet wurde. Sie können es abonieren um selbstständig Ihre Anwendung vor dem Update sicher beenden zu können.
	</p>
	<h3>Die autoCloseHostApplication-Property</h3>
	<p>
	    Wenn Ihre Anwendung beim Beenden keine weiteren Aktionen erfordert (z.B. speichern von Einstellungen etc.) können Sie auch die Eigenschaft <span class="dotnetProperty">autoCloseHostApplication</span> des updateControllers auf <em>True</em> setzen.
	</p>
	<p>
	    Ist diese Eigenschaft gesetzt übernimmt der updateController das schließen Ihrer Anwendung, Sie müssen dann nicht das oben genannte Event behandeln.
	</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
</asp:Content>

