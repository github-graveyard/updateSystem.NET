namespace updateSystemDotNet.Updater.UI.Forms
{
    partial class interactionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.imgInformation = new System.Windows.Forms.PictureBox();
            this.flpBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // flpBottom
            // 
            this.flpBottom.AutoSize = true;
            this.flpBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpBottom.BackColor = System.Drawing.Color.Transparent;
            this.flpBottom.Controls.Add(this.btnCancel);
            this.flpBottom.Controls.Add(this.btnOk);
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBottom.Location = new System.Drawing.Point(0, 118);
            this.flpBottom.MinimumSize = new System.Drawing.Size(0, 34);
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Padding = new System.Windows.Forms.Padding(3);
            this.flpBottom.Size = new System.Drawing.Size(350, 34);
            this.flpBottom.TabIndex = 13;
            this.flpBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.flpBottom_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(274, 6);
            this.btnCancel.MinimumSize = new System.Drawing.Size(64, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "#cancel#";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(204, 6);
            this.btnOk.MinimumSize = new System.Drawing.Size(64, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 22);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "#ok#";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(51, 51);
            this.lblMessage.MaximumSize = new System.Drawing.Size(288, 0);
            this.lblMessage.MinimumSize = new System.Drawing.Size(0, 50);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 50);
            this.lblMessage.TabIndex = 16;
            this.lblMessage.Text = "#message#";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 12);
            this.lblTitle.MaximumSize = new System.Drawing.Size(288, 0);
            this.lblTitle.MinimumSize = new System.Drawing.Size(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(54, 21);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "#title#";
            // 
            // imgInformation
            // 
            this.imgInformation.Location = new System.Drawing.Point(12, 12);
            this.imgInformation.Name = "imgInformation";
            this.imgInformation.Size = new System.Drawing.Size(32, 32);
            this.imgInformation.TabIndex = 14;
            this.imgInformation.TabStop = false;
            // 
            // interactionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 152);
            this.ControlBox = false;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.imgInformation);
            this.Controls.Add(this.flpBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "interactionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "updateSystem.Net updateInstaller";
            this.flpBottom.ResumeLayout(false);
            this.flpBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox imgInformation;
    }
}