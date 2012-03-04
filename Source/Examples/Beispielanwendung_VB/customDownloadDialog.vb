Public Class customDownloadDialog

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Font = SystemFonts.MessageBoxFont

    End Sub

    Private Sub customDownloadDialog_downloadUpdatesCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles Me.downloadUpdatesCompleted

        If Not e.Error Is Nothing Then
            If Not e.Cancelled Then Throw e.Error
            DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            DialogResult = Windows.Forms.DialogResult.OK
        End If
        Close()

    End Sub

    Private Sub customDownloadDialog_downloadUpdatesProgressChanged(ByVal sender As Object, ByVal e As updateSystemDotNet.appEventArgs.downloadUpdatesProgressChangedEventArgs) Handles Me.downloadUpdatesProgressChanged
        prgDownload.Value = e.ProgressPercentage
    End Sub

    Private Sub customDownloadDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        startDownload()
    End Sub

    Private Sub btnCancelUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelUpdate.Click
        If isBusy Then cancelDownload()
    End Sub
End Class