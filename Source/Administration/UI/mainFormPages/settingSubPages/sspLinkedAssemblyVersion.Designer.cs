namespace updateSystemDotNet.Administration.UI.mainFormPages.settingSubPages {
	partial class sspLinkedAssemblyVersion {
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
			this.pnlLinkedAssembly = new System.Windows.Forms.Panel();
			this.btnBrowseAssembly = new System.Windows.Forms.Button();
			this.txtLinkedAssemblyPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rbLinked = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.rbNotLinked = new System.Windows.Forms.RadioButton();
			this.flpControls = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlLinkedAssembly.SuspendLayout();
			this.flpControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlLinkedAssembly
			// 
			this.pnlLinkedAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlLinkedAssembly.Controls.Add(this.btnBrowseAssembly);
			this.pnlLinkedAssembly.Controls.Add(this.txtLinkedAssemblyPath);
			this.pnlLinkedAssembly.Controls.Add(this.label2);
			this.pnlLinkedAssembly.Enabled = false;
			this.pnlLinkedAssembly.Location = new System.Drawing.Point(3, 85);
			this.pnlLinkedAssembly.Name = "pnlLinkedAssembly";
			this.pnlLinkedAssembly.Size = new System.Drawing.Size(446, 30);
			this.pnlLinkedAssembly.TabIndex = 8;
			// 
			// btnBrowseAssembly
			// 
			this.btnBrowseAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseAssembly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseAssembly.Location = new System.Drawing.Point(404, 3);
			this.btnBrowseAssembly.Name = "btnBrowseAssembly";
			this.btnBrowseAssembly.Size = new System.Drawing.Size(38, 23);
			this.btnBrowseAssembly.TabIndex = 2;
			this.btnBrowseAssembly.Text = "...";
			this.btnBrowseAssembly.UseVisualStyleBackColor = true;
			this.btnBrowseAssembly.Click += new System.EventHandler(this.btnBrowseAssembly_Click);
			// 
			// txtLinkedAssemblyPath
			// 
			this.txtLinkedAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLinkedAssemblyPath.Location = new System.Drawing.Point(55, 3);
			this.txtLinkedAssemblyPath.Name = "txtLinkedAssemblyPath";
			this.txtLinkedAssemblyPath.ReadOnly = true;
			this.txtLinkedAssemblyPath.Size = new System.Drawing.Size(344, 23);
			this.txtLinkedAssemblyPath.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 22);
			this.label2.TabIndex = 0;
			this.label2.Text = "Pfad:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rbLinked
			// 
			this.rbLinked.AutoSize = true;
			this.rbLinked.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.flpControls.SetFlowBreak(this.rbLinked, true);
			this.rbLinked.Location = new System.Drawing.Point(3, 59);
			this.rbLinked.Name = "rbLinked";
			this.rbLinked.Size = new System.Drawing.Size(196, 20);
			this.rbLinked.TabIndex = 7;
			this.rbLinked.TabStop = true;
			this.rbLinked.Text = "Version aus Assembly ermitteln";
			this.rbLinked.UseVisualStyleBackColor = true;
			this.rbLinked.CheckedChanged += new System.EventHandler(this.rbLinked_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.flpControls.SetFlowBreak(this.label1, true);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(467, 30);
			this.label1.TabIndex = 5;
			this.label1.Text = "Legen Sie hier fest, ob bei neuen Updatepaketen die Versionsnummer automatisch vo" +
				"n einer Anwendung ermittelt werden soll.";
			// 
			// rbNotLinked
			// 
			this.rbNotLinked.AutoSize = true;
			this.rbNotLinked.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.flpControls.SetFlowBreak(this.rbNotLinked, true);
			this.rbNotLinked.Location = new System.Drawing.Point(3, 33);
			this.rbNotLinked.Name = "rbNotLinked";
			this.rbNotLinked.Size = new System.Drawing.Size(152, 20);
			this.rbNotLinked.TabIndex = 6;
			this.rbNotLinked.TabStop = true;
			this.rbNotLinked.Text = "Version manuell setzen";
			this.rbNotLinked.UseVisualStyleBackColor = true;
			// 
			// flpControls
			// 
			this.flpControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flpControls.Controls.Add(this.label1);
			this.flpControls.Controls.Add(this.rbNotLinked);
			this.flpControls.Controls.Add(this.rbLinked);
			this.flpControls.Controls.Add(this.pnlLinkedAssembly);
			this.flpControls.Location = new System.Drawing.Point(3, 3);
			this.flpControls.Name = "flpControls";
			this.flpControls.Size = new System.Drawing.Size(488, 126);
			this.flpControls.TabIndex = 9;
			// 
			// sspLinkedAssemblyVersion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flpControls);
			this.displayOrder = 700;
			this.MinimumSize = new System.Drawing.Size(390, 100);
			this.Name = "sspLinkedAssemblyVersion";
			this.Size = new System.Drawing.Size(497, 135);
			this.Title = "Versionsverknüpfung";
			this.pnlLinkedAssembly.ResumeLayout(false);
			this.pnlLinkedAssembly.PerformLayout();
			this.flpControls.ResumeLayout(false);
			this.flpControls.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlLinkedAssembly;
		private System.Windows.Forms.Button btnBrowseAssembly;
		private System.Windows.Forms.TextBox txtLinkedAssemblyPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbLinked;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbNotLinked;
		private System.Windows.Forms.FlowLayoutPanel flpControls;
	}
}
