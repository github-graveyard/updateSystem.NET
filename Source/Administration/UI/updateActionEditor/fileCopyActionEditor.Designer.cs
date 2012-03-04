namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
	partial class fileCopyActionEditor
	{
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.tsFiles = new System.Windows.Forms.ToolStrip();
			this.tsbtnAddFiles = new System.Windows.Forms.ToolStripButton();
			this.tsbtnAddFolder = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.tvwFiles = new updateSystemDotNet.Administration.UI.Controls.explorerTreeView();
			this.imglFiles = new System.Windows.Forms.ImageList(this.components);
			this.tsFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsFiles
			// 
			this.tsFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddFiles,
            this.tsbtnAddFolder,
            this.toolStripSeparator1,
            this.tsbtnDelete});
			this.tsFiles.Location = new System.Drawing.Point(0, 0);
			this.tsFiles.Name = "tsFiles";
			this.tsFiles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.tsFiles.Size = new System.Drawing.Size(500, 25);
			this.tsFiles.TabIndex = 0;
			this.tsFiles.Text = "toolStrip1";
			// 
			// tsbtnAddFiles
			// 
			this.tsbtnAddFiles.Image = global::updateSystemDotNet.Administration.Properties.Resources.add_file;
			this.tsbtnAddFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddFiles.Name = "tsbtnAddFiles";
			this.tsbtnAddFiles.Size = new System.Drawing.Size(138, 22);
			this.tsbtnAddFiles.Text = "Datei(en) hinzufügen";
			this.tsbtnAddFiles.Click += new System.EventHandler(this.tsbtnAddFiles_Click);
			// 
			// tsbtnAddFolder
			// 
			this.tsbtnAddFolder.Image = global::updateSystemDotNet.Administration.Properties.Resources.add_folder;
			this.tsbtnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddFolder.Name = "tsbtnAddFolder";
			this.tsbtnAddFolder.Size = new System.Drawing.Size(127, 22);
			this.tsbtnAddFolder.Text = "Ordner hinzufügen";
			this.tsbtnAddFolder.Click += new System.EventHandler(this.tsbtnAddFolder_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.Image = global::updateSystemDotNet.Administration.Properties.Resources.removePackage;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(71, 22);
			this.tsbtnDelete.Text = "Löschen";
			// 
			// tvwFiles
			// 
			this.tvwFiles.AllowDrop = true;
			this.tvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwFiles.HideSelection = false;
			this.tvwFiles.HotTracking = true;
			this.tvwFiles.ImageIndex = 0;
			this.tvwFiles.ImageList = this.imglFiles;
			this.tvwFiles.ItemHeight = 20;
			this.tvwFiles.Location = new System.Drawing.Point(0, 25);
			this.tvwFiles.Name = "tvwFiles";
			this.tvwFiles.SelectedImageIndex = 0;
			this.tvwFiles.ShowLines = false;
			this.tvwFiles.Size = new System.Drawing.Size(500, 334);
			this.tvwFiles.TabIndex = 1;
			// 
			// imglFiles
			// 
			this.imglFiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imglFiles.ImageSize = new System.Drawing.Size(16, 16);
			this.imglFiles.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// fileCopyActionEditor
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tvwFiles);
			this.Controls.Add(this.tsFiles);
			this.Name = "fileCopyActionEditor";
			this.tsFiles.ResumeLayout(false);
			this.tsFiles.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsFiles;
		private System.Windows.Forms.ToolStripButton tsbtnAddFiles;
		private System.Windows.Forms.ToolStripButton tsbtnAddFolder;
		private Controls.explorerTreeView tvwFiles;
		private System.Windows.Forms.ImageList imglFiles;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
	}
}
