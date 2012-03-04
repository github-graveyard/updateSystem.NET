<%@ Page Title="{appname} - Roadmap" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="Roadmap.aspx.cs" Inherits="Download_RoadMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
	<h2>Roadmap</h2>
	<p>
		Hier finden Sie Informationen über Funktionen und Fixes die für spätere Versionen des updateSystem.NET geplant sind.
	</p>
	<div id="roadmap">
		<h3>Version 2.0 (Geplantes Release: Q1/2012)</h3>
		<ul class="roadmapEntries">
			<li class="roadmapPlannend">Updateservice (Installation von Updates ohne UAC-Elevation)</li>
			<li class="roadmapPlannend">Statistikanzeige über Website.</li>
			<li class="roadmapPlannend">Veröffentlichen von Updates ohne FTP Zugang ermöglichen</li>
			<li class="roadmapPlannend">Mehrsprachige Administrationsoberfläche</li>
		    <li class="roadmapPlannend">Eigene Updateaktionen</li>
		</ul>
		<h3>Version 1.6 (Geplantes Release Q2/2011)</h3>
		<ul class="roadmapEntries">
			<li class="roadmapPlannend">Verbesserter updateInstaller</li>
			<li class="roadmapPlannend">updateAction zum erstellen von Verknüpfungen</li>
			<li class="roadmapInProgress">Verbessertes UI für die Built-In Updatedialoge</li>
			<li class="roadmapPlannend">Templates für Updatepakete</li>
			<li class="roadmapPlannend">Aktualisierung der Anwendung im laufenden Betrieb mittels ShadowCopy</li>
			<li class="roadmapPlannend">Auf erhöhte DPI Werte optimierte Dialoge</li>
		</ul>
		<h3>Legende</h3>
		<ul class="roadmapEntries">
			<li class="roadmapCompleted">= Abgeschlossen/Implementiert</li>
			<li class="roadmapInProgress">= In Bearbeitung</li>
			<li class="roadmapPlannend">= Geplant</li>
			<li class="roadmapDisposed">= Verworfen</li>
		</ul>
	</div>

</asp:Content>