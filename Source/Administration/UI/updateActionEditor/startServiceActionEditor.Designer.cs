namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class startServiceActionEditor
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
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkRestartIfRunnig = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtServiceName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtArguments
			// 
			this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArguments.Location = new System.Drawing.Point(7, 111);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(489, 23);
			this.txtArguments.TabIndex = 20;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 15);
			this.label3.TabIndex = 19;
			this.label3.Text = "Argumente (Optional)";
			// 
			// chkRestartIfRunnig
			// 
			this.chkRestartIfRunnig.AutoSize = true;
			this.chkRestartIfRunnig.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRestartIfRunnig.Location = new System.Drawing.Point(7, 155);
			this.chkRestartIfRunnig.Name = "chkRestartIfRunnig";
			this.chkRestartIfRunnig.Size = new System.Drawing.Size(258, 20);
			this.chkRestartIfRunnig.TabIndex = 18;
			this.chkRestartIfRunnig.Text = "Dienst neu starten wenn dieser bereits läuft";
			this.chkRestartIfRunnig.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(493, 22);
			this.label2.TabIndex = 17;
			this.label2.Text = "Wichtig: Bitte geben Sie den Namen- und nicht den Anzeigenamen des Dienstes an.";
			// 
			// txtServiceName
			// 
			this.txtServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtServiceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtServiceName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtServiceName.Location = new System.Drawing.Point(7, 27);
			this.txtServiceName.Name = "txtServiceName";
			this.txtServiceName.Size = new System.Drawing.Size(489, 23);
			this.txtServiceName.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(4, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(279, 23);
			this.label1.TabIndex = 15;
			this.label1.Text = "Dienstname:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// startServiceActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtArguments);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkRestartIfRunnig);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtServiceName);
			this.Controls.Add(this.label1);
			this.Name = "startServiceActionEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRestartIfRunnig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label1;
    }
}
