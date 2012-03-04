namespace updateSystemDotNet.Internal.UI
{
    partial class versionEditorControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.txtMinor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Major:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(6, 24);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(59, 20);
            this.txtMajor.TabIndex = 1;
            // 
            // txtMinor
            // 
            this.txtMinor.Location = new System.Drawing.Point(71, 24);
            this.txtMinor.Name = "txtMinor";
            this.txtMinor.Size = new System.Drawing.Size(59, 20);
            this.txtMinor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(68, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minor:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtBuild
            // 
            this.txtBuild.Location = new System.Drawing.Point(136, 24);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Size = new System.Drawing.Size(59, 20);
            this.txtBuild.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(133, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Build:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtRevision
            // 
            this.txtRevision.Location = new System.Drawing.Point(201, 24);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(59, 20);
            this.txtRevision.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(198, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Revision:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // versionEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBuild);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.label1);
            this.Name = "versionEditorControl";
            this.Size = new System.Drawing.Size(268, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.TextBox txtMinor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label label4;
    }
}
