using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class deleteFilesActionEditor
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
			this.label1 = new System.Windows.Forms.Label();
        	this.txtPath = new updateSystemDotNet.Administration.UI.Controls.textBoxEx();
			this.seperatorLabel1 = new updateSystemDotNet.Administration.UI.Controls.seperatorLabel();
			this.lvwFileNames = new extendedListView();
			this.clmFileNames = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.btnAddEntry = new System.Windows.Forms.Button();
			this.btnRemoveEntry = new System.Windows.Forms.Button();
			this.lnkVarInfo = new updateSystemDotNet.Administration.UI.Controls.linkLabelEx();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(493, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Verzeichnis in welchem sich die Dateien befinden welche gelöscht werden sollen:";
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtPath.Location = new System.Drawing.Point(7, 38);
			this.txtPath.Name = "txtPath";
			this.txtPath.cueText = "z.B.: $appdata\\Dateien";
			this.txtPath.Size = new System.Drawing.Size(489, 23);
			this.txtPath.TabIndex = 1;
			this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
			// 
			// seperatorLabel1
			// 
			this.seperatorLabel1.Location = new System.Drawing.Point(3, 89);
			this.seperatorLabel1.Name = "seperatorLabel1";
			this.seperatorLabel1.Size = new System.Drawing.Size(493, 21);
			this.seperatorLabel1.TabIndex = 2;
			this.seperatorLabel1.Text = "Zu löschende Dateien";
			this.seperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvwFileNames
			// 
			this.lvwFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwFileNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFileNames});
			this.lvwFileNames.FullRowSelect = true;
			this.lvwFileNames.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwFileNames.Location = new System.Drawing.Point(7, 158);
			this.lvwFileNames.MultiSelect = false;
			this.lvwFileNames.Name = "lvwFileNames";
			this.lvwFileNames.Size = new System.Drawing.Size(383, 197);
			this.lvwFileNames.TabIndex = 3;
			this.lvwFileNames.UseCompatibleStateImageBehavior = false;
			this.lvwFileNames.View = System.Windows.Forms.View.Details;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Dateiname:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFileName
			// 
			this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileName.Location = new System.Drawing.Point(150, 126);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(240, 23);
			this.txtFileName.TabIndex = 5;
			// 
			// btnAddEntry
			// 
			this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddEntry.AutoSize = true;
			this.btnAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddEntry.Location = new System.Drawing.Point(398, 127);
			this.btnAddEntry.Name = "btnAddEntry";
			this.btnAddEntry.Size = new System.Drawing.Size(99, 25);
			this.btnAddEntry.TabIndex = 6;
			this.btnAddEntry.Text = "Hinzufügen";
			this.btnAddEntry.UseVisualStyleBackColor = true;
			this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
			// 
			// btnRemoveEntry
			// 
			this.btnRemoveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveEntry.AutoSize = true;
			this.btnRemoveEntry.Enabled = false;
			this.btnRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveEntry.Location = new System.Drawing.Point(398, 158);
			this.btnRemoveEntry.Name = "btnRemoveEntry";
			this.btnRemoveEntry.Size = new System.Drawing.Size(99, 25);
			this.btnRemoveEntry.TabIndex = 7;
			this.btnRemoveEntry.Text = "Entfernen";
			this.btnRemoveEntry.UseVisualStyleBackColor = true;
			this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
			// 
			// lnkVarInfo
			// 
			this.lnkVarInfo.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
			this.lnkVarInfo.AutoSize = true;
			this.lnkVarInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.lnkVarInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkVarInfo.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.lnkVarInfo.Location = new System.Drawing.Point(7, 67);
			this.lnkVarInfo.Name = "lnkVarInfo";
			this.lnkVarInfo.Size = new System.Drawing.Size(192, 13);
			this.lnkVarInfo.TabIndex = 16;
			this.lnkVarInfo.TabStop = true;
			this.lnkVarInfo.Text = "Informationen zu den Pfadvariablen";
			this.lnkVarInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVarInfo_LinkClicked);
			// 
			// deleteFilesActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lnkVarInfo);
			this.Controls.Add(this.btnRemoveEntry);
			this.Controls.Add(this.btnAddEntry);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lvwFileNames);
			this.Controls.Add(this.seperatorLabel1);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.Name = "deleteFilesActionEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.Controls.textBoxEx txtPath;
        private Controls.seperatorLabel seperatorLabel1;
        private UI.Controls.extendedListView lvwFileNames;
        private System.Windows.Forms.ColumnHeader clmFileNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Button btnRemoveEntry;
        private Controls.linkLabelEx lnkVarInfo;
    }
}
