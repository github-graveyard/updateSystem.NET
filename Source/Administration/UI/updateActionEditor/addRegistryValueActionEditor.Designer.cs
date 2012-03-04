namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class addRegistryValueActionEditor
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
			this.seperatorLabel2 = new updateSystemDotNet.Administration.UI.Controls.seperatorLabel();
        	this.lvwValues = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cboValueTypes = new System.Windows.Forms.ComboBox();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAddValue = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// seperatorLabel1
			// 
			this.seperatorLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.seperatorLabel1.Location = new System.Drawing.Point(3, 58);
			this.seperatorLabel1.Name = "seperatorLabel1";
			this.seperatorLabel1.Size = new System.Drawing.Size(493, 21);
			this.seperatorLabel1.TabIndex = 4;
			this.seperatorLabel1.Text = "Eintrag hinzufügen/bearbeiten";
			this.seperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// seperatorLabel2
			// 
			this.seperatorLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.seperatorLabel2.Location = new System.Drawing.Point(3, 180);
			this.seperatorLabel2.Name = "seperatorLabel2";
			this.seperatorLabel2.Size = new System.Drawing.Size(493, 21);
			this.seperatorLabel2.TabIndex = 5;
			this.seperatorLabel2.Text = "Einträge";
			this.seperatorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvwValues
			// 
			this.lvwValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lvwValues.FullRowSelect = true;
			this.lvwValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwValues.Location = new System.Drawing.Point(7, 204);
			this.lvwValues.MultiSelect = false;
			this.lvwValues.Name = "lvwValues";
			this.lvwValues.Size = new System.Drawing.Size(489, 151);
			this.lvwValues.TabIndex = 6;
			this.lvwValues.UseCompatibleStateImageBehavior = false;
			this.lvwValues.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 135;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Wert";
			this.columnHeader2.Width = 190;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Typ";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 25);
			this.label3.TabIndex = 7;
			this.label3.Text = "Name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(66, 82);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(213, 23);
			this.txtName.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(287, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "Typ:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboValueTypes
			// 
			this.cboValueTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboValueTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboValueTypes.FormattingEnabled = true;
			this.cboValueTypes.Location = new System.Drawing.Point(337, 83);
			this.cboValueTypes.Name = "cboValueTypes";
			this.cboValueTypes.Size = new System.Drawing.Size(159, 23);
			this.cboValueTypes.TabIndex = 10;
			// 
			// txtValue
			// 
			this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtValue.Location = new System.Drawing.Point(66, 114);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(430, 23);
			this.txtValue.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 114);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 25);
			this.label5.TabIndex = 11;
			this.label5.Text = "Wert:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAddValue
			// 
			this.btnAddValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddValue.AutoSize = true;
			this.btnAddValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddValue.Location = new System.Drawing.Point(413, 143);
			this.btnAddValue.Name = "btnAddValue";
			this.btnAddValue.Size = new System.Drawing.Size(83, 24);
			this.btnAddValue.TabIndex = 13;
			this.btnAddValue.Text = "Hinzufügen";
			this.btnAddValue.UseVisualStyleBackColor = true;
			this.btnAddValue.Click += new System.EventHandler(this.btnAddValue_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.AutoSize = true;
			this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemove.Location = new System.Drawing.Point(335, 143);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 24);
			this.btnRemove.TabIndex = 14;
			this.btnRemove.Text = "Entfernen";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Visible = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// addRegistryValueActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAddValue);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cboValueTypes);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lvwValues);
			this.Controls.Add(this.seperatorLabel2);
			this.Controls.Add(this.seperatorLabel1);
			this.Name = "addRegistryValueActionEditor";
			this.Controls.SetChildIndex(this.seperatorLabel1, 0);
			this.Controls.SetChildIndex(this.seperatorLabel2, 0);
			this.Controls.SetChildIndex(this.lvwValues, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.txtName, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.cboValueTypes, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtValue, 0);
			this.Controls.SetChildIndex(this.btnAddValue, 0);
			this.Controls.SetChildIndex(this.btnRemove, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Controls.seperatorLabel seperatorLabel1;
        private Controls.seperatorLabel seperatorLabel2;
        private UI.Controls.extendedListView lvwValues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboValueTypes;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddValue;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
