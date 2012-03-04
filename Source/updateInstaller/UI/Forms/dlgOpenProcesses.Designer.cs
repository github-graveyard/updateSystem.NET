namespace updateSystemDotNet.Updater.UI.Forms
{
    partial class dlgOpenProcesses
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imgProcess = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwProcesses = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnKillProcess = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.flpBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // flpBottom
            // 
            this.flpBottom.AutoSize = true;
            this.flpBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpBottom.BackColor = System.Drawing.Color.Transparent;
            this.flpBottom.Controls.Add(this.btnCancel);
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBottom.Location = new System.Drawing.Point(0, 187);
            this.flpBottom.MaximumSize = new System.Drawing.Size(0, 34);
            this.flpBottom.MinimumSize = new System.Drawing.Size(0, 34);
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Padding = new System.Windows.Forms.Padding(3);
            this.flpBottom.Size = new System.Drawing.Size(379, 34);
            this.flpBottom.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(297, 6);
            this.btnCancel.MinimumSize = new System.Drawing.Size(64, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // imgProcess
            // 
            this.imgProcess.Location = new System.Drawing.Point(12, 12);
            this.imgProcess.Name = "imgProcess";
            this.imgProcess.Size = new System.Drawing.Size(50, 50);
            this.imgProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgProcess.TabIndex = 5;
            this.imgProcess.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.lblTitle.Location = new System.Drawing.Point(68, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(247, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Das Update kann nicht fortgesetzt werden";
            // 
            // lvwProcesses
            // 
            this.lvwProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwProcesses.FullRowSelect = true;
            this.lvwProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwProcesses.Location = new System.Drawing.Point(12, 68);
            this.lvwProcesses.MultiSelect = false;
            this.lvwProcesses.Name = "lvwProcesses";
            this.lvwProcesses.Size = new System.Drawing.Size(247, 113);
            this.lvwProcesses.TabIndex = 7;
            this.lvwProcesses.UseCompatibleStateImageBehavior = false;
            this.lvwProcesses.View = System.Windows.Forms.View.Details;
            this.lvwProcesses.SelectedIndexChanged += new System.EventHandler(this.lvwProcesses_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Prozessname";
            this.columnHeader1.Width = 219;
            // 
            // btnKillProcess
            // 
            this.btnKillProcess.Enabled = false;
            this.btnKillProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKillProcess.Location = new System.Drawing.Point(265, 68);
            this.btnKillProcess.Name = "btnKillProcess";
            this.btnKillProcess.Size = new System.Drawing.Size(105, 23);
            this.btnKillProcess.TabIndex = 8;
            this.btnKillProcess.Text = "Prozess beenden";
            this.btnKillProcess.UseVisualStyleBackColor = true;
            this.btnKillProcess.Click += new System.EventHandler(this.btnKillProcess_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.Location = new System.Drawing.Point(265, 97);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Liste aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(68, 34);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(302, 28);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Die folgenden Prozesse müssen beendet werden, damit der Updatevorgang fortgesetzt" +
                " werden kann:";
            // 
            // dlgOpenProcesses
            // 
            this.ClientSize = new System.Drawing.Size(379, 221);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnKillProcess);
            this.Controls.Add(this.lvwProcesses);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.imgProcess);
            this.Controls.Add(this.flpBottom);
            this.DrawTop = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgOpenProcesses";
            this.Text = "updateSystemDotNet Updateinstaller";
            this.flpBottom.ResumeLayout(false);
            this.flpBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox imgProcess;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwProcesses;
        private System.Windows.Forms.Button btnKillProcess;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
