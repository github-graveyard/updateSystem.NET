namespace updateSystemDotNet.Administration.UI.mainFormPages.startSubPages {
	partial class startVSIntegrationSubPage {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startVSIntegrationSubPage));
			this.rbVB = new System.Windows.Forms.RadioButton();
			this.rbCSharp = new System.Windows.Forms.RadioButton();
			this.rbDesigner = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlVB = new System.Windows.Forms.Panel();
			this.txtVB = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.pnlCSharp = new System.Windows.Forms.Panel();
			this.txtCSharp = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.flpWindowsForms = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCopyControllerObject = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.imgImportSettings = new System.Windows.Forms.PictureBox();
			this.pnlWinForms = new System.Windows.Forms.Panel();
			this.pnlVB.SuspendLayout();
			this.pnlCSharp.SuspendLayout();
			this.flpControls.SuspendLayout();
			this.flpWindowsForms.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgImportSettings)).BeginInit();
			this.pnlWinForms.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbVB
			// 
			this.rbVB.AutoSize = true;
			this.rbVB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbVB.Location = new System.Drawing.Point(254, 3);
			this.rbVB.Name = "rbVB";
			this.rbVB.Size = new System.Drawing.Size(101, 20);
			this.rbVB.TabIndex = 14;
			this.rbVB.TabStop = true;
			this.rbVB.Text = "VB.NET Code";
			this.rbVB.UseVisualStyleBackColor = true;
			this.rbVB.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// rbCSharp
			// 
			this.rbCSharp.AutoSize = true;
			this.rbCSharp.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbCSharp.Location = new System.Drawing.Point(171, 3);
			this.rbCSharp.Name = "rbCSharp";
			this.rbCSharp.Size = new System.Drawing.Size(77, 20);
			this.rbCSharp.TabIndex = 13;
			this.rbCSharp.TabStop = true;
			this.rbCSharp.Text = "C# Code";
			this.rbCSharp.UseVisualStyleBackColor = true;
			this.rbCSharp.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// rbDesigner
			// 
			this.rbDesigner.AutoSize = true;
			this.rbDesigner.Checked = true;
			this.rbDesigner.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbDesigner.Location = new System.Drawing.Point(3, 3);
			this.rbDesigner.Name = "rbDesigner";
			this.rbDesigner.Size = new System.Drawing.Size(162, 20);
			this.rbDesigner.TabIndex = 12;
			this.rbDesigner.TabStop = true;
			this.rbDesigner.Text = "WindowsForms Designer";
			this.rbDesigner.UseVisualStyleBackColor = true;
			this.rbDesigner.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(480, 39);
			this.label1.TabIndex = 11;
			this.label1.Text = "Sie können die Einstellungen dieses Projektes über die Zwischenablage in Ihr Proj" +
				"ekt in der Entwicklungsumgebung übertragen.\r\nWählen Sie dafür zuerst die passend" +
				"e Zielumgebung aus:";
			// 
			// pnlVB
			// 
			this.pnlVB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlVB.Controls.Add(this.txtVB);
			this.pnlVB.Controls.Add(this.label9);
			this.pnlVB.Location = new System.Drawing.Point(9, 97);
			this.pnlVB.Name = "pnlVB";
			this.pnlVB.Size = new System.Drawing.Size(472, 271);
			this.pnlVB.TabIndex = 17;
			this.pnlVB.Visible = false;
			// 
			// txtVB
			// 
			this.txtVB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtVB.Location = new System.Drawing.Point(0, 70);
			this.txtVB.Multiline = true;
			this.txtVB.Name = "txtVB";
			this.txtVB.ReadOnly = true;
			this.txtVB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtVB.Size = new System.Drawing.Size(472, 201);
			this.txtVB.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Top;
			this.label9.Location = new System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(472, 70);
			this.label9.TabIndex = 1;
			this.label9.Text = resources.GetString("label9.Text");
			// 
			// pnlCSharp
			// 
			this.pnlCSharp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlCSharp.Controls.Add(this.txtCSharp);
			this.pnlCSharp.Controls.Add(this.label8);
			this.pnlCSharp.Location = new System.Drawing.Point(9, 97);
			this.pnlCSharp.Name = "pnlCSharp";
			this.pnlCSharp.Size = new System.Drawing.Size(472, 271);
			this.pnlCSharp.TabIndex = 16;
			this.pnlCSharp.Visible = false;
			// 
			// txtCSharp
			// 
			this.txtCSharp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCSharp.Location = new System.Drawing.Point(0, 67);
			this.txtCSharp.Multiline = true;
			this.txtCSharp.Name = "txtCSharp";
			this.txtCSharp.ReadOnly = true;
			this.txtCSharp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCSharp.Size = new System.Drawing.Size(472, 204);
			this.txtCSharp.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(472, 67);
			this.label8.TabIndex = 1;
			this.label8.Text = resources.GetString("label8.Text");
			// 
			// flpControls
			// 
			this.flpControls.AutoSize = true;
			this.flpControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flpControls.Controls.Add(this.rbDesigner);
			this.flpControls.Controls.Add(this.rbCSharp);
			this.flpControls.Controls.Add(this.rbVB);
			this.flpControls.Location = new System.Drawing.Point(9, 65);
			this.flpControls.Name = "flpControls";
			this.flpControls.Size = new System.Drawing.Size(358, 26);
			this.flpControls.TabIndex = 18;
			// 
			// flpWindowsForms
			// 
			this.flpWindowsForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flpWindowsForms.Controls.Add(this.label2);
			this.flpWindowsForms.Controls.Add(this.label3);
			this.flpWindowsForms.Controls.Add(this.btnCopyControllerObject);
			this.flpWindowsForms.Controls.Add(this.label5);
			this.flpWindowsForms.Controls.Add(this.label4);
			this.flpWindowsForms.Controls.Add(this.label6);
			this.flpWindowsForms.Controls.Add(this.label7);
			this.flpWindowsForms.Controls.Add(this.imgImportSettings);
			this.flpWindowsForms.Location = new System.Drawing.Point(0, 0);
			this.flpWindowsForms.Name = "flpWindowsForms";
			this.flpWindowsForms.Size = new System.Drawing.Size(472, 271);
			this.flpWindowsForms.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.flpWindowsForms.SetFlowBreak(this.label2, true);
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Schritt 1:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 24);
			this.label3.Margin = new System.Windows.Forms.Padding(3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(284, 15);
			this.label3.TabIndex = 11;
			this.label3.Text = "Kopieren Sie die Projektdaten in die Zwischenablage:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCopyControllerObject
			// 
			this.btnCopyControllerObject.AutoSize = true;
			this.btnCopyControllerObject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCopyControllerObject.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.flpWindowsForms.SetFlowBreak(this.btnCopyControllerObject, true);
			this.btnCopyControllerObject.Location = new System.Drawing.Point(293, 24);
			this.btnCopyControllerObject.Name = "btnCopyControllerObject";
			this.btnCopyControllerObject.Size = new System.Drawing.Size(101, 24);
			this.btnCopyControllerObject.TabIndex = 8;
			this.btnCopyControllerObject.Text = "Daten kopieren";
			this.btnCopyControllerObject.UseVisualStyleBackColor = true;
			this.btnCopyControllerObject.Click += new System.EventHandler(this.btnCopyControllerObject_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 54);
			this.label5.Margin = new System.Windows.Forms.Padding(3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Schritt 2:";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.flpWindowsForms.SetFlowBreak(this.label4, true);
			this.label4.Location = new System.Drawing.Point(3, 73);
			this.label4.Margin = new System.Windows.Forms.Padding(3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(464, 60);
			this.label4.TabIndex = 13;
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.UseMnemonic = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(3, 139);
			this.label6.Margin = new System.Windows.Forms.Padding(3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Schritt 3:";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.flpWindowsForms.SetFlowBreak(this.label7, true);
			this.label7.Location = new System.Drawing.Point(3, 158);
			this.label7.Margin = new System.Windows.Forms.Padding(3);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(440, 30);
			this.label7.TabIndex = 15;
			this.label7.Text = "Klicken Sie im SmartTag-Menu des Controllers auf den Link zum übernehmen der Eins" +
				"tellungen.";
			// 
			// imgImportSettings
			// 
			this.imgImportSettings.Location = new System.Drawing.Point(3, 194);
			this.imgImportSettings.Name = "imgImportSettings";
			this.imgImportSettings.Size = new System.Drawing.Size(350, 70);
			this.imgImportSettings.TabIndex = 9;
			this.imgImportSettings.TabStop = false;
			// 
			// pnlWinForms
			// 
			this.pnlWinForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlWinForms.Controls.Add(this.flpWindowsForms);
			this.pnlWinForms.Location = new System.Drawing.Point(9, 97);
			this.pnlWinForms.Name = "pnlWinForms";
			this.pnlWinForms.Size = new System.Drawing.Size(472, 271);
			this.pnlWinForms.TabIndex = 15;
			// 
			// startVSIntegrationSubPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlWinForms);
			this.Controls.Add(this.pnlCSharp);
			this.Controls.Add(this.pnlVB);
			this.Controls.Add(this.flpControls);
			this.Controls.Add(this.label1);
			this.Name = "startVSIntegrationSubPage";
			this.Size = new System.Drawing.Size(486, 371);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.flpControls, 0);
			this.Controls.SetChildIndex(this.pnlVB, 0);
			this.Controls.SetChildIndex(this.pnlCSharp, 0);
			this.Controls.SetChildIndex(this.pnlWinForms, 0);
			this.pnlVB.ResumeLayout(false);
			this.pnlVB.PerformLayout();
			this.pnlCSharp.ResumeLayout(false);
			this.pnlCSharp.PerformLayout();
			this.flpControls.ResumeLayout(false);
			this.flpControls.PerformLayout();
			this.flpWindowsForms.ResumeLayout(false);
			this.flpWindowsForms.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgImportSettings)).EndInit();
			this.pnlWinForms.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbVB;
		private System.Windows.Forms.RadioButton rbCSharp;
		private System.Windows.Forms.RadioButton rbDesigner;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlVB;
		private System.Windows.Forms.TextBox txtVB;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel pnlCSharp;
		private System.Windows.Forms.TextBox txtCSharp;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
		private System.Windows.Forms.FlowLayoutPanel flpWindowsForms;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCopyControllerObject;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox imgImportSettings;
		private System.Windows.Forms.Panel pnlWinForms;

	}
}
