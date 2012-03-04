<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class customDownloadDialog
    Inherits updateSystemDotNet.updateDownloadBaseForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.prgDownload = New System.Windows.Forms.ProgressBar
        Me.btnCancelUpdate = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'prgDownload
        '
        Me.prgDownload.Location = New System.Drawing.Point(13, 13)
        Me.prgDownload.Name = "prgDownload"
        Me.prgDownload.Size = New System.Drawing.Size(387, 20)
        Me.prgDownload.TabIndex = 0
        '
        'btnCancelUpdate
        '
        Me.btnCancelUpdate.Location = New System.Drawing.Point(301, 39)
        Me.btnCancelUpdate.Name = "btnCancelUpdate"
        Me.btnCancelUpdate.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelUpdate.TabIndex = 1
        Me.btnCancelUpdate.Text = "Abbrechen"
        Me.btnCancelUpdate.UseVisualStyleBackColor = True
        '
        'customDownloadDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 70)
        Me.Controls.Add(Me.btnCancelUpdate)
        Me.Controls.Add(Me.prgDownload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "customDownloadDialog"
        Me.ShowInTaskbar = False
        Me.Text = "Updates werden heruntergeladen...."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prgDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancelUpdate As System.Windows.Forms.Button
End Class
