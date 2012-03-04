<%@ Page Title="{appname} - Hilfe - Schritt für Schritt Anleitung" Language="C#" MasterPageFile="~/Layout/web.master" AutoEventWireup="true" CodeFile="StepByStep.aspx.cs" Inherits="Help_StepByStep" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter.Net20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" Runat="Server">
    <h2>Schritt für Schritt Anleitung</h2>
    <p>
        Diese Anleitung wird Sie Schritt für Schritt durch das Einrichten eines neuen Updateprojektes, dem hinzufügen des updateSystem.NET zu Ihrem Projekt und dem Erstellen eines ersten Updates führen.
    </p>
    <h3>Das updateSystem.NET herunterladen und installieren</h3>
    <p>
        Laden Sie sich die aktuelle Version des updateSystem.NET <a href="/Download/" target="_blank">hier</a> herunter und folgen Sie den Anweisungen des Installationsassistenten.
    </p>
    <p class="content_center">
        <img src="/Images/Help/StepByStep/StartMenu.png" alt="updateSystem.NET im StartMenu" />
    </p>
    <p>
        Nach der Installation finden Sie im Startmenu einen neuen Eintrag <em>"updateSystem.NET Administration"</em> über diesen Sie die Administrationsoberfläche starten können.
    </p>
    <h3>Ein neues Updateprojekt erstellen</h3>
    <p>
        Nachdem Sie die Administration gestartet haben klicken Sie auf der linken Seite auf <em>"Neues Projekt"</em>. Dies öffnet einen Assistenten welcher in mehreren Schritten Informationen sammelt die zum Erstellen eines Updateprojektes notwendig sind.
    </p>
    <ul>
        <li>
            <strong>Schritt 1: Allgemeine Projektinformationen</strong>
            <p>
                <em>Name der Anwendung:</em> Geben Sie hier den Namen Ihrer Anwendung an, dieser erscheint in fast allen Dialogen die der updateController später während der Updatesuche anzeigt.<br />
                <em>Update-Url:</em> Dies ist die HTTP-URL über welche die Updates abgerufen werden. Diese muss auf <strong>das gleiche</strong> Verzeichnis zeigen, welches Sie in Schritt 3 bei Ihren FTP-Serverdaten angegeben haben.<br />
                <em>Projektdateiname:</em> Dies ist der vollständige Pfad zu der Projektdatei welche während dem Einrichten erzeugt wird und alle Informationen beinhaltet die benötigt werden um Ihr Updateprojekt öffnen zu können.
            </p>
        </li>
        <li>
            <strong>Schritt 2: Statistiken</strong>
            <p>
                Hier können Sie einen Statistikserver festlegen welcher mit Ihrem Projekt verknüpft werden kann, um Daten über die Anzahl von Updateanfragen und Downloads zu erfassen. Diese Einstellung ist optional und wird in dieser Schnellstartanleitung nicht weiter behandelt, weitere Informationen über den Gebrauch der Statistikdienste finden Sie in der <a href="/Help/">Hilfe</a>.
            </p>            
        </li>
        <li>
            <strong>Schritt 3: Den FTP-Server konfigurieren</strong>
            <p>
                Das updateSystem.NET veröffentlicht die Updatekonfiguration sowie die Updatepakete direkt über FTP.<br />
                In diesem Schritt legen Sie nun die Zugangsdaten zu Ihrem FTP-Server sowie das Verzeichnis fest, in welches die Updatedaten hochgeladen werden sollen.
            </p>
        </li>
        <li>
            <strong>Schritt 4: </strong>
            <p>
                In diesem Schritt richtet der Assistent alle benötigten Verzeichnisse und Dateien auf Ihrem FTP-Server ein. Nachdem der Vorgang erfolgreich abgeschlossen wurde, öffnet ein Klick auf <em>"Weiter"</em> das neu angelegte Updateprojekt.
            </p>
        </li>
    </ul>
    <h3>Ihr Projekt Updatefähig machen</h3>
    <p>
        Nun müssen Sie in Ihrem Projekt ein updateController-Objekt erstellen, um Updates suchen und installieren zu können. Dies geht entweder über den <a href="/Help/Integration/addToProjectWinForms.aspx" target="_blank">Windows Forms Designer</a> oder per <a href="/Help/Integration/addToProjectCode.aspx" target="_blank">Code</a>.
    </p>
    <h3>Das erste Updatepaket erstellen</h3>
    <p>
        Öffnen Sie Ihr angelegtes Updateprojekt mit der updateSystem.NET Administration (z.B. über einen Doppelklick auf die Projektdatei). Wechseln Sie in den Tab <em>Updatepakete</em> und wählen Sie <em>Hinzufügen</em>.
    </p>
    <div class="sbs_diff">
        <p>
            Auf der ersten Dialogseite müssen Sie allgemeine Informationen über die Versionsinformationen des neuen Updatepaketes angeben:
        </p>
        <p class="content_center">
            <img src="/Images/Help/StepByStep/updatepackage_general.png" alt="Neues Updatepaket - Allgemein" />
        </p>
        <ul>
            <li>
                <strong>Version:</strong> Dies ist die Versionsnummer die dieses Updatepaket tragen soll, in unserem Beispiel 2.0.0.0.
            </li>
            <li>
                <strong>Releasestatus:</strong> Hier können Sie einen aus drei verschiedenen Typen (<em>Final, Beta, Alpha</em>) wählen, welcher dem aktuellen Entwicklungsstand Ihres Projektes und den Dateien welche Sie über das Update ausliefern möchten am besten entspricht.<br />
                Entscheiden Sie sich für Beta oder Alpha können Sie neben der Auswahlbox noch eine Zahl festlegen, um die wievielte Vorabversion es sich handelt. Diese Angabe wird auch bei der Updatesuche berücksichtigt.
            </li>
            <li>
                <strong>Architektur:</strong> Mit dieser Einstellung können Sie festlegen, für welche Prozessorarchiktekturen das Update verfügbar sein soll. Der Standardwert ist <em>"Unabhängig"</em>, Sie können die Verfügbarkeit jedoch auf 32-Bit (x86) oder 64-Bit (x64) Betriebssystemarchitekturen einschränken.
            </li>
            <li>
                <strong>Beschreibung:</strong> Dies ist eine interne Beschreibung des Updatepaketes, Sie ist für den Benutzer welchem das Updateangezeigt wird nicht ersichtlich.
            </li>
            <li>
                <strong>Veröffentlicht:</strong> Aktivieren Sie diese Option, wenn das Updatepaket als verfügbar gekennzeichnet werden- und damit allen Clients zum Download bereitstehen soll.
            </li>
            <li>
                <strong>Service Pack:</strong> Mit dieser Option markieren Sie das Updatepaket als Service Pack. Dies hat zur Auswirkung, dass alle Updates, welche einen niedrigeren Releasestatus als dieses Update haben, bei der Updatesuche nicht berücksichtigt werden.
            </li>
        </ul>
    </div>
    <div class="sbs_diff2">
        <p class="content_center">
            <img src="/Images/Help/StepByStep/updatepackage_changelog.png" alt="Neues Updatepaket - Changelog" />
        </p>
        <p>
            Im Bereich <em>Änderungen</em> geben Sie die Änderungen an, die dieses Updatepaket im Gegensatz zu der alten Version beinhaltet. Sie können im oberen Bereich zwischen Deutsch und Englisch wählen bzw. die Änderungen in beiden Sprachen verfassen.
        </p>
    </div>
    <div class="sbs_diff">
        <p class="content_center">
            <img src="/Images/Help/StepByStep/updatepackage_actions.png" alt="Neues Updatepaket - Updateaktionen" />
        </p>
        <p>
            Unter dem Punkt <em>Aktionen</em> finden Sie alle Updateaktionen die Sie in diesem Updatepaket verwenden können. Ziehen Sie die gewünschte Aktion einfach via Drag and Drop auf den Punkt <em>Aktionen</em> oder klicken Sie doppelt auf einen Eintrag um diesen Hinzuzufügen und dessen Konfigurationsseite zu öffnen.
        </p>
        <p>
            Hier können Sie nun die Aktionen aussuchen, die für ihr Update erforderlich sind, wenn Sie nur Programmdateien austauschen wollen, benötigen Sie ausschließlich die Aktion <em>Dateien kopieren oder ersetzen</em>.
        </p>
    </div>
    <div class="sbs_diff2">
        <p class="content_center">
            <img src="/Images/Help/StepByStep/updatepackage_filecopyaction.png" alt="Neues Updatepaket - Dateien kopieren" />
        </p>
        <p>
            Die Updateaktion <em>Dateien kopieren oder ersetzen</em> ist die Aktion, welche am häufigsten benötigt wird, da sie die neuen Programmdateien enthällt.
        </p>
        <p>
            Um die Daten Ihrer Anwendung zu aktualisieren, wählen Sie den Ordner <em>Programmverzeichnis</em> aus und klicken Sie entweder auf <em>Dateien hinzufügen</em> oder <em>Ordner hinzufügen</em>.<br />
            Wenn Sie einen neuen Ordner anlegen möchten, können Sie dies über einen Rechtsklick auf einen Ordner in der Verzeichnisansicht tun.
        </p>
    </div>
    <div class="sbs_diff">
        <p>
            Jetzt sollten Sie alle Informationen zusammen haben, um das erste Updatepaket erstellen zu können. Sie haben die Version festgelegt, angegeben was sich in dieser Version alles geändert hat und die neuen Dateien hinzugefügt. Klicken Sie jetzt auf <em>Updatepaket erstellen</em> um Ihr neues Update zu erstellen und hochzuladen.
        </p>
    </div>    
    <h3>Nach Updates suchen und diese Installieren</h3>
    <p>
        Nun muss nur noch die Updatesuche und Installtion in Ihrer Anwendung angestoßen werden. Dies können Sie z.B. über einen Klick auf einen Button oder beliebig anders auslösen.
    </p>
    <p>
        Das unten ausgeführte Codebeispiel gibt die einfachste Art wieder, um Ihre Anwendung automatisch zu aktualisieren, Sie können den Updatevorgang natürlich noch weiter nach Ihren Wünschen gestalten, Anleitungen und Beispiele dazu finden Sie in der <a href="/Help/">Hilfe</a> und in dem Quellcode der <a href="/Help/sampleProjects.aspx">Beispielanwendungen</a>.
    </p>
    <div id="helpContents">
        <pre><CH:CodeHighlighter runat="server" ID="CssCodeHighlighter" LanguageKey="C#">private void btnRunUpdateInteractive_Click(object sender, EventArgs e) {

    //Automatisch die zu aktualisierende Anwendung schließen
    upctrlMain.autoCloseHostApplication = true;

    //Updatesuche starten
    upctrlMain.updateInteractive(this);
}</CH:CodeHighlighter></pre></div>
   
</asp:Content>

