namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class startProcessActionEditor
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
			this.chkElevatedRights = new System.Windows.Forms.CheckBox();
			this.chkDontStartIfExists = new System.Windows.Forms.CheckBox();
			this.chkWaitForExit = new System.Windows.Forms.CheckBox();
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// chkElevatedRights
			// 
			this.chkElevatedRights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.chkElevatedRights.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkElevatedRights.Location = new System.Drawing.Point(6, 200);
			this.chkElevatedRights.Name = "chkElevatedRights";
			this.chkElevatedRights.Size = new System.Drawing.Size(481, 21);
			this.chkElevatedRights.TabIndex = 19;
			this.chkElevatedRights.Text = "Prozess benötigt erhöhte Rechte";
			this.chkElevatedRights.UseVisualStyleBackColor = true;
			// 
			// chkDontStartIfExists
			// 
			this.chkDontStartIfExists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.chkDontStartIfExists.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkDontStartIfExists.Location = new System.Drawing.Point(6, 163);
			this.chkDontStartIfExists.Name = "chkDontStartIfExists";
			this.chkDontStartIfExists.Size = new System.Drawing.Size(481, 30);
			this.chkDontStartIfExists.TabIndex = 18;
			this.chkDontStartIfExists.Text = "Diesen Prozess nicht starten wenn bereits eine oder mehre Instanzen der Anwendung" +
				" laufen";
			this.chkDontStartIfExists.UseVisualStyleBackColor = true;
			// 
			// chkWaitForExit
			// 
			this.chkWaitForExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.chkWaitForExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkWaitForExit.Location = new System.Drawing.Point(6, 135);
			this.chkWaitForExit.Name = "chkWaitForExit";
			this.chkWaitForExit.Size = new System.Drawing.Size(481, 21);
			this.chkWaitForExit.TabIndex = 17;
			this.chkWaitForExit.Text = "Warten bis der Prozess beendet ist";
			this.chkWaitForExit.UseVisualStyleBackColor = true;
			// 
			// txtArguments
			// 
			this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArguments.Location = new System.Drawing.Point(6, 92);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(481, 23);
			this.txtArguments.TabIndex = 16;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(2, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 18);
			this.label2.TabIndex = 15;
			this.label2.Text = "Kommandoparameter:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtPath.Location = new System.Drawing.Point(6, 27);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(481, 23);
			this.txtPath.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "Vollständiger Pfad zu der Anwendung:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(6, 246);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(481, 53);
			this.label3.TabIndex = 20;
			this.label3.Text = "Hinweis: Verwenden Sie diese Aktion nicht, um Ihre eigene Anwendung nach dem Upda" +
				"te zu starten. Nutzen Sie anstelle dessen die \"restartApplication\"-Eigenschaft d" +
				"es updateControllers.";
			// 
			// startProcessActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkElevatedRights);
			this.Controls.Add(this.chkDontStartIfExists);
			this.Controls.Add(this.chkWaitForExit);
			this.Controls.Add(this.txtArguments);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.Name = "startProcessActionEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkElevatedRights;
        private System.Windows.Forms.CheckBox chkDontStartIfExists;
        private System.Windows.Forms.CheckBox chkWaitForExit;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
