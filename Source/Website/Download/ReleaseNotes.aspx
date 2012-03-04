<%@ Page Title="{appname} - Release Notes" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="ReleaseNotes.aspx.cs" Inherits="Download_ReleaseNotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Release Notes</h2>
	<p>
		Hier finden Sie in chronologisch absteigender Reihenfolge alle Änderungen die in den jeweiligen Versionen des updateSystem.NET implementiert wurden.
	</p>
	<div id="releasenotes">
		<a id="latest"></a><h3>Änderungen in der Version 1.5.1.xxxx (Noch nicht veröffentlicht!)</h3>
		<ul class="changes">
			<li class="feature"><em>updateDesigner</em> umbenannt in <em>Administration</em>.</li>
			<li class="feature">Komplett neue Oberfläche der Administration.</li>
			<li class="feature">Verbesserte Fehlerbehandlung.</li>
			<li class="feature">Neue und stabilere FTP Engine.</li>
			<li class="feature">Es kann zwischen FTP/SSL Implizit und FTP/SSL Explizit gewählt werden.</li>
			<li class="feature">Neben einer passiven FTP Verbindung kann nun auch eine aktive genutzt werden.</li>
			<li class="feature">Der Schlüssel zur Signatur der Updatepakete und der Updatekonfiguration ist nun 4096-Bit stark (vorher 1024 Bit).</li>
			<li class="feature">Überarbeitete actionEditoren.</li>
			<li class="feature">Die Administration merkt sich die Größe der Spalten in der Updateübersicht.</li>
			<li class="feature">Es lässt sich mehr als ein Updatepaket gleichzeitg löschen.</li>
			<li class="feature">Beim Erstellen eines neuen Ordner in der fileCopyAction können direkt verschachtelte Strukturen angelegt werden.</li>
			<li class="feature">Die Programmeinstellungen und die (neuen) Projektdateien sind vollständig verschlüsselt.</li>
			<li class="feature">Der Dialog zum Hinzufügen eines existierenden Statistikservers erkennt automatisch den Typ des Servers (ASP.NET oder PHP)</li>
			<li class="feature">Übersichtlichere Statistikserververwaltung</li>
			<li class="bug">Skalierungsfehler bei der Anzeige der Statistikdaten behoben.</li>
			<li class="feature">.NET Assemblies können wieder automatisch während dem Update mit NGEN vorkompiliert werden</li>
			<li class="feature">Selbstgeschriebenes Setup für das updateSystem.NET</li>
			<li class="feature">Es kann eine Datei ausgewählt werden, aus welcher automatisch die Versionsnummer für neue Updates bezogen werden soll</li>
			<li class="bug">In den Built-In Dialogen vom updateController werden nun auch korrekt die erweiterten Versionsinformationen wie z.B. Alpha1 oder Beta 1 angezeigt</li>
			<li class="feature">Die Versionsnummer und der Releasestatus existierender Updatepakete kann im Nachhinein bearbeitet werden.</li>
			<li class="feature">Updatepaketen können eigene Felder hinzugefügt werden, welche von der Anwendung abgefragt werden können.</li>
			<li class="feature">Updatepakete lassen sich kopieren/klonen.</li>
			<li class="feature">Dateien können via Drag and Drop in die Aktion <em>"Dateien kopieren oder ersetzen"</em> gezogen werden.</li>
			<li class="feature">In der Updateübersicht kann nach bestimmten Updatepaketen gesucht werden.</li>
			<li class="feature">Der GetStatistic-Request wird nun mittels GZIP komprimmiert (ASP.NET only) was eine deutliche Reduzierung des Traffics zur Folge hat.</li>
			<li class="feature">Updatepakete können in der Übersicht über das Kontextmenu als Service Pack markiert werden.</li>
			<li class="feature">Die Updatepakete lassen sich auf jedem Computer bearbeiten, da die Dateien aus den FileCopyActions nun temporär heruntergeladen werden und so ein erneutes Erstellen des Updatepakets erlauben.</li>
		</ul>
		<h3>Legende</h3>
		<ul class="changes">
			<li class="bug">= Fehler behoben</li>
			<li class="feature">= Funktion hinzugefügt/verbessert</li>
		</ul>
	</div>
</asp:Content>