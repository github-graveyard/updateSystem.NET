<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class mainForm
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.btnRunCustomDownloadDialog = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.prgDownloadProgress = New System.Windows.Forms.ProgressBar
        Me.label3 = New System.Windows.Forms.Label
        Me.btnRunAsync = New System.Windows.Forms.Button
        Me.grpDialogs = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.btnRunDialogs = New System.Windows.Forms.Button
        Me.grpAppInfo = New System.Windows.Forms.GroupBox
        Me.lblFilter = New System.Windows.Forms.Label
        Me.lblReleaseInfo = New System.Windows.Forms.Label
        Me.lblAssemblyVersion = New System.Windows.Forms.Label
        Me.grpUpdateInteractive = New System.Windows.Forms.GroupBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnRunUpdateInteractive = New System.Windows.Forms.Button
        Me.upctrlMain = New updateSystemDotNet.updateController
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.grpDialogs.SuspendLayout()
        Me.grpAppInfo.SuspendLayout()
        Me.grpUpdateInteractive.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.btnRunCustomDownloadDialog)
        Me.groupBox2.Location = New System.Drawing.Point(7, 287)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(657, 55)
        Me.groupBox2.TabIndex = 9
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Anpassbarer Downloaddialog"
        '
        'label4
        '
        Me.label4.Dock = System.Windows.Forms.DockStyle.Right
        Me.label4.Location = New System.Drawing.Point(106, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(548, 36)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Wenn während des Updatedownloads ein eigener Dialog angezeigt werden soll, kann d" & _
            "ies mit einer eigenen Form realisiert werden, welche von updateDownloadBaseForm " & _
            "erbt."
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRunCustomDownloadDialog
        '
        Me.btnRunCustomDownloadDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRunCustomDownloadDialog.Location = New System.Drawing.Point(6, 22)
        Me.btnRunCustomDownloadDialog.Name = "btnRunCustomDownloadDialog"
        Me.btnRunCustomDownloadDialog.Size = New System.Drawing.Size(72, 23)
        Me.btnRunCustomDownloadDialog.TabIndex = 0
        Me.btnRunCustomDownloadDialog.Text = "Start"
        Me.btnRunCustomDownloadDialog.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.prgDownloadProgress)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.btnRunAsync)
        Me.groupBox1.Location = New System.Drawing.Point(7, 216)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(657, 65)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Asynchrone Updatesuche ohne Dialoge"
        '
        'prgDownloadProgress
        '
        Me.prgDownloadProgress.Location = New System.Drawing.Point(6, 44)
        Me.prgDownloadProgress.Name = "prgDownloadProgress"
        Me.prgDownloadProgress.Size = New System.Drawing.Size(72, 13)
        Me.prgDownloadProgress.TabIndex = 4
        '
        'label3
        '
        Me.label3.Dock = System.Windows.Forms.DockStyle.Right
        Me.label3.Location = New System.Drawing.Point(106, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(548, 46)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Natürlich kann auch ohne die Dialoge nach Aktualisierungen gesucht- und diese her" & _
            "untergeladen werden. Dieses Beispiel zeigt wie man im Hintergrund nach Updates s" & _
            "ucht und diese herunterlädt."
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRunAsync
        '
        Me.btnRunAsync.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRunAsync.Location = New System.Drawing.Point(6, 19)
        Me.btnRunAsync.Name = "btnRunAsync"
        Me.btnRunAsync.Size = New System.Drawing.Size(72, 23)
        Me.btnRunAsync.TabIndex = 0
        Me.btnRunAsync.Text = "Start"
        Me.btnRunAsync.UseVisualStyleBackColor = True
        '
        'grpDialogs
        '
        Me.grpDialogs.Controls.Add(Me.label2)
        Me.grpDialogs.Controls.Add(Me.btnRunDialogs)
        Me.grpDialogs.Location = New System.Drawing.Point(7, 163)
        Me.grpDialogs.Name = "grpDialogs"
        Me.grpDialogs.Size = New System.Drawing.Size(657, 47)
        Me.grpDialogs.TabIndex = 7
        Me.grpDialogs.TabStop = False
        Me.grpDialogs.Text = "Manuelles aufrufen der Updatedialoge"
        '
        'label2
        '
        Me.label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.label2.Location = New System.Drawing.Point(106, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(548, 28)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Alle Updatedialoge (Suche, Anzeige und Download) lassen sich auch einzelnd im Cod" & _
            "e aufrufen."
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRunDialogs
        '
        Me.btnRunDialogs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRunDialogs.Location = New System.Drawing.Point(6, 18)
        Me.btnRunDialogs.Name = "btnRunDialogs"
        Me.btnRunDialogs.Size = New System.Drawing.Size(72, 23)
        Me.btnRunDialogs.TabIndex = 0
        Me.btnRunDialogs.Text = "Start"
        Me.btnRunDialogs.UseVisualStyleBackColor = True
        '
        'grpAppInfo
        '
        Me.grpAppInfo.Controls.Add(Me.lblFilter)
        Me.grpAppInfo.Controls.Add(Me.lblReleaseInfo)
        Me.grpAppInfo.Controls.Add(Me.lblAssemblyVersion)
        Me.grpAppInfo.Location = New System.Drawing.Point(7, 12)
        Me.grpAppInfo.Name = "grpAppInfo"
        Me.grpAppInfo.Size = New System.Drawing.Size(657, 76)
        Me.grpAppInfo.TabIndex = 6
        Me.grpAppInfo.TabStop = False
        Me.grpAppInfo.Text = "Anwendungsinformationen"
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Location = New System.Drawing.Point(7, 56)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(85, 13)
        Me.lblFilter.TabIndex = 2
        Me.lblFilter.Text = "Suche nach: {0}"
        '
        'lblReleaseInfo
        '
        Me.lblReleaseInfo.AutoSize = True
        Me.lblReleaseInfo.Location = New System.Drawing.Point(7, 38)
        Me.lblReleaseInfo.Name = "lblReleaseInfo"
        Me.lblReleaseInfo.Size = New System.Drawing.Size(100, 13)
        Me.lblReleaseInfo.TabIndex = 1
        Me.lblReleaseInfo.Text = "Releaseinfo: {0} {1}"
        '
        'lblAssemblyVersion
        '
        Me.lblAssemblyVersion.AutoSize = True
        Me.lblAssemblyVersion.Location = New System.Drawing.Point(7, 20)
        Me.lblAssemblyVersion.Name = "lblAssemblyVersion"
        Me.lblAssemblyVersion.Size = New System.Drawing.Size(105, 13)
        Me.lblAssemblyVersion.TabIndex = 0
        Me.lblAssemblyVersion.Text = "Assemblyversion: {0}"
        '
        'grpUpdateInteractive
        '
        Me.grpUpdateInteractive.Controls.Add(Me.label1)
        Me.grpUpdateInteractive.Controls.Add(Me.btnRunUpdateInteractive)
        Me.grpUpdateInteractive.Location = New System.Drawing.Point(7, 94)
        Me.grpUpdateInteractive.Name = "grpUpdateInteractive"
        Me.grpUpdateInteractive.Size = New System.Drawing.Size(657, 63)
        Me.grpUpdateInteractive.TabIndex = 5
        Me.grpUpdateInteractive.TabStop = False
        Me.grpUpdateInteractive.Text = "Komplett automatisierte Updatesuche"
        '
        'label1
        '
        Me.label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.label1.Location = New System.Drawing.Point(109, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(545, 44)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Mit der Methode updateInteractive() führt der updateController automatisch alle z" & _
            "um Updateprozess gehörenden Funktionen aus."
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRunUpdateInteractive
        '
        Me.btnRunUpdateInteractive.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRunUpdateInteractive.Location = New System.Drawing.Point(6, 26)
        Me.btnRunUpdateInteractive.Name = "btnRunUpdateInteractive"
        Me.btnRunUpdateInteractive.Size = New System.Drawing.Size(72, 23)
        Me.btnRunUpdateInteractive.TabIndex = 0
        Me.btnRunUpdateInteractive.Text = "Start"
        Me.btnRunUpdateInteractive.UseVisualStyleBackColor = True
        '
        'upctrlMain
        '
        Me.upctrlMain.applicationLocation = ""
        Me.upctrlMain.autoCopyCommandlineArguments = True
        Me.upctrlMain.projectId = "c82eae0f-bb7f-41ca-afbb-5872936da2e8"
        Me.upctrlMain.proxyPassword = Nothing
        Me.upctrlMain.proxyUrl = Nothing
        Me.upctrlMain.proxyUsername = Nothing
        Me.upctrlMain.publicKey = resources.GetString("upctrlMain.publicKey")
        Me.upctrlMain.releaseFilter.checkForAlpha = False
        Me.upctrlMain.releaseFilter.checkForBeta = False
        Me.upctrlMain.releaseFilter.checkForFinal = True
        Me.upctrlMain.releaseInfo.Version = ""
        Me.upctrlMain.requestElevation = True
        Me.upctrlMain.retrieveHostVersion = True
        Me.upctrlMain.updateLocation = "https://updates.updatesystem.net/test/public/"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 364)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.grpDialogs)
        Me.Controls.Add(Me.grpAppInfo)
        Me.Controls.Add(Me.grpUpdateInteractive)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mainForm"
        Me.Text = "updateSystem.NET - Testdialog"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.grpDialogs.ResumeLayout(False)
        Me.grpAppInfo.ResumeLayout(False)
        Me.grpAppInfo.PerformLayout()
        Me.grpUpdateInteractive.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents btnRunCustomDownloadDialog As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents prgDownloadProgress As System.Windows.Forms.ProgressBar
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnRunAsync As System.Windows.Forms.Button
    Private WithEvents grpDialogs As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnRunDialogs As System.Windows.Forms.Button
    Private WithEvents grpAppInfo As System.Windows.Forms.GroupBox
    Private WithEvents lblFilter As System.Windows.Forms.Label
    Private WithEvents lblReleaseInfo As System.Windows.Forms.Label
    Private WithEvents lblAssemblyVersion As System.Windows.Forms.Label
    Private WithEvents grpUpdateInteractive As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnRunUpdateInteractive As System.Windows.Forms.Button
    Private WithEvents upctrlMain As updateSystemDotNet.updateController

End Class
