namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class removeRegistryValuesActionEditor
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
			this.seperatorLabel1 = new updateSystemDotNet.Administration.UI.Controls.seperatorLabel();
			this.btnRemoveEntry = new System.Windows.Forms.Button();
			this.btnAddEntry = new System.Windows.Forms.Button();
			this.txtValueName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
        	this.lvwValues = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmValues = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// seperatorLabel1
			// 
			this.seperatorLabel1.Location = new System.Drawing.Point(3, 60);
			this.seperatorLabel1.Name = "seperatorLabel1";
			this.seperatorLabel1.Size = new System.Drawing.Size(493, 23);
			this.seperatorLabel1.TabIndex = 4;
			this.seperatorLabel1.Text = "Zu löschende Werte";
			this.seperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRemoveEntry
			// 
			this.btnRemoveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveEntry.Enabled = false;
			this.btnRemoveEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveEntry.Location = new System.Drawing.Point(397, 121);
			this.btnRemoveEntry.Name = "btnRemoveEntry";
			this.btnRemoveEntry.Size = new System.Drawing.Size(99, 25);
			this.btnRemoveEntry.TabIndex = 12;
			this.btnRemoveEntry.Text = "Entfernen";
			this.btnRemoveEntry.UseVisualStyleBackColor = true;
			this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
			// 
			// btnAddEntry
			// 
			this.btnAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddEntry.Location = new System.Drawing.Point(398, 90);
			this.btnAddEntry.Name = "btnAddEntry";
			this.btnAddEntry.Size = new System.Drawing.Size(99, 25);
			this.btnAddEntry.TabIndex = 11;
			this.btnAddEntry.Text = "Hinzufügen";
			this.btnAddEntry.UseVisualStyleBackColor = true;
			this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
			// 
			// txtValueName
			// 
			this.txtValueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtValueName.Location = new System.Drawing.Point(150, 89);
			this.txtValueName.Name = "txtValueName";
			this.txtValueName.Size = new System.Drawing.Size(240, 23);
			this.txtValueName.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 89);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 24);
			this.label3.TabIndex = 9;
			this.label3.Text = "Name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lvwValues
			// 
			this.lvwValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmValues});
			this.lvwValues.FullRowSelect = true;
			this.lvwValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwValues.Location = new System.Drawing.Point(7, 121);
			this.lvwValues.MultiSelect = false;
			this.lvwValues.Name = "lvwValues";
			this.lvwValues.Size = new System.Drawing.Size(383, 234);
			this.lvwValues.TabIndex = 8;
			this.lvwValues.UseCompatibleStateImageBehavior = false;
			this.lvwValues.View = System.Windows.Forms.View.Details;
			// 
			// removeRegistryValuesActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRemoveEntry);
			this.Controls.Add(this.btnAddEntry);
			this.Controls.Add(this.txtValueName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lvwValues);
			this.Controls.Add(this.seperatorLabel1);
			this.Name = "removeRegistryValuesActionEditor";
			this.Controls.SetChildIndex(this.seperatorLabel1, 0);
			this.Controls.SetChildIndex(this.lvwValues, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtValueName, 0);
			this.Controls.SetChildIndex(this.btnAddEntry, 0);
			this.Controls.SetChildIndex(this.btnRemoveEntry, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Controls.seperatorLabel seperatorLabel1;
        private System.Windows.Forms.Button btnRemoveEntry;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.TextBox txtValueName;
        private System.Windows.Forms.Label label3;
        private UI.Controls.extendedListView lvwValues;
        private System.Windows.Forms.ColumnHeader clmValues;
    }
}
