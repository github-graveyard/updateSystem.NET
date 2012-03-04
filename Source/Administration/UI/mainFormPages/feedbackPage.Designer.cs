namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class feedbackPage {
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMail = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnSendFeedback = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.bgwSendFeedback = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(3, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(510, 34);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ihr Feedback ist uns wichtig. Wenn Ihnen eine Funktion fehlt oder Sie konstruktiv" +
				"e Kritik jeder Art senden möchten, nutzen Sie bitte dieses Formular.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Ihr Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(189, 68);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(321, 23);
			this.txtName.TabIndex = 3;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Ihre E-Mailadresse (Optional):";
			// 
			// txtMail
			// 
			this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMail.Location = new System.Drawing.Point(189, 97);
			this.txtMail.Name = "txtMail";
			this.txtMail.Size = new System.Drawing.Size(321, 23);
			this.txtMail.TabIndex = 5;
			this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(177, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Ihre Nachricht:";
			// 
			// txtMessage
			// 
			this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessage.Location = new System.Drawing.Point(189, 126);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMessage.Size = new System.Drawing.Size(321, 106);
			this.txtMessage.TabIndex = 7;
			// 
			// btnSendFeedback
			// 
			this.btnSendFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSendFeedback.AutoSize = true;
			this.btnSendFeedback.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnSendFeedback.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSendFeedback.Location = new System.Drawing.Point(385, 239);
			this.btnSendFeedback.Name = "btnSendFeedback";
			this.btnSendFeedback.Size = new System.Drawing.Size(125, 24);
			this.btnSendFeedback.TabIndex = 8;
			this.btnSendFeedback.Text = "Feedback absenden";
			this.btnSendFeedback.UseVisualStyleBackColor = true;
			this.btnSendFeedback.Click += new System.EventHandler(this.btnSendFeedback_Click);
			// 
			// bgwSendFeedback
			// 
			this.bgwSendFeedback.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSendFeedback_DoWork);
			this.bgwSendFeedback.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSendFeedback_RunWorkerCompleted);
			// 
			// feedbackPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSendFeedback);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMail);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Name = "feedbackPage";
			this.pageName = "Feedback";
			this.Size = new System.Drawing.Size(513, 270);
			this.Title = "Feedback senden";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.txtName, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.txtMail, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtMessage, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.btnSendFeedback, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMessage;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnSendFeedback;
		private System.ComponentModel.BackgroundWorker bgwSendFeedback;
	}
}
