namespace updateSystemDotNet.Internal.UI
{
    partial class releaseFilterControl
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
            this.chkFinal = new System.Windows.Forms.CheckBox();
            this.chkBeta = new System.Windows.Forms.CheckBox();
            this.chkAlpha = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkFinal
            // 
            this.chkFinal.AutoSize = true;
            this.chkFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFinal.Location = new System.Drawing.Point(3, 3);
            this.chkFinal.Name = "chkFinal";
            this.chkFinal.Size = new System.Drawing.Size(54, 18);
            this.chkFinal.TabIndex = 0;
            this.chkFinal.Text = "Final";
            this.chkFinal.UseVisualStyleBackColor = true;
            // 
            // chkBeta
            // 
            this.chkBeta.AutoSize = true;
            this.chkBeta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBeta.Location = new System.Drawing.Point(3, 26);
            this.chkBeta.Name = "chkBeta";
            this.chkBeta.Size = new System.Drawing.Size(54, 18);
            this.chkBeta.TabIndex = 1;
            this.chkBeta.Text = "Beta";
            this.chkBeta.UseVisualStyleBackColor = true;
            // 
            // chkAlpha
            // 
            this.chkAlpha.AutoSize = true;
            this.chkAlpha.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAlpha.Location = new System.Drawing.Point(3, 49);
            this.chkAlpha.Name = "chkAlpha";
            this.chkAlpha.Size = new System.Drawing.Size(59, 18);
            this.chkAlpha.TabIndex = 2;
            this.chkAlpha.Text = "Alpha";
            this.chkAlpha.UseVisualStyleBackColor = true;
            // 
            // releaseFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAlpha);
            this.Controls.Add(this.chkBeta);
            this.Controls.Add(this.chkFinal);
            this.Name = "releaseFilterControl";
            this.Size = new System.Drawing.Size(107, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFinal;
        private System.Windows.Forms.CheckBox chkBeta;
        private System.Windows.Forms.CheckBox chkAlpha;
    }
}
