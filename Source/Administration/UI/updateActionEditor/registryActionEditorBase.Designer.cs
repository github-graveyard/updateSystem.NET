namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class registryActionEditorBase
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
			this.cboRegistryRoot = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRegistryPath = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Registrypfad:";
			// 
			// cboRegistryRoot
			// 
			this.cboRegistryRoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRegistryRoot.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cboRegistryRoot.FormattingEnabled = true;
			this.cboRegistryRoot.Location = new System.Drawing.Point(7, 18);
			this.cboRegistryRoot.Name = "cboRegistryRoot";
			this.cboRegistryRoot.Size = new System.Drawing.Size(163, 23);
			this.cboRegistryRoot.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(177, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "\\";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRegistryPath
			// 
			this.txtRegistryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegistryPath.Location = new System.Drawing.Point(196, 18);
			this.txtRegistryPath.Name = "txtRegistryPath";
			this.txtRegistryPath.Size = new System.Drawing.Size(300, 23);
			this.txtRegistryPath.TabIndex = 3;
			// 
			// registryActionEditorBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtRegistryPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cboRegistryRoot);
			this.Controls.Add(this.label1);
			this.Name = "registryActionEditorBase";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRegistryRoot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegistryPath;
    }
}
