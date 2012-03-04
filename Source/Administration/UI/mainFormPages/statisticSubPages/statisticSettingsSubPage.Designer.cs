namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	partial class statisticSettingsSubPage {
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
			this.grpMaintenance = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.aclCleanup = new updateSystemDotNet.Administration.UI.Controls.actionLabel();
			this.btnCleanup = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.dtpCleanup = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.grpState = new updateSystemDotNet.Administration.UI.Controls.groupBoxEx();
			this.lblStateDescription = new System.Windows.Forms.Label();
			this.aclState = new updateSystemDotNet.Administration.UI.Controls.actionLabel();
			this.flpStatusControls = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAddProject = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnRemoveProjekt = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.btnUpdateState = new updateSystemDotNet.Administration.UI.Controls.buttonEx();
			this.bgwUpdateState = new System.ComponentModel.BackgroundWorker();
			this.bgwAddProject = new System.ComponentModel.BackgroundWorker();
			this.bgwDeleteProject = new System.ComponentModel.BackgroundWorker();
			this.bgwCleanup = new System.ComponentModel.BackgroundWorker();
			this.grpMaintenance.SuspendLayout();
			this.grpState.SuspendLayout();
			this.flpStatusControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpMaintenance
			// 
			this.grpMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpMaintenance.Controls.Add(this.aclCleanup);
			this.grpMaintenance.Controls.Add(this.btnCleanup);
			this.grpMaintenance.Controls.Add(this.dtpCleanup);
			this.grpMaintenance.Controls.Add(this.label1);
			this.grpMaintenance.Enabled = false;
			this.grpMaintenance.Location = new System.Drawing.Point(4, 191);
			this.grpMaintenance.Name = "grpMaintenance";
			this.grpMaintenance.Size = new System.Drawing.Size(474, 93);
			this.grpMaintenance.TabIndex = 1;
			this.grpMaintenance.TabStop = false;
			this.grpMaintenance.Text = "Wartung";
			// 
			// aclCleanup
			// 
			this.aclCleanup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.aclCleanup.BackColor = System.Drawing.Color.Transparent;
			this.aclCleanup.Location = new System.Drawing.Point(244, 61);
			this.aclCleanup.Name = "aclCleanup";
			this.aclCleanup.Size = new System.Drawing.Size(215, 23);
			this.aclCleanup.State = updateSystemDotNet.Administration.UI.Controls.actionLabelStates.Waiting;
			this.aclCleanup.suppressTextPadding = false;
			this.aclCleanup.TabIndex = 3;
			this.aclCleanup.Text = "Einträge werden gelöscht...";
			this.aclCleanup.Visible = false;
			// 
			// btnCleanup
			// 
			this.btnCleanup.AutoSize = true;
			this.btnCleanup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCleanup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCleanup.Location = new System.Drawing.Point(142, 60);
			this.btnCleanup.Name = "btnCleanup";
			this.btnCleanup.Size = new System.Drawing.Size(96, 24);
			this.btnCleanup.TabIndex = 2;
			this.btnCleanup.Text = "Daten löschen";
			this.btnCleanup.UseVisualStyleBackColor = true;
			this.btnCleanup.Click += new System.EventHandler(this.btnCleanup_Click);
			// 
			// dtpCleanup
			// 
			this.dtpCleanup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpCleanup.Location = new System.Drawing.Point(12, 61);
			this.dtpCleanup.Name = "dtpCleanup";
			this.dtpCleanup.Size = new System.Drawing.Size(117, 23);
			this.dtpCleanup.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(450, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hier können Sie Statistikeinträge von diesem Projekt löschen, die älter als das e" +
				"ingestellte Datum sind.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpState
			// 
			this.grpState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpState.Controls.Add(this.lblStateDescription);
			this.grpState.Controls.Add(this.aclState);
			this.grpState.Controls.Add(this.flpStatusControls);
			this.grpState.Location = new System.Drawing.Point(4, 30);
			this.grpState.Name = "grpState";
			this.grpState.Size = new System.Drawing.Size(471, 155);
			this.grpState.TabIndex = 2;
			this.grpState.TabStop = false;
			this.grpState.Text = "Status";
			// 
			// lblStateDescription
			// 
			this.lblStateDescription.Location = new System.Drawing.Point(15, 54);
			this.lblStateDescription.Name = "lblStateDescription";
			this.lblStateDescription.Size = new System.Drawing.Size(441, 61);
			this.lblStateDescription.TabIndex = 2;
			this.lblStateDescription.Text = "Statusbeschreibung ...";
			// 
			// aclState
			// 
			this.aclState.BackColor = System.Drawing.Color.Transparent;
			this.aclState.Location = new System.Drawing.Point(16, 26);
			this.aclState.Name = "aclState";
			this.aclState.Size = new System.Drawing.Size(443, 23);
			this.aclState.State = updateSystemDotNet.Administration.UI.Controls.actionLabelStates.Waiting;
			this.aclState.suppressTextPadding = true;
			this.aclState.TabIndex = 1;
			this.aclState.Text = "Projektstatus: Unbekannt";
			// 
			// flpStatusControls
			// 
			this.flpStatusControls.Controls.Add(this.btnAddProject);
			this.flpStatusControls.Controls.Add(this.btnRemoveProjekt);
			this.flpStatusControls.Controls.Add(this.btnUpdateState);
			this.flpStatusControls.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flpStatusControls.Location = new System.Drawing.Point(12, 118);
			this.flpStatusControls.Name = "flpStatusControls";
			this.flpStatusControls.Size = new System.Drawing.Size(447, 31);
			this.flpStatusControls.TabIndex = 0;
			// 
			// btnAddProject
			// 
			this.btnAddProject.AutoSize = true;
			this.btnAddProject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddProject.Location = new System.Drawing.Point(3, 3);
			this.btnAddProject.Name = "btnAddProject";
			this.btnAddProject.Size = new System.Drawing.Size(121, 24);
			this.btnAddProject.TabIndex = 0;
			this.btnAddProject.Text = "Projekt hinzufügen";
			this.btnAddProject.UseVisualStyleBackColor = true;
			this.btnAddProject.Visible = false;
			this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
			// 
			// btnRemoveProjekt
			// 
			this.btnRemoveProjekt.AutoSize = true;
			this.btnRemoveProjekt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRemoveProjekt.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveProjekt.Location = new System.Drawing.Point(130, 3);
			this.btnRemoveProjekt.Name = "btnRemoveProjekt";
			this.btnRemoveProjekt.Size = new System.Drawing.Size(112, 24);
			this.btnRemoveProjekt.TabIndex = 1;
			this.btnRemoveProjekt.Text = "Projekt entfernen";
			this.btnRemoveProjekt.UseVisualStyleBackColor = true;
			this.btnRemoveProjekt.Visible = false;
			this.btnRemoveProjekt.Click += new System.EventHandler(this.btnRemoveProjekt_Click);
			// 
			// btnUpdateState
			// 
			this.btnUpdateState.AutoSize = true;
			this.btnUpdateState.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnUpdateState.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdateState.Location = new System.Drawing.Point(248, 3);
			this.btnUpdateState.Name = "btnUpdateState";
			this.btnUpdateState.Size = new System.Drawing.Size(122, 24);
			this.btnUpdateState.TabIndex = 2;
			this.btnUpdateState.Text = "Status aktualisieren";
			this.btnUpdateState.UseVisualStyleBackColor = true;
			this.btnUpdateState.Click += new System.EventHandler(this.btnUpdateState_Click);
			// 
			// bgwUpdateState
			// 
			this.bgwUpdateState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdateState_DoWork);
			this.bgwUpdateState.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdateState_RunWorkerCompleted);
			// 
			// bgwAddProject
			// 
			this.bgwAddProject.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAddProject_DoWork);
			this.bgwAddProject.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAddProject_RunWorkerCompleted);
			// 
			// bgwDeleteProject
			// 
			this.bgwDeleteProject.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDeleteProject_DoWork);
			this.bgwDeleteProject.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDeleteProject_RunWorkerCompleted);
			// 
			// bgwCleanup
			// 
			this.bgwCleanup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCleanup_DoWork);
			this.bgwCleanup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCleanup_RunWorkerCompleted);
			// 
			// statisticSettingsSubPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpState);
			this.Controls.Add(this.grpMaintenance);
			this.Name = "statisticSettingsSubPage";
			this.pageName = "Einstellungen";
			this.Size = new System.Drawing.Size(478, 287);
			this.Title = "Statistikserver Einstellungen";
			this.Controls.SetChildIndex(this.grpMaintenance, 0);
			this.Controls.SetChildIndex(this.grpState, 0);
			this.grpMaintenance.ResumeLayout(false);
			this.grpMaintenance.PerformLayout();
			this.grpState.ResumeLayout(false);
			this.flpStatusControls.ResumeLayout(false);
			this.flpStatusControls.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpMaintenance;
		private updateSystemDotNet.Administration.UI.Controls.groupBoxEx grpState;
		private System.Windows.Forms.FlowLayoutPanel flpStatusControls;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnAddProject;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnRemoveProjekt;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnUpdateState;
		private updateSystemDotNet.Administration.UI.Controls.actionLabel aclState;
		private System.Windows.Forms.Label lblStateDescription;
		private System.ComponentModel.BackgroundWorker bgwUpdateState;
		private System.ComponentModel.BackgroundWorker bgwAddProject;
		private System.Windows.Forms.DateTimePicker dtpCleanup;
		private System.Windows.Forms.Label label1;
		private updateSystemDotNet.Administration.UI.Controls.buttonEx btnCleanup;
		private System.ComponentModel.BackgroundWorker bgwDeleteProject;
		private System.ComponentModel.BackgroundWorker bgwCleanup;
		private updateSystemDotNet.Administration.UI.Controls.actionLabel aclCleanup;
	}
}
