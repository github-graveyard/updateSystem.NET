<%@ Page Title="{appname} - Hilfe - Asynchrone Updatesuche" Language="C#" MasterPageFile="~/Layout/help.master" AutoEventWireup="true" CodeFile="updateCheckAsync.aspx.cs" Inherits="Help_updateCheck_updateCheckAsync" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter.Net20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHelpBody" Runat="Server">
    <h2>Im Hintergrund nach Aktualisierungen suchen und diese Installieren</h2>
    <p>
        Sie können die Updatesuche natürlich auch im Hintergrund durchführen lassen und Ihre Benutzer nur Benachrichtigen, wenn auch wirklich Aktualisierungen verfügbar sind.
    </p>
    <p>
        Dazu stellt Ihnen der <span class="dotnetComponent">updateController</span> die Methode <span class="dotnetMethod">checkForUpdatesAsync</span> zur Verfügung.
    </p>
    <p>
        Mit dieser sucht der updateSytem.NET updateController automatisch im Hintergrund nach Aktualisierungen, ohne dabei die Ausführung Ihrer Anwendung zu unterbrechen.
    </p>
    <p>
        Es gibt zwei Events welche von dieser Methode heraus gefeuert werden:
    </p>
    <ul>
        <li><span class="dotnetEvent">checkForUpdatesCompleted</span> - Wird immer am Ende der Updatesuche aufgerufen und enthällt dabei evtl. aufgetretene Fehler.</li>
        <li><span class="dotnetEvent">updateFound</span> - Wird nur aufgerufen wenn Aktualisierungen gefunden wurden und enthällt in den EventArgs das Updateresult.</li>
    </ul>
    <p>
        Wurden Aktualisierungen gefunden wurden, können Sie diese auch im Hintergrund herunterladen lassen. Dazu gibt es im <span class="dotnetComponent">updateController</span> die Methode<span class="dotnetMethod">downloadUpdates</span>.
    </p>
    <p>
        Diese Methode feuert ebenfalls zwei Events:
    </p>
    <ul>
        <li><span class="dotnetEvent">downloadUpdatesProgressChanged</span> - Wird aufgerufen, wenn sich der Fortschritt des Downloads ändert. Über die EventArgs ist der Gesammtfortschritt in Prozent zu entnehmen.</li>
        <li><span class="dotnetEvent">downloadUpdatesCompleted</span> - Wird aufgerufen, wenn der Download abgeschlossen- oder durch einen Fehler unterbrochen wurde. Die Exception kann den EventArgs entnommen werden.</li>
    </ul>
    <p>
        Ist die Updatesuche und der Download abgeschlossen, müssen Sie nur noch das Update anwenden, dies geschieht mit der Methode <span class="dotnetMethod">applyUpdate</span>. Dazu noch relevant: <a href="/Help/updateCheck/closeApplication.aspx">Die Anwendung vor der Updateinstallation beenden</a>.
    </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSampleCode" Runat="Server">
<h2>Beispielcode</h2>
<pre><CH:CodeHighlighter runat="server" ID="CssCodeHighlighter" LanguageKey="C#">private void btnRunAsync_Click(object sender, EventArgs e) {
    //Events einhängen
    upctrlMain.checkForUpdatesCompleted += upctrlMain_checkForUpdatesCompleted;
    upctrlMain.updateFound += upctrlMain_updateFound;

    //Updatesuche anstoßen
    upctrlMain.checkForUpdatesAsync();
}

//Dieses Event wird in jedem Falle nach Abschluß der Updatesuche gefeuert.
//Also bei gefundenen Updates, keinen neuen Updates und auch im Fehlerfall.
private void upctrlMain_checkForUpdatesCompleted(object sender, checkForUpdatesCompletedEventArgs e) {
	upctrlMain.checkForUpdatesCompleted -= upctrlMain_checkForUpdatesCompleted;

	//Überprüfen ob ein Fehler auftrat:
	if (e.Error != null) {
		//könnte man auch ne MessageBox anzeigen, aber das ist jedem selber überlassen.
		throw e.Error;
	}
}

//Dieses Event wird ausschließlich gefeuert, wenn bei der Updatesuche neue Aktualisierungen gefunden wurden.
private void upctrlMain_updateFound(object sender, updateFoundEventArgs e) {
	upctrlMain.updateFound -= upctrlMain_updateFound;

	//Dem Benutzer anzeigen das es neue Updates gibt, dazu bauen wir uns erst den Changelog zusammen
    var sbChangelog = new StringBuilder();
	foreach (updatePackage package in e.Result.newUpdatePackages) {
		sbChangelog.AppendLine(string.Format("Änderungen in Version {0}:", package.releaseInfo.Version));
		sbChangelog.AppendLine(e.Result.Changelogs[package].germanChanges);
		sbChangelog.AppendLine();
    }

	//Neueste Version ermitteln
	string latestVersion = e.Result.newUpdatePackages[e.Result.newUpdatePackages.Count - 1].releaseInfo.Version;

	if (
		MessageBox.Show(
			string.Format(
				"Es ist für Ihre Anwendung eine neue Version verfügbar: {0}\r\nChangelog:\r\n{1}Möchten Sie das Update jetzt installieren?",
				latestVersion, sbChangelog), "Testanwendung", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
		DialogResult.Yes) {
		upctrlMain.downloadUpdatesCompleted += upctrlMain_downloadUpdatesCompleted;
		upctrlMain.downloadUpdatesProgressChanged += upctrlMain_downloadUpdatesProgressChanged;
		upctrlMain.downloadUpdates();
	}
}

//Event welches den Fortschritt des Downloads in % anzeigt.
private void upctrlMain_downloadUpdatesProgressChanged(object sender, downloadUpdatesProgressChangedEventArgs e) {
	prgDownloadProgress.Value = e.ProgressPercentage;
}

//Event welches eintritt, wenn der Download fertig ist (tritt auch bei Fehlern ein!)
private void upctrlMain_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e) {
	upctrlMain.downloadUpdatesCompleted -= upctrlMain_downloadUpdatesCompleted;
	upctrlMain.downloadUpdatesProgressChanged -= upctrlMain_downloadUpdatesProgressChanged;

	//Überprüfen ob das Update durch einen Fehler oder den Benutzer abgebrochen wurde
	if (e.Error != null)
		throw e.Error;

	//Download war erfolgreich, dann den Updateprozess starten
	upctrlMain.applyUpdate();
}</CH:CodeHighlighter></pre>
<p>
    Dieser Code stammt aus unserem C# Beispielprojekt, wenn Sie in VB.NET entwickeln finden Sie <a href="/Help/sampleProjects.aspx">hier</a> das Beispielprojekt auch in VB.NET.
</p>
</asp:Content>

