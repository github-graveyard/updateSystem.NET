using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.updateActionEditor
{
    partial class closeProcessActionEditor
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
			this.lvwProcesses = new extendedListView();
			this.clmProcess = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnAddProcess = new System.Windows.Forms.Button();
			this.btnRemoveProcess = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lvwProcesses
			// 
			this.lvwProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmProcess});
			this.lvwProcesses.FullRowSelect = true;
			this.lvwProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwProcesses.Location = new System.Drawing.Point(3, 126);
			this.lvwProcesses.MultiSelect = false;
			this.lvwProcesses.Name = "lvwProcesses";
			this.lvwProcesses.Size = new System.Drawing.Size(369, 229);
			this.lvwProcesses.TabIndex = 0;
			this.lvwProcesses.UseCompatibleStateImageBehavior = false;
			this.lvwProcesses.View = System.Windows.Forms.View.Details;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(-3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(504, 36);
			this.label1.TabIndex = 1;
			this.label1.Text = "Geben Sie hier die Namen der Prozesse (ohne .exe am Ende) an, welche geschlossen " +
				"werden sollen.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(30, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Prozessname:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(133, 92);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(240, 23);
			this.txtName.TabIndex = 3;
			// 
			// btnAddProcess
			// 
			this.btnAddProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddProcess.AutoSize = true;
			this.btnAddProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddProcess.Location = new System.Drawing.Point(380, 92);
			this.btnAddProcess.Name = "btnAddProcess";
			this.btnAddProcess.Size = new System.Drawing.Size(117, 25);
			this.btnAddProcess.TabIndex = 4;
			this.btnAddProcess.Text = "Hinzufügen";
			this.btnAddProcess.UseVisualStyleBackColor = true;
			this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
			// 
			// btnRemoveProcess
			// 
			this.btnRemoveProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveProcess.AutoSize = true;
			this.btnRemoveProcess.Enabled = false;
			this.btnRemoveProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveProcess.Location = new System.Drawing.Point(380, 126);
			this.btnRemoveProcess.Name = "btnRemoveProcess";
			this.btnRemoveProcess.Size = new System.Drawing.Size(117, 25);
			this.btnRemoveProcess.TabIndex = 5;
			this.btnRemoveProcess.Text = "Entfernen";
			this.btnRemoveProcess.UseVisualStyleBackColor = true;
			this.btnRemoveProcess.Click += new System.EventHandler(this.btnRemoveProcess_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(-3, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(504, 46);
			this.label3.TabIndex = 6;
			this.label3.Text = "Hinweis: Nutzen Sie diese Aktion nicht um Ihre eigene Anwendung zu beenden. Verwe" +
				"nden Sie anstelle dessen das \"updateInstallerStarted\"-Event des updateController" +
				"s.";
			// 
			// closeProcessActionEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnRemoveProcess);
			this.Controls.Add(this.btnAddProcess);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lvwProcesses);
			this.Name = "closeProcessActionEditor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private UI.Controls.extendedListView lvwProcesses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAddProcess;
        private System.Windows.Forms.Button btnRemoveProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader clmProcess;
    }
}
