namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class renameFileActionEditor
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
			this.txtNewFilename = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lnkVarInfo = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.SuspendLayout();
			// 
			// txtNewFilename
			// 
			this.txtNewFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNewFilename.Location = new System.Drawing.Point(7, 113);
			this.txtNewFilename.Name = "txtNewFilename";
			this.txtNewFilename.Size = new System.Drawing.Size(489, 23);
			this.txtNewFilename.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(3, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(279, 23);
			this.label2.TabIndex = 13;
			this.label2.Text = "Neuer Dateiname";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtPath.Location = new System.Drawing.Point(7, 27);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(489, 23);
			this.txtPath.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(383, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Vollständiger Pfad zu der umzubennenden Datei";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lnkVarInfo
			// 
			this.lnkVarInfo.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lnkVarInfo.AutoSize = true;
			this.lnkVarInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.lnkVarInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkVarInfo.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lnkVarInfo.Location = new System.Drawing.Point(7, 60);
			this.lnkVarInfo.Name = "lnkVarInfo";
			this.lnkVarInfo.Size = new System.Drawing.Size(192, 13);
			this.lnkVarInfo.TabIndex = 15;
			this.lnkVarInfo.TabStop = true;
			this.lnkVarInfo.Text = "Informationen zu den Pfadvariablen";
			this.lnkVarInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVarInfo_LinkClicked);
			// 
			// renameFileActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lnkVarInfo);
			this.Controls.Add(this.txtNewFilename);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.Name = "renameFileActionEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewFilename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private Controls.linkLabelEx lnkVarInfo;
    }
}
