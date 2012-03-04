namespace Beispielanwendung_CSharp {
	sealed partial class mainForm {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.grpUpdateInteractive = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRunUpdateInteractive = new System.Windows.Forms.Button();
			this.grpAppInfo = new System.Windows.Forms.GroupBox();
			this.lblFilter = new System.Windows.Forms.Label();
			this.lblReleaseInfo = new System.Windows.Forms.Label();
			this.lblAssemblyVersion = new System.Windows.Forms.Label();
			this.upctrlMain = new updateSystemDotNet.updateController();
			this.grpDialogs = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRunDialogs = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.prgDownloadProgress = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRunAsync = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRunCustomDownloadDialog = new System.Windows.Forms.Button();
			this.grpUpdateInteractive.SuspendLayout();
			this.grpAppInfo.SuspendLayout();
			this.grpDialogs.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpUpdateInteractive
			// 
			this.grpUpdateInteractive.Controls.Add(this.label1);
			this.grpUpdateInteractive.Controls.Add(this.btnRunUpdateInteractive);
			this.grpUpdateInteractive.Location = new System.Drawing.Point(12, 95);
			this.grpUpdateInteractive.Name = "grpUpdateInteractive";
			this.grpUpdateInteractive.Size = new System.Drawing.Size(657, 63);
			this.grpUpdateInteractive.TabIndex = 0;
			this.grpUpdateInteractive.TabStop = false;
			this.grpUpdateInteractive.Text = "Komplett automatisierte Updatesuche";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Location = new System.Drawing.Point(109, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(545, 44);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mit der Methode updateInteractive() führt der updateController automatisch alle z" +
				"um Updateprozess gehörenden Funktionen aus.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRunUpdateInteractive
			// 
			this.btnRunUpdateInteractive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRunUpdateInteractive.Location = new System.Drawing.Point(6, 26);
			this.btnRunUpdateInteractive.Name = "btnRunUpdateInteractive";
			this.btnRunUpdateInteractive.Size = new System.Drawing.Size(72, 23);
			this.btnRunUpdateInteractive.TabIndex = 0;
			this.btnRunUpdateInteractive.Text = "Start";
			this.btnRunUpdateInteractive.UseVisualStyleBackColor = true;
			this.btnRunUpdateInteractive.Click += new System.EventHandler(this.btnRunUpdateInteractive_Click);
			// 
			// grpAppInfo
			// 
			this.grpAppInfo.Controls.Add(this.lblFilter);
			this.grpAppInfo.Controls.Add(this.lblReleaseInfo);
			this.grpAppInfo.Controls.Add(this.lblAssemblyVersion);
			this.grpAppInfo.Location = new System.Drawing.Point(12, 13);
			this.grpAppInfo.Name = "grpAppInfo";
			this.grpAppInfo.Size = new System.Drawing.Size(657, 76);
			this.grpAppInfo.TabIndex = 1;
			this.grpAppInfo.TabStop = false;
			this.grpAppInfo.Text = "Anwendungsinformationen";
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(7, 56);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(85, 13);
			this.lblFilter.TabIndex = 2;
			this.lblFilter.Text = "Suche nach: {0}";
			// 
			// lblReleaseInfo
			// 
			this.lblReleaseInfo.AutoSize = true;
			this.lblReleaseInfo.Location = new System.Drawing.Point(7, 38);
			this.lblReleaseInfo.Name = "lblReleaseInfo";
			this.lblReleaseInfo.Size = new System.Drawing.Size(100, 13);
			this.lblReleaseInfo.TabIndex = 1;
			this.lblReleaseInfo.Text = "Releaseinfo: {0} {1}";
			// 
			// lblAssemblyVersion
			// 
			this.lblAssemblyVersion.AutoSize = true;
			this.lblAssemblyVersion.Location = new System.Drawing.Point(7, 20);
			this.lblAssemblyVersion.Name = "lblAssemblyVersion";
			this.lblAssemblyVersion.Size = new System.Drawing.Size(105, 13);
			this.lblAssemblyVersion.TabIndex = 0;
			this.lblAssemblyVersion.Text = "Assemblyversion: {0}";
			// 
			// upctrlMain
			// 
			this.upctrlMain.applicationLocation = "";
			this.upctrlMain.autoCopyCommandlineArguments = true;
			this.upctrlMain.projectId = "c82eae0f-bb7f-41ca-afbb-5872936da2e8";
			this.upctrlMain.proxyPassword = null;
			this.upctrlMain.proxyUrl = null;
			this.upctrlMain.proxyUsername = null;
			this.upctrlMain.publicKey = resources.GetString("upctrlMain.publicKey");
			this.upctrlMain.releaseFilter.checkForAlpha = false;
			this.upctrlMain.releaseFilter.checkForBeta = false;
			this.upctrlMain.releaseFilter.checkForFinal = true;
			this.upctrlMain.releaseInfo.Version = "";
			this.upctrlMain.requestElevation = true;
			this.upctrlMain.retrieveHostVersion = true;
			this.upctrlMain.updateLocation = "https://updates.updatesystem.net/test/public/";
			// 
			// grpDialogs
			// 
			this.grpDialogs.Controls.Add(this.label2);
			this.grpDialogs.Controls.Add(this.btnRunDialogs);
			this.grpDialogs.Location = new System.Drawing.Point(12, 164);
			this.grpDialogs.Name = "grpDialogs";
			this.grpDialogs.Size = new System.Drawing.Size(657, 47);
			this.grpDialogs.TabIndex = 2;
			this.grpDialogs.TabStop = false;
			this.grpDialogs.Text = "Manuelles aufrufen der Updatedialoge";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Location = new System.Drawing.Point(106, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(548, 28);
			this.label2.TabIndex = 1;
			this.label2.Text = "Alle Updatedialoge (Suche, Anzeige und Download) lassen sich auch einzelnd im Cod" +
				"e aufrufen.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRunDialogs
			// 
			this.btnRunDialogs.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRunDialogs.Location = new System.Drawing.Point(6, 18);
			this.btnRunDialogs.Name = "btnRunDialogs";
			this.btnRunDialogs.Size = new System.Drawing.Size(72, 23);
			this.btnRunDialogs.TabIndex = 0;
			this.btnRunDialogs.Text = "Start";
			this.btnRunDialogs.UseVisualStyleBackColor = true;
			this.btnRunDialogs.Click += new System.EventHandler(this.btnRunDialogs_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.prgDownloadProgress);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btnRunAsync);
			this.groupBox1.Location = new System.Drawing.Point(12, 217);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(657, 65);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Asynchrone Updatesuche ohne Dialoge";
			// 
			// prgDownloadProgress
			// 
			this.prgDownloadProgress.Location = new System.Drawing.Point(6, 44);
			this.prgDownloadProgress.Name = "prgDownloadProgress";
			this.prgDownloadProgress.Size = new System.Drawing.Size(72, 13);
			this.prgDownloadProgress.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Location = new System.Drawing.Point(106, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(548, 46);
			this.label3.TabIndex = 1;
			this.label3.Text = "Natürlich kann auch ohne die Dialoge nach Aktualisierungen gesucht- und diese her" +
				"untergeladen werden. Dieses Beispiel zeigt wie man im Hintergrund nach Updates s" +
				"ucht und diese herunterlädt.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRunAsync
			// 
			this.btnRunAsync.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRunAsync.Location = new System.Drawing.Point(6, 19);
			this.btnRunAsync.Name = "btnRunAsync";
			this.btnRunAsync.Size = new System.Drawing.Size(72, 23);
			this.btnRunAsync.TabIndex = 0;
			this.btnRunAsync.Text = "Start";
			this.btnRunAsync.UseVisualStyleBackColor = true;
			this.btnRunAsync.Click += new System.EventHandler(this.btnRunAsync_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.btnRunCustomDownloadDialog);
			this.groupBox2.Location = new System.Drawing.Point(12, 288);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(657, 55);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Anpassbarer Downloaddialog";
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Right;
			this.label4.Location = new System.Drawing.Point(106, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(548, 36);
			this.label4.TabIndex = 1;
			this.label4.Text = "Wenn während des Updatedownloads ein eigener Dialog angezeigt werden soll, kann d" +
				"ies mit einer eigenen Form realisiert werden, welche von updateDownloadBaseForm " +
				"erbt.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRunCustomDownloadDialog
			// 
			this.btnRunCustomDownloadDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRunCustomDownloadDialog.Location = new System.Drawing.Point(6, 22);
			this.btnRunCustomDownloadDialog.Name = "btnRunCustomDownloadDialog";
			this.btnRunCustomDownloadDialog.Size = new System.Drawing.Size(72, 23);
			this.btnRunCustomDownloadDialog.TabIndex = 0;
			this.btnRunCustomDownloadDialog.Text = "Start";
			this.btnRunCustomDownloadDialog.UseVisualStyleBackColor = true;
			this.btnRunCustomDownloadDialog.Click += new System.EventHandler(this.btnRunCustomDownloadDialog_Click);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 374);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpDialogs);
			this.Controls.Add(this.grpAppInfo);
			this.Controls.Add(this.grpUpdateInteractive);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "mainForm";
			this.Text = "updateSystem.NET - Testdialog";
			this.grpUpdateInteractive.ResumeLayout(false);
			this.grpAppInfo.ResumeLayout(false);
			this.grpAppInfo.PerformLayout();
			this.grpDialogs.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpUpdateInteractive;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRunUpdateInteractive;
		private updateSystemDotNet.updateController upctrlMain;
		private System.Windows.Forms.GroupBox grpAppInfo;
		private System.Windows.Forms.Label lblAssemblyVersion;
		private System.Windows.Forms.Label lblReleaseInfo;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.GroupBox grpDialogs;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRunDialogs;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnRunAsync;
		private System.Windows.Forms.ProgressBar prgDownloadProgress;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRunCustomDownloadDialog;
	}
}

