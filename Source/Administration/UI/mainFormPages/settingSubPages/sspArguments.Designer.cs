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
			this.label5 = new System.Windows.Forms.Label();
			this.txtArgumentFailure = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtArgumentSuccess = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.flpControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label5, true);
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(397, 30);
			this.label5.TabIndex = 24;
			this.label5.Text = "Hier können Sie Parameter angeben, welche bei einem erfolgreichen oder fehlgeschl" +
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
			// label4
			// 
			this.label4.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label4, true);
			this.label4.Location = new System.Drawing.Point(3, 86);
			this.label4.Margin = new System.Windows.Forms.Padding(3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(256, 15);
			this.label4.TabIndex = 22;
			this.label4.Text = "Parameter bei einem fehlgeschlagenen Update:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label3, true);
			this.label3.Location = new System.Drawing.Point(3, 36);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(233, 15);
			this.label3.TabIndex = 20;
			this.label3.Text = "Parameter bei einem erfolgreichen Update:";
			// 
			// flpControls
			// 
			this.flpControls.Controls.Add(this.label5);
			this.flpControls.Controls.Add(this.label3);
			this.flpControls.Controls.Add(this.txtArgumentSuccess);
			this.flpControls.Controls.Add(this.label4);
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

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtArgumentFailure;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtArgumentSuccess;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
	}
}
