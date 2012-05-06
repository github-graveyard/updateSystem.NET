namespace updateSystemDotNet.Administration.UI.Dialogs {
	partial class publishUpdatesResultDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Erfolgreich", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Fehlgeschlagen", System.Windows.Forms.HorizontalAlignment.Left);
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.btnClose = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.chkHidePublishResult = new System.Windows.Forms.CheckBox();
			this.lvwResult = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmPublishInterface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ctxResult = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuExportCSV = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonArea1.SuspendLayout();
			this.ctxResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnClose);
			this.buttonArea1.Controls.Add(this.chkHidePublishResult);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 213);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(496, 50);
			this.buttonArea1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(409, 13);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(72, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Schließen";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkHidePublishResult
			// 
			this.chkHidePublishResult.AutoSize = true;
			this.chkHidePublishResult.BackColor = System.Drawing.Color.Transparent;
			this.chkHidePublishResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkHidePublishResult.Location = new System.Drawing.Point(36, 13);
			this.chkHidePublishResult.MinimumSize = new System.Drawing.Size(0, 25);
			this.chkHidePublishResult.Name = "chkHidePublishResult";
			this.chkHidePublishResult.Size = new System.Drawing.Size(367, 25);
			this.chkHidePublishResult.TabIndex = 1;
			this.chkHidePublishResult.Text = "Diesen Dialog nicht mehr anzeigen, wenn keine Fehler auftraten";
			this.chkHidePublishResult.UseVisualStyleBackColor = false;
			// 
			// lvwResult
			// 
			this.lvwResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmPublishInterface,
            this.clmError});
			this.lvwResult.ContextMenuStrip = this.ctxResult;
			this.lvwResult.FullRowSelect = true;
			listViewGroup1.Header = "Erfolgreich";
			listViewGroup1.Name = "grpSuccess";
			listViewGroup2.Header = "Fehlgeschlagen";
			listViewGroup2.Name = "grpFailed";
			this.lvwResult.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.lvwResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwResult.Location = new System.Drawing.Point(13, 12);
			this.lvwResult.Name = "lvwResult";
			this.lvwResult.Size = new System.Drawing.Size(468, 195);
			this.lvwResult.TabIndex = 1;
			this.lvwResult.UseCompatibleStateImageBehavior = false;
			this.lvwResult.View = System.Windows.Forms.View.Details;
			// 
			// clmName
			// 
			this.clmName.Text = "Name";
			this.clmName.Width = 183;
			// 
			// clmPublishInterface
			// 
			this.clmPublishInterface.Text = "Schnittstelle";
			this.clmPublishInterface.Width = 116;
			// 
			// clmError
			// 
			this.clmError.Text = "Fehlermeldung";
			this.clmError.Width = 137;
			// 
			// ctxResult
			// 
			this.ctxResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportCSV});
			this.ctxResult.Name = "ctxResult";
			this.ctxResult.ShowImageMargin = false;
			this.ctxResult.Size = new System.Drawing.Size(161, 26);
			// 
			// mnuExportCSV
			// 
			this.mnuExportCSV.Name = "mnuExportCSV";
			this.mnuExportCSV.Size = new System.Drawing.Size(160, 22);
			this.mnuExportCSV.Text = "Als CSV Exportieren...";
			this.mnuExportCSV.Click += new System.EventHandler(this.mnuExportCSV_Click);
			// 
			// publishUpdatesResultDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 263);
			this.Controls.Add(this.lvwResult);
			this.Controls.Add(this.buttonArea1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "publishUpdatesResultDialog";
			this.Text = "Veröffentlichung abgeschlossen - [appname]";
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.ctxResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnClose;
		private System.Windows.Forms.CheckBox chkHidePublishResult;
		private updateSystemDotNet.Administration.UI.Controls.extendedListView lvwResult;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmPublishInterface;
		private System.Windows.Forms.ColumnHeader clmError;
		private System.Windows.Forms.ContextMenuStrip ctxResult;
		private System.Windows.Forms.ToolStripMenuItem mnuExportCSV;
	}
}