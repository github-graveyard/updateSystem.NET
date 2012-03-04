Option Strict On

Imports System.Reflection
Imports updateSystemDotNet.Core.Types
Imports updateSystemDotNet
Imports System.Text

Friend Class mainForm

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Font = SystemFonts.MessageBoxFont

        'Assemblyversion ermitteln
        lblAssemblyVersion.Text = String.Format(lblAssemblyVersion.Text, Assembly.GetExecutingAssembly().GetName().Version)

        lblReleaseInfo.Text = String.Format(lblReleaseInfo.Text, upctrlMain.releaseInfo.Type, (If(upctrlMain.releaseInfo.Type <> releaseTypes.Final, "(" + upctrlMain.releaseInfo.[Step].ToString & ")", "")))
        lblFilter.Text = String.Format(lblFilter.Text, String.Format("Final: {0}, Beta: {1}, Alpha: {2}", _
                                                                    If(upctrlMain.releaseFilter.checkForFinal, "Ja", "Nein"), _
                                                                    If(upctrlMain.releaseFilter.checkForBeta, "Ja", "Nein"), _
                                                                    If(upctrlMain.releaseFilter.checkForAlpha, "Ja", "Nein")))


    End Sub

    'Dieses Event wird benötigt, um die Anwendung selbstständig schließen zu können.
    'Dies ist für den Updateprozess notwendig da die Anwendungsdateuen während der
    'Ausführung ja nicht überschrieben werden können.
    'Alternativ kann auch die Eigenschaft "autoCloseHostApplication" des updateControllers
    'auf true gesetzt werden. Dann wird die Anwendung automatisch geschlossen aber es gibt
    'keine Möglichkeit um z.B. Einstellungen zu speichern.
    Private Sub upctrlMain_updateInstallerStarted(ByVal sender As Object, ByVal e As updateSystemDotNet.appEventArgs.updateInstallerStartedEventArgs) Handles upctrlMain.updateInstallerStarted
        Close()
    End Sub

#Region " Einfache Updatesuche "

    Private Sub btnRunUpdateInteractive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunUpdateInteractive.Click

        upctrlMain.updateInteractive()

    End Sub

#End Region

#Region " Manuelles aufrufen der Updatedialoge "

    Private Sub btnRunDialogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunDialogs.Click
        'Natürlich könnte man auch immer auf == DialogResult.OK prüfen, aber das würde
        'die Abfragen zu sehr verschachteln, letztendlich nur eine Geschmacksfrage :-)

        'Nach Updates suchen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann gibt es keine Updates
        If upctrlMain.checkForUpdatesDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Dem Benutzer die Updatenachricht anzeigen, wenn das zurückgegebene DialogResult nicht "OK" ist, dann möchte
        'er die Updates nicht installieren.
        If upctrlMain.showUpdateDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Die Updates herunterladen. Wenn das zurückgegebene DialogResult nicht "OK" ist, dann wurde der Download abgebrochen (Fehler oder Benutzer).
        If upctrlMain.downloadUpdatesDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

        'Wenn wir bis hier hin gekommen sind, kann das Update nun eingespielt werden. Diese Methode
        'startet den updateInstaller und feuert das im Konstruktor abonierte "updateInstallerStarted"-Event
        'damit wir wissen wann die Anwendung geschlossen werden soll.
        upctrlMain.applyUpdate()

    End Sub

#End Region

#Region " Asynchroner Updatespaß "

    Private Sub btnRunAsync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunAsync.Click
        'Updatesuche anstoßen
        upctrlMain.checkForUpdatesAsync()
    End Sub

    'Dieses Event wird in jedem Falle nach Abschluß der Updatesuche gefeuert.
    'Also bei gefundenen Updates, keinen neuen Updates und auch im Fehlerfall.
    Private Sub upctrlMain_checkForUpdatesCompleted(ByVal sender As Object, ByVal e As updateSystemDotNet.appEventArgs.checkForUpdatesCompletedEventArgs) Handles upctrlMain.checkForUpdatesCompleted

        'Überprüfen ob ein Fehler auftrat:
        'könnte man auch ne MessageBox anzeigen, aber das ist jedem selber überlassen.
        If Not e.Error Is Nothing And Not e.Cancelled Then Throw e.Error

    End Sub

    'Dieses Event wird ausschließlich gefeuert, wenn bei der Updatesuche neue Aktualisierungen gefunden wurden.
    Private Sub upctrlMain_updateFound(ByVal sender As Object, ByVal e As updateSystemDotNet.appEventArgs.updateFoundEventArgs) Handles upctrlMain.updateFound

        'Dem Benutzer anzeigen das es neue Updates gibt, dazu bauen wir uns erst den Changelog zusammen
        Dim sbChangelog As New StringBuilder
        For Each package As updatePackage In e.Result.newUpdatePackages
            sbChangelog.AppendLine("Änderungen in Version " + package.releaseInfo.Version)
            sbChangelog.AppendLine(e.Result.Changelogs(package).germanChanges)
            sbChangelog.AppendLine()
        Next

        'Neueste Version ermitteln
        Dim latestVersion As String = e.Result.newUpdatePackages(e.Result.newUpdatePackages.Count - 1).releaseInfo.Version
        If MessageBox.Show(String.Format("Es ist eine neue Version verfügbar: {0}" + Environment.NewLine + "Changelog:" + Environment.NewLine + "{1}" + Environment.NewLine + "Möchten Sie diese Installieren?", latestVersion, sbChangelog.ToString), "Testanwendung", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            upctrlMain.downloadUpdates()
        End If

    End Sub

    
    Private Sub upctrlMain_downloadUpdatesCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles upctrlMain.downloadUpdatesCompleted

        If Not e.Error Is Nothing Then Throw e.Error

        upctrlMain.applyUpdate()

    End Sub

    Private Sub upctrlMain_downloadUpdatesProgressChanged(ByVal sender As Object, ByVal e As updateSystemDotNet.appEventArgs.downloadUpdatesProgressChangedEventArgs) Handles upctrlMain.downloadUpdatesProgressChanged
        prgDownloadProgress.Value = e.ProgressPercentage
    End Sub

#End Region

#Region " Eigener Downloaddialog "

    Private Sub btnRunCustomDownloadDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunCustomDownloadDialog.Click


        If upctrlMain.checkForUpdatesDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

        If upctrlMain.showUpdateDialog(Me) <> Windows.Forms.DialogResult.OK Then Exit Sub

        If upctrlMain.downloadUpdatesDialog(Me, New customDownloadDialog) <> Windows.Forms.DialogResult.OK Then Exit Sub

        upctrlMain.applyUpdate()

    End Sub

#End Region

End Class
