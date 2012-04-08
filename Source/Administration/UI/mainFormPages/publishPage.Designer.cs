using System;

namespace updateSystemDotNet.Administration.UI.mainFormPages {
	partial class publishPage {
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
			this.lvwPublish = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.clmLastPublishedAt = new System.Windows.Forms.ColumnHeader();
			this.btnPublishNow = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvwPublish
			// 
			this.lvwPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwPublish.CheckBoxes = true;
			this.lvwPublish.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmLastPublishedAt});
			this.lvwPublish.FullRowSelect = true;
			this.lvwPublish.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwPublish.Location = new System.Drawing.Point(0, 24);
			this.lvwPublish.Name = "lvwPublish";
			this.lvwPublish.Size = new System.Drawing.Size(482, 155);
			this.lvwPublish.TabIndex = 5;
			this.lvwPublish.UseCompatibleStateImageBehavior = false;
			this.lvwPublish.View = System.Windows.Forms.View.Details;
			this.lvwPublish.SelectedIndexChanged += new System.EventHandler(this.lvwPublish_SelectedIndexChanged);
			// 
			// clmName
			// 
			this.clmName.Text = "Name";
			this.clmName.Width = 300;
			// 
			// clmLastPublishedAt
			// 
			this.clmLastPublishedAt.Text = "Zuletzt ausgeführt";
			this.clmLastPublishedAt.Width = 150;
			// 
			// btnPublishNow
			// 
			this.btnPublishNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPublishNow.AutoSize = true;
			this.btnPublishNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPublishNow.Location = new System.Drawing.Point(341, 185);
			this.btnPublishNow.Name = "btnPublishNow";
			this.btnPublishNow.Size = new System.Drawing.Size(141, 25);
			this.btnPublishNow.TabIndex = 6;
			this.btnPublishNow.Text = "Jetzt Veröffentlichen";
			this.btnPublishNow.UseVisualStyleBackColor = true;
			this.btnPublishNow.Click += new System.EventHandler(this.btnPublishNow_Click);
			// 
			// publishPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnPublishNow);
			this.Controls.Add(this.lvwPublish);
			this.Name = "publishPage";
			this.Size = new System.Drawing.Size(482, 213);
			this.Controls.SetChildIndex(this.lvwPublish, 0);
			this.Controls.SetChildIndex(this.btnPublishNow, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.extendedListView lvwPublish;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmLastPublishedAt;
		private System.Windows.Forms.Button btnPublishNow;
	}
}
