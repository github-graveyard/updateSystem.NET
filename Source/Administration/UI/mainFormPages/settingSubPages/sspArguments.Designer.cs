namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	partial class sspArguments {
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.lblArgsDescription = new System.Windows.Forms.Label();
			this.txtArgumentFailure = new System.Windows.Forms.TextBox();
			this.lblArgsDescFailed = new System.Windows.Forms.Label();
			this.txtArgumentSuccess = new System.Windows.Forms.TextBox();
			this.lblArgsDescSuccess = new System.Windows.Forms.Label();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.flpControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblArgsDescription
			// 
			this.lblArgsDescription.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblArgsDescription, true);
			this.lblArgsDescription.Location = new System.Drawing.Point(3, 0);
			this.lblArgsDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
			this.lblArgsDescription.Name = "lblArgsDescription";
			this.lblArgsDescription.Size = new System.Drawing.Size(397, 30);
			this.lblArgsDescription.TabIndex = 24;
			this.lblArgsDescription.Text = "Hier können Sie Parameter angeben, welche bei einem erfolgreichen oder fehlgeschl" +
    "agenem Update an die Anwendung übergeben werden sollen.";
			// 
			// txtArgumentFailure
			// 
			this.txtArgumentFailure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtArgumentFailure.Location = new System.Drawing.Point(3, 107);
			this.txtArgumentFailure.Name = "txtArgumentFailure";
			this.txtArgumentFailure.Size = new System.Drawing.Size(436, 23);
			this.txtArgumentFailure.TabIndex = 23;
			this.txtArgumentFailure.TextChanged += new System.EventHandler(this.txtArgumentFailure_TextChanged);
			// 
			// lblArgsDescFailed
			// 
			this.lblArgsDescFailed.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblArgsDescFailed, true);
			this.lblArgsDescFailed.Location = new System.Drawing.Point(3, 86);
			this.lblArgsDescFailed.Margin = new System.Windows.Forms.Padding(3);
			this.lblArgsDescFailed.Name = "lblArgsDescFailed";
			this.lblArgsDescFailed.Size = new System.Drawing.Size(256, 15);
			this.lblArgsDescFailed.TabIndex = 22;
			this.lblArgsDescFailed.Text = "Parameter bei einem fehlgeschlagenen Update:";
			this.lblArgsDescFailed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtArgumentSuccess
			// 
			this.flpControls.SetFlowBreak(this.txtArgumentSuccess, true);
			this.txtArgumentSuccess.Location = new System.Drawing.Point(3, 57);
			this.txtArgumentSuccess.Name = "txtArgumentSuccess";
			this.txtArgumentSuccess.Size = new System.Drawing.Size(436, 23);
			this.txtArgumentSuccess.TabIndex = 21;
			this.txtArgumentSuccess.TextChanged += new System.EventHandler(this.txtArgumentSuccess_TextChanged);
			// 
			// lblArgsDescSuccess
			// 
			this.lblArgsDescSuccess.AutoSize = true;
			this.flpControls.SetFlowBreak(this.lblArgsDescSuccess, true);
			this.lblArgsDescSuccess.Location = new System.Drawing.Point(3, 36);
			this.lblArgsDescSuccess.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.lblArgsDescSuccess.Name = "lblArgsDescSuccess";
			this.lblArgsDescSuccess.Size = new System.Drawing.Size(233, 15);
			this.lblArgsDescSuccess.TabIndex = 20;
			this.lblArgsDescSuccess.Text = "Parameter bei einem erfolgreichen Update:";
			// 
			// flpControls
			// 
			this.flpControls.Controls.Add(this.lblArgsDescription);
			this.flpControls.Controls.Add(this.lblArgsDescSuccess);
			this.flpControls.Controls.Add(this.txtArgumentSuccess);
			this.flpControls.Controls.Add(this.lblArgsDescFailed);
			this.flpControls.Controls.Add(this.txtArgumentFailure);
			this.flpControls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flpControls.Location = new System.Drawing.Point(0, 0);
			this.flpControls.Name = "flpControls";
			this.flpControls.Size = new System.Drawing.Size(452, 142);
			this.flpControls.TabIndex = 25;
			// 
			// sspArguments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpControls);
			this.displayOrder = 800;
			this.MinimumSize = new System.Drawing.Size(390, 100);
			this.Name = "sspArguments";
			this.Size = new System.Drawing.Size(452, 142);
			this.Title = "Übergabeparameter";
			this.flpControls.ResumeLayout(false);
			this.flpControls.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblArgsDescription;
		private System.Windows.Forms.TextBox txtArgumentFailure;
		private System.Windows.Forms.Label lblArgsDescFailed;
		private System.Windows.Forms.TextBox txtArgumentSuccess;
		private System.Windows.Forms.Label lblArgsDescSuccess;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
	}
}
