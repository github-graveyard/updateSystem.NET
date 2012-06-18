using System.Drawing;
using updateSystemDotNet.Administration.UI.Controls;

namespace updateSystemDotNet.Administration.UI.Dialogs
{
	sealed partial class updatePackageDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Allgemein");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Änderungen");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Eigene Felder");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Veröffentlichen");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Aktionen");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updatePackageDialog));
			this.tvwContent = new updateSystemDotNet.Administration.UI.Controls.explorerTreeView();
			this.imglMain = new System.Windows.Forms.ImageList(this.components);
			this.pnlContent = new System.Windows.Forms.Panel();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlGeneral = new System.Windows.Forms.Panel();
			this.chkServicePack = new System.Windows.Forms.CheckBox();
			this.lblServicePackDescription = new System.Windows.Forms.Label();
			this.lblPublishDescription = new System.Windows.Forms.Label();
			this.nmPreviewState = new System.Windows.Forms.NumericUpDown();
			this.cboReleaseState = new System.Windows.Forms.ComboBox();
			this.lblGeneralReleaseState = new System.Windows.Forms.Label();
			this.nmRevision = new System.Windows.Forms.NumericUpDown();
			this.nmBuild = new System.Windows.Forms.NumericUpDown();
			this.nmMinor = new System.Windows.Forms.NumericUpDown();
			this.nmMajor = new System.Windows.Forms.NumericUpDown();
			this.lblGeneralRevision = new System.Windows.Forms.Label();
			this.lblGeneralBuild = new System.Windows.Forms.Label();
			this.lblGeneralMinor = new System.Windows.Forms.Label();
			this.lblGeneralMajor = new System.Windows.Forms.Label();
			this.chkPublished = new System.Windows.Forms.CheckBox();
			this.cboTargetArchitecture = new System.Windows.Forms.ComboBox();
			this.lblGeneralArchitecture = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblGeneralVersion = new System.Windows.Forms.Label();
			this.lblGeneralDescription = new System.Windows.Forms.Label();
			this.pnlChanges = new System.Windows.Forms.Panel();
			this.txtChanges = new System.Windows.Forms.TextBox();
			this.pnlLanguage = new System.Windows.Forms.FlowLayoutPanel();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.cboLanguage = new System.Windows.Forms.ComboBox();
			this.btnImportChangeFromFile = new System.Windows.Forms.Button();
			this.pnlAvailability = new System.Windows.Forms.Panel();
			this.pnlCustomVersion = new System.Windows.Forms.Panel();
			this.lstCustomVersions = new System.Windows.Forms.ListBox();
			this.btnRemoveCustomVersion = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.btnAddCustomVersion = new System.Windows.Forms.Button();
			this.txtNewCustomVersion = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.rbCustomVersions = new System.Windows.Forms.RadioButton();
			this.rbAllVersions = new System.Windows.Forms.RadioButton();
			this.pnlActions = new System.Windows.Forms.Panel();
			this.lvwActions = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblActionsDescription = new System.Windows.Forms.Label();
			this.pnlBuildPackage = new System.Windows.Forms.Panel();
			this.lblErrorText = new System.Windows.Forms.Label();
			this.seperatorLabel1 = new updateSystemDotNet.Administration.UI.Controls.seperatorLabel();
			this.aclBuildPackage = new updateSystemDotNet.Administration.UI.Controls.actionLabel();
			this.pnlCustomFields = new System.Windows.Forms.Panel();
			this.lblCFDescription = new System.Windows.Forms.Label();
			this.btnRemoveCustomField = new System.Windows.Forms.Button();
			this.btnAddOrUpdateCustomField = new System.Windows.Forms.Button();
			this.txtCustomFieldValue = new System.Windows.Forms.TextBox();
			this.lblCFValue = new System.Windows.Forms.Label();
			this.txtCustomFieldKey = new System.Windows.Forms.TextBox();
			this.lblCFKey = new System.Windows.Forms.Label();
			this.lvwCustomFields = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmhKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmhValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonArea1 = new updateSystemDotNet.Administration.UI.Controls.buttonArea();
			this.bgwBuildPackage = new System.ComponentModel.BackgroundWorker();
			this.pnlPublish = new System.Windows.Forms.Panel();
			this.lvwPublishWith = new updateSystemDotNet.Administration.UI.Controls.extendedListView();
			this.clmDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblChoosePublishSource = new System.Windows.Forms.Label();
			this.pnlGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmPreviewState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmRevision)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmBuild)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMinor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMajor)).BeginInit();
			this.pnlChanges.SuspendLayout();
			this.pnlLanguage.SuspendLayout();
			this.pnlAvailability.SuspendLayout();
			this.pnlCustomVersion.SuspendLayout();
			this.pnlActions.SuspendLayout();
			this.pnlBuildPackage.SuspendLayout();
			this.pnlCustomFields.SuspendLayout();
			this.buttonArea1.SuspendLayout();
			this.pnlPublish.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvwContent
			// 
			this.tvwContent.AllowDrop = true;
			this.tvwContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvwContent.FullRowSelect = true;
			this.tvwContent.HideSelection = false;
			this.tvwContent.HotTracking = true;
			this.tvwContent.ImageIndex = 0;
			this.tvwContent.ImageList = this.imglMain;
			this.tvwContent.ItemHeight = 24;
			this.tvwContent.Location = new System.Drawing.Point(12, 12);
			this.tvwContent.Name = "tvwContent";
			treeNode1.Name = "nodeGeneral";
			treeNode1.Text = "Allgemein";
			treeNode2.Name = "nodeChanges";
			treeNode2.Text = "Änderungen";
			treeNode3.Name = "nodeCustomFields";
			treeNode3.Text = "Eigene Felder";
			treeNode4.Name = "nodePublish";
			treeNode4.Text = "Veröffentlichen";
			treeNode5.Name = "nodeActions";
			treeNode5.Text = "Aktionen";
			this.tvwContent.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
			this.tvwContent.SelectedImageIndex = 0;
			this.tvwContent.ShowLines = false;
			this.tvwContent.Size = new System.Drawing.Size(178, 311);
			this.tvwContent.TabIndex = 17;
			// 
			// imglMain
			// 
			this.imglMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imglMain.ImageSize = new System.Drawing.Size(16, 16);
			this.imglMain.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlContent
			// 
			this.pnlContent.Location = new System.Drawing.Point(196, 12);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(429, 311);
			this.pnlContent.TabIndex = 18;
			// 
			// btnOk
			// 
			this.btnOk.AutoSize = true;
			this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(402, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(135, 24);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "Updatepaket erstellen";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(543, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlGeneral
			// 
			this.pnlGeneral.Controls.Add(this.chkServicePack);
			this.pnlGeneral.Controls.Add(this.lblServicePackDescription);
			this.pnlGeneral.Controls.Add(this.lblPublishDescription);
			this.pnlGeneral.Controls.Add(this.nmPreviewState);
			this.pnlGeneral.Controls.Add(this.cboReleaseState);
			this.pnlGeneral.Controls.Add(this.lblGeneralReleaseState);
			this.pnlGeneral.Controls.Add(this.nmRevision);
			this.pnlGeneral.Controls.Add(this.nmBuild);
			this.pnlGeneral.Controls.Add(this.nmMinor);
			this.pnlGeneral.Controls.Add(this.nmMajor);
			this.pnlGeneral.Controls.Add(this.lblGeneralRevision);
			this.pnlGeneral.Controls.Add(this.lblGeneralBuild);
			this.pnlGeneral.Controls.Add(this.lblGeneralMinor);
			this.pnlGeneral.Controls.Add(this.lblGeneralMajor);
			this.pnlGeneral.Controls.Add(this.chkPublished);
			this.pnlGeneral.Controls.Add(this.cboTargetArchitecture);
			this.pnlGeneral.Controls.Add(this.lblGeneralArchitecture);
			this.pnlGeneral.Controls.Add(this.txtDescription);
			this.pnlGeneral.Controls.Add(this.lblGeneralVersion);
			this.pnlGeneral.Controls.Add(this.lblGeneralDescription);
			this.pnlGeneral.Location = new System.Drawing.Point(196, 12);
			this.pnlGeneral.Name = "pnlGeneral";
			this.pnlGeneral.Size = new System.Drawing.Size(429, 311);
			this.pnlGeneral.TabIndex = 19;
			// 
			// chkServicePack
			// 
			this.chkServicePack.AutoSize = true;
			this.chkServicePack.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkServicePack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.chkServicePack.Location = new System.Drawing.Point(107, 218);
			this.chkServicePack.Name = "chkServicePack";
			this.chkServicePack.Size = new System.Drawing.Size(103, 20);
			this.chkServicePack.TabIndex = 70;
			this.chkServicePack.Text = "Service Pack";
			this.chkServicePack.UseVisualStyleBackColor = true;
			// 
			// lblServicePackDescription
			// 
			this.lblServicePackDescription.Location = new System.Drawing.Point(107, 239);
			this.lblServicePackDescription.Name = "lblServicePackDescription";
			this.lblServicePackDescription.Size = new System.Drawing.Size(309, 70);
			this.lblServicePackDescription.TabIndex = 84;
			this.lblServicePackDescription.Text = resources.GetString("lblServicePackDescription.Text");
			// 
			// lblPublishDescription
			// 
			this.lblPublishDescription.Location = new System.Drawing.Point(108, 169);
			this.lblPublishDescription.Name = "lblPublishDescription";
			this.lblPublishDescription.Size = new System.Drawing.Size(308, 53);
			this.lblPublishDescription.TabIndex = 83;
			this.lblPublishDescription.Text = "Aktivieren Sie diese Option, wenn das Updatepaket als verfügbar gekennzeichnet we" +
    "rden- und damit allen Clients zum Download bereitstehen soll.";
			// 
			// nmPreviewState
			// 
			this.nmPreviewState.Enabled = false;
			this.nmPreviewState.Location = new System.Drawing.Point(229, 58);
			this.nmPreviewState.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.nmPreviewState.Name = "nmPreviewState";
			this.nmPreviewState.Size = new System.Drawing.Size(54, 23);
			this.nmPreviewState.TabIndex = 82;
			this.nmPreviewState.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cboReleaseState
			// 
			this.cboReleaseState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboReleaseState.FormattingEnabled = true;
			this.cboReleaseState.Items.AddRange(new object[] {
            "Alpha",
            "Beta",
            "Final"});
			this.cboReleaseState.Location = new System.Drawing.Point(107, 59);
			this.cboReleaseState.Name = "cboReleaseState";
			this.cboReleaseState.Size = new System.Drawing.Size(116, 23);
			this.cboReleaseState.TabIndex = 81;
			this.cboReleaseState.SelectedIndexChanged += new System.EventHandler(this.cboReleaseState_SelectedIndexChanged);
			// 
			// lblGeneralReleaseState
			// 
			this.lblGeneralReleaseState.Location = new System.Drawing.Point(12, 59);
			this.lblGeneralReleaseState.Name = "lblGeneralReleaseState";
			this.lblGeneralReleaseState.Size = new System.Drawing.Size(89, 21);
			this.lblGeneralReleaseState.TabIndex = 80;
			this.lblGeneralReleaseState.Text = "Releasestatus:";
			this.lblGeneralReleaseState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nmRevision
			// 
			this.nmRevision.Location = new System.Drawing.Point(305, 22);
			this.nmRevision.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nmRevision.Name = "nmRevision";
			this.nmRevision.Size = new System.Drawing.Size(60, 23);
			this.nmRevision.TabIndex = 79;
			// 
			// nmBuild
			// 
			this.nmBuild.Location = new System.Drawing.Point(239, 22);
			this.nmBuild.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nmBuild.Name = "nmBuild";
			this.nmBuild.Size = new System.Drawing.Size(60, 23);
			this.nmBuild.TabIndex = 78;
			// 
			// nmMinor
			// 
			this.nmMinor.Location = new System.Drawing.Point(173, 22);
			this.nmMinor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nmMinor.Name = "nmMinor";
			this.nmMinor.Size = new System.Drawing.Size(60, 23);
			this.nmMinor.TabIndex = 77;
			// 
			// nmMajor
			// 
			this.nmMajor.Location = new System.Drawing.Point(107, 22);
			this.nmMajor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nmMajor.Name = "nmMajor";
			this.nmMajor.Size = new System.Drawing.Size(60, 23);
			this.nmMajor.TabIndex = 76;
			// 
			// lblGeneralRevision
			// 
			this.lblGeneralRevision.Location = new System.Drawing.Point(300, 1);
			this.lblGeneralRevision.Name = "lblGeneralRevision";
			this.lblGeneralRevision.Size = new System.Drawing.Size(62, 18);
			this.lblGeneralRevision.TabIndex = 75;
			this.lblGeneralRevision.Text = "Revision:";
			this.lblGeneralRevision.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblGeneralBuild
			// 
			this.lblGeneralBuild.Location = new System.Drawing.Point(235, 1);
			this.lblGeneralBuild.Name = "lblGeneralBuild";
			this.lblGeneralBuild.Size = new System.Drawing.Size(62, 18);
			this.lblGeneralBuild.TabIndex = 74;
			this.lblGeneralBuild.Text = "Build:";
			this.lblGeneralBuild.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblGeneralMinor
			// 
			this.lblGeneralMinor.Location = new System.Drawing.Point(170, 1);
			this.lblGeneralMinor.Name = "lblGeneralMinor";
			this.lblGeneralMinor.Size = new System.Drawing.Size(62, 18);
			this.lblGeneralMinor.TabIndex = 73;
			this.lblGeneralMinor.Text = "Minor:";
			this.lblGeneralMinor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblGeneralMajor
			// 
			this.lblGeneralMajor.Location = new System.Drawing.Point(105, 1);
			this.lblGeneralMajor.Name = "lblGeneralMajor";
			this.lblGeneralMajor.Size = new System.Drawing.Size(62, 18);
			this.lblGeneralMajor.TabIndex = 72;
			this.lblGeneralMajor.Text = "Major:";
			this.lblGeneralMajor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// chkPublished
			// 
			this.chkPublished.AutoSize = true;
			this.chkPublished.Checked = true;
			this.chkPublished.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPublished.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkPublished.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.chkPublished.Location = new System.Drawing.Point(108, 148);
			this.chkPublished.Name = "chkPublished";
			this.chkPublished.Size = new System.Drawing.Size(112, 20);
			this.chkPublished.TabIndex = 71;
			this.chkPublished.Text = "Veröffentlicht";
			this.chkPublished.UseVisualStyleBackColor = true;
			// 
			// cboTargetArchitecture
			// 
			this.cboTargetArchitecture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTargetArchitecture.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cboTargetArchitecture.FormattingEnabled = true;
			this.cboTargetArchitecture.Items.AddRange(new object[] {
            "Any Cpu",
            "x86 (32 Bit Operating system)",
            "x64 (64 Bit Operating system)"});
			this.cboTargetArchitecture.Location = new System.Drawing.Point(107, 86);
			this.cboTargetArchitecture.Name = "cboTargetArchitecture";
			this.cboTargetArchitecture.Size = new System.Drawing.Size(176, 23);
			this.cboTargetArchitecture.TabIndex = 69;
			// 
			// lblGeneralArchitecture
			// 
			this.lblGeneralArchitecture.Location = new System.Drawing.Point(12, 86);
			this.lblGeneralArchitecture.Name = "lblGeneralArchitecture";
			this.lblGeneralArchitecture.Size = new System.Drawing.Size(89, 21);
			this.lblGeneralArchitecture.TabIndex = 68;
			this.lblGeneralArchitecture.Text = "Architektur:";
			this.lblGeneralArchitecture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(108, 118);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(308, 23);
			this.txtDescription.TabIndex = 67;
			// 
			// lblGeneralVersion
			// 
			this.lblGeneralVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblGeneralVersion.Location = new System.Drawing.Point(12, 20);
			this.lblGeneralVersion.Name = "lblGeneralVersion";
			this.lblGeneralVersion.Size = new System.Drawing.Size(66, 20);
			this.lblGeneralVersion.TabIndex = 65;
			this.lblGeneralVersion.Text = "Version:";
			this.lblGeneralVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblGeneralDescription
			// 
			this.lblGeneralDescription.Location = new System.Drawing.Point(12, 118);
			this.lblGeneralDescription.Name = "lblGeneralDescription";
			this.lblGeneralDescription.Size = new System.Drawing.Size(89, 22);
			this.lblGeneralDescription.TabIndex = 66;
			this.lblGeneralDescription.Text = "Beschreibung:";
			this.lblGeneralDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlChanges
			// 
			this.pnlChanges.Controls.Add(this.txtChanges);
			this.pnlChanges.Controls.Add(this.pnlLanguage);
			this.pnlChanges.Location = new System.Drawing.Point(196, 12);
			this.pnlChanges.Name = "pnlChanges";
			this.pnlChanges.Size = new System.Drawing.Size(429, 311);
			this.pnlChanges.TabIndex = 20;
			// 
			// txtChanges
			// 
			this.txtChanges.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtChanges.Location = new System.Drawing.Point(0, 30);
			this.txtChanges.Multiline = true;
			this.txtChanges.Name = "txtChanges";
			this.txtChanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChanges.Size = new System.Drawing.Size(429, 281);
			this.txtChanges.TabIndex = 2;
			// 
			// pnlLanguage
			// 
			this.pnlLanguage.Controls.Add(this.lblLanguage);
			this.pnlLanguage.Controls.Add(this.cboLanguage);
			this.pnlLanguage.Controls.Add(this.btnImportChangeFromFile);
			this.pnlLanguage.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlLanguage.Location = new System.Drawing.Point(0, 0);
			this.pnlLanguage.Name = "pnlLanguage";
			this.pnlLanguage.Size = new System.Drawing.Size(429, 30);
			this.pnlLanguage.TabIndex = 1;
			// 
			// lblLanguage
			// 
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(3, 3);
			this.lblLanguage.Margin = new System.Windows.Forms.Padding(3);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Padding = new System.Windows.Forms.Padding(3);
			this.lblLanguage.Size = new System.Drawing.Size(58, 21);
			this.lblLanguage.TabIndex = 2;
			this.lblLanguage.Text = "Sprache:";
			this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboLanguage
			// 
			this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLanguage.FormattingEnabled = true;
			this.cboLanguage.Items.AddRange(new object[] {
            "Deutsch/German",
            "Englisch/Enlish"});
			this.cboLanguage.Location = new System.Drawing.Point(67, 3);
			this.cboLanguage.Name = "cboLanguage";
			this.cboLanguage.Size = new System.Drawing.Size(155, 23);
			this.cboLanguage.TabIndex = 3;
			// 
			// btnImportChangeFromFile
			// 
			this.btnImportChangeFromFile.AutoSize = true;
			this.btnImportChangeFromFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnImportChangeFromFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnImportChangeFromFile.Location = new System.Drawing.Point(228, 3);
			this.btnImportChangeFromFile.Name = "btnImportChangeFromFile";
			this.btnImportChangeFromFile.Size = new System.Drawing.Size(112, 24);
			this.btnImportChangeFromFile.TabIndex = 4;
			this.btnImportChangeFromFile.Text = "Aus Datei laden...";
			this.btnImportChangeFromFile.UseVisualStyleBackColor = true;
			this.btnImportChangeFromFile.Click += new System.EventHandler(this.btnImportChangeFromFile_Click);
			// 
			// pnlAvailability
			// 
			this.pnlAvailability.Controls.Add(this.pnlCustomVersion);
			this.pnlAvailability.Controls.Add(this.label13);
			this.pnlAvailability.Controls.Add(this.label12);
			this.pnlAvailability.Controls.Add(this.rbCustomVersions);
			this.pnlAvailability.Controls.Add(this.rbAllVersions);
			this.pnlAvailability.Location = new System.Drawing.Point(196, 12);
			this.pnlAvailability.Name = "pnlAvailability";
			this.pnlAvailability.Size = new System.Drawing.Size(429, 311);
			this.pnlAvailability.TabIndex = 21;
			// 
			// pnlCustomVersion
			// 
			this.pnlCustomVersion.Controls.Add(this.lstCustomVersions);
			this.pnlCustomVersion.Controls.Add(this.btnRemoveCustomVersion);
			this.pnlCustomVersion.Controls.Add(this.label14);
			this.pnlCustomVersion.Controls.Add(this.btnAddCustomVersion);
			this.pnlCustomVersion.Controls.Add(this.txtNewCustomVersion);
			this.pnlCustomVersion.Enabled = false;
			this.pnlCustomVersion.Location = new System.Drawing.Point(20, 119);
			this.pnlCustomVersion.Name = "pnlCustomVersion";
			this.pnlCustomVersion.Size = new System.Drawing.Size(401, 137);
			this.pnlCustomVersion.TabIndex = 14;
			// 
			// lstCustomVersions
			// 
			this.lstCustomVersions.FormattingEnabled = true;
			this.lstCustomVersions.ItemHeight = 15;
			this.lstCustomVersions.Location = new System.Drawing.Point(3, 35);
			this.lstCustomVersions.Name = "lstCustomVersions";
			this.lstCustomVersions.Size = new System.Drawing.Size(283, 94);
			this.lstCustomVersions.TabIndex = 4;
			this.lstCustomVersions.SelectedIndexChanged += new System.EventHandler(this.lstCustomVersions_SelectedIndexChanged);
			// 
			// btnRemoveCustomVersion
			// 
			this.btnRemoveCustomVersion.Enabled = false;
			this.btnRemoveCustomVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveCustomVersion.Location = new System.Drawing.Point(295, 34);
			this.btnRemoveCustomVersion.Name = "btnRemoveCustomVersion";
			this.btnRemoveCustomVersion.Size = new System.Drawing.Size(101, 23);
			this.btnRemoveCustomVersion.TabIndex = 8;
			this.btnRemoveCustomVersion.Text = "Entfernen";
			this.btnRemoveCustomVersion.UseVisualStyleBackColor = true;
			this.btnRemoveCustomVersion.Click += new System.EventHandler(this.btnRemoveCustomVersion_Click);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(35, 4);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(103, 22);
			this.label14.TabIndex = 5;
			this.label14.Text = "Versionsnummer:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAddCustomVersion
			// 
			this.btnAddCustomVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddCustomVersion.Location = new System.Drawing.Point(295, 6);
			this.btnAddCustomVersion.Name = "btnAddCustomVersion";
			this.btnAddCustomVersion.Size = new System.Drawing.Size(101, 23);
			this.btnAddCustomVersion.TabIndex = 7;
			this.btnAddCustomVersion.Text = "Hinzufügen";
			this.btnAddCustomVersion.UseVisualStyleBackColor = true;
			this.btnAddCustomVersion.Click += new System.EventHandler(this.btnAddCustomVersion_Click);
			// 
			// txtNewCustomVersion
			// 
			this.txtNewCustomVersion.Location = new System.Drawing.Point(144, 6);
			this.txtNewCustomVersion.Name = "txtNewCustomVersion";
			this.txtNewCustomVersion.Size = new System.Drawing.Size(142, 23);
			this.txtNewCustomVersion.TabIndex = 6;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(17, 78);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(404, 30);
			this.label13.TabIndex = 13;
			this.label13.Text = "Dieses Updatepaket steht allen kleineren Versionen zur Verfügung welche zusätzlic" +
    "h auf folgender Liste aufgeführt sein müssen:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(404, 30);
			this.label12.TabIndex = 12;
			this.label12.Text = "Dieses Updatepaket steht allen kleineren Versionen zur Verfügung.";
			// 
			// rbCustomVersions
			// 
			this.rbCustomVersions.AutoSize = true;
			this.rbCustomVersions.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbCustomVersions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.rbCustomVersions.Location = new System.Drawing.Point(3, 57);
			this.rbCustomVersions.Name = "rbCustomVersions";
			this.rbCustomVersions.Size = new System.Drawing.Size(231, 20);
			this.rbCustomVersions.TabIndex = 11;
			this.rbCustomVersions.Text = "Verfügbar für bestimmte Versionen";
			this.rbCustomVersions.UseVisualStyleBackColor = true;
			// 
			// rbAllVersions
			// 
			this.rbAllVersions.AutoSize = true;
			this.rbAllVersions.Checked = true;
			this.rbAllVersions.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbAllVersions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.rbAllVersions.Location = new System.Drawing.Point(3, 3);
			this.rbAllVersions.Name = "rbAllVersions";
			this.rbAllVersions.Size = new System.Drawing.Size(189, 20);
			this.rbAllVersions.TabIndex = 10;
			this.rbAllVersions.TabStop = true;
			this.rbAllVersions.Text = "Verfügbar für alle Versionen";
			this.rbAllVersions.UseVisualStyleBackColor = true;
			// 
			// pnlActions
			// 
			this.pnlActions.Controls.Add(this.lvwActions);
			this.pnlActions.Controls.Add(this.lblActionsDescription);
			this.pnlActions.Location = new System.Drawing.Point(196, 12);
			this.pnlActions.Name = "pnlActions";
			this.pnlActions.Size = new System.Drawing.Size(429, 311);
			this.pnlActions.TabIndex = 22;
			// 
			// lvwActions
			// 
			this.lvwActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmDescription});
			this.lvwActions.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lvwActions.FullRowSelect = true;
			this.lvwActions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwActions.LargeImageList = this.imglMain;
			this.lvwActions.Location = new System.Drawing.Point(0, 69);
			this.lvwActions.MultiSelect = false;
			this.lvwActions.Name = "lvwActions";
			this.lvwActions.ShowItemToolTips = true;
			this.lvwActions.Size = new System.Drawing.Size(429, 242);
			this.lvwActions.SmallImageList = this.imglMain;
			this.lvwActions.TabIndex = 0;
			this.lvwActions.TileSize = new System.Drawing.Size(300, 35);
			this.lvwActions.UseCompatibleStateImageBehavior = false;
			this.lvwActions.View = System.Windows.Forms.View.Tile;
			// 
			// clmName
			// 
			this.clmName.Width = 300;
			// 
			// clmDescription
			// 
			this.clmDescription.Width = 300;
			// 
			// lblActionsDescription
			// 
			this.lblActionsDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblActionsDescription.Location = new System.Drawing.Point(0, 0);
			this.lblActionsDescription.Name = "lblActionsDescription";
			this.lblActionsDescription.Size = new System.Drawing.Size(429, 66);
			this.lblActionsDescription.TabIndex = 1;
			this.lblActionsDescription.Text = resources.GetString("lblActionsDescription.Text");
			this.lblActionsDescription.UseMnemonic = false;
			// 
			// pnlBuildPackage
			// 
			this.pnlBuildPackage.Controls.Add(this.lblErrorText);
			this.pnlBuildPackage.Controls.Add(this.seperatorLabel1);
			this.pnlBuildPackage.Controls.Add(this.aclBuildPackage);
			this.pnlBuildPackage.Location = new System.Drawing.Point(196, 12);
			this.pnlBuildPackage.Name = "pnlBuildPackage";
			this.pnlBuildPackage.Size = new System.Drawing.Size(429, 311);
			this.pnlBuildPackage.TabIndex = 23;
			// 
			// lblErrorText
			// 
			this.lblErrorText.Location = new System.Drawing.Point(3, 85);
			this.lblErrorText.Name = "lblErrorText";
			this.lblErrorText.Size = new System.Drawing.Size(423, 83);
			this.lblErrorText.TabIndex = 2;
			this.lblErrorText.Text = "Hier kommt der Errortext...";
			this.lblErrorText.Visible = false;
			// 
			// seperatorLabel1
			// 
			this.seperatorLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.seperatorLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
			this.seperatorLabel1.Location = new System.Drawing.Point(3, 3);
			this.seperatorLabel1.Name = "seperatorLabel1";
			this.seperatorLabel1.Size = new System.Drawing.Size(426, 23);
			this.seperatorLabel1.TabIndex = 1;
			this.seperatorLabel1.Text = "Updatepaket erstellen";
			this.seperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// aclBuildPackage
			// 
			this.aclBuildPackage.BackColor = System.Drawing.Color.Transparent;
			this.aclBuildPackage.Location = new System.Drawing.Point(6, 36);
			this.aclBuildPackage.Name = "aclBuildPackage";
			this.aclBuildPackage.Size = new System.Drawing.Size(423, 23);
			this.aclBuildPackage.State = updateSystemDotNet.Administration.UI.Controls.actionLabelStates.Waiting;
			this.aclBuildPackage.suppressTextPadding = false;
			this.aclBuildPackage.TabIndex = 0;
			this.aclBuildPackage.Text = "Updatepaket erzeugen und komprimieren";
			// 
			// pnlCustomFields
			// 
			this.pnlCustomFields.Controls.Add(this.lblCFDescription);
			this.pnlCustomFields.Controls.Add(this.btnRemoveCustomField);
			this.pnlCustomFields.Controls.Add(this.btnAddOrUpdateCustomField);
			this.pnlCustomFields.Controls.Add(this.txtCustomFieldValue);
			this.pnlCustomFields.Controls.Add(this.lblCFValue);
			this.pnlCustomFields.Controls.Add(this.txtCustomFieldKey);
			this.pnlCustomFields.Controls.Add(this.lblCFKey);
			this.pnlCustomFields.Controls.Add(this.lvwCustomFields);
			this.pnlCustomFields.Location = new System.Drawing.Point(196, 12);
			this.pnlCustomFields.Name = "pnlCustomFields";
			this.pnlCustomFields.Size = new System.Drawing.Size(429, 311);
			this.pnlCustomFields.TabIndex = 24;
			this.pnlCustomFields.Visible = false;
			// 
			// lblCFDescription
			// 
			this.lblCFDescription.Location = new System.Drawing.Point(0, 0);
			this.lblCFDescription.Name = "lblCFDescription";
			this.lblCFDescription.Size = new System.Drawing.Size(429, 48);
			this.lblCFDescription.TabIndex = 8;
			this.lblCFDescription.Text = "Hier können Sie beliebige Werte definieren, auf welche Sie über die Eigenschaft \'" +
    "customFields\' des entsprechenden Updatepakets und dem festgelegten Namen zugreif" +
    "en können.";
			// 
			// btnRemoveCustomField
			// 
			this.btnRemoveCustomField.AutoSize = true;
			this.btnRemoveCustomField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRemoveCustomField.Enabled = false;
			this.btnRemoveCustomField.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveCustomField.Location = new System.Drawing.Point(265, 80);
			this.btnRemoveCustomField.Name = "btnRemoveCustomField";
			this.btnRemoveCustomField.Size = new System.Drawing.Size(72, 24);
			this.btnRemoveCustomField.TabIndex = 7;
			this.btnRemoveCustomField.Text = "Entfernen";
			this.btnRemoveCustomField.UseVisualStyleBackColor = true;
			this.btnRemoveCustomField.Click += new System.EventHandler(this.btnRemoveCustomField_Click);
			// 
			// btnAddOrUpdateCustomField
			// 
			this.btnAddOrUpdateCustomField.AutoSize = true;
			this.btnAddOrUpdateCustomField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddOrUpdateCustomField.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddOrUpdateCustomField.Location = new System.Drawing.Point(343, 80);
			this.btnAddOrUpdateCustomField.Name = "btnAddOrUpdateCustomField";
			this.btnAddOrUpdateCustomField.Size = new System.Drawing.Size(83, 24);
			this.btnAddOrUpdateCustomField.TabIndex = 6;
			this.btnAddOrUpdateCustomField.Text = "Hinzufügen";
			this.btnAddOrUpdateCustomField.UseVisualStyleBackColor = true;
			this.btnAddOrUpdateCustomField.Click += new System.EventHandler(this.btnAddOrUpdateCustomField_Click);
			// 
			// txtCustomFieldValue
			// 
			this.txtCustomFieldValue.Location = new System.Drawing.Point(240, 53);
			this.txtCustomFieldValue.Name = "txtCustomFieldValue";
			this.txtCustomFieldValue.Size = new System.Drawing.Size(189, 23);
			this.txtCustomFieldValue.TabIndex = 5;
			// 
			// lblCFValue
			// 
			this.lblCFValue.Location = new System.Drawing.Point(186, 52);
			this.lblCFValue.Name = "lblCFValue";
			this.lblCFValue.Size = new System.Drawing.Size(48, 23);
			this.lblCFValue.TabIndex = 4;
			this.lblCFValue.Text = "Wert:";
			this.lblCFValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCustomFieldKey
			// 
			this.txtCustomFieldKey.Location = new System.Drawing.Point(52, 52);
			this.txtCustomFieldKey.Name = "txtCustomFieldKey";
			this.txtCustomFieldKey.Size = new System.Drawing.Size(128, 23);
			this.txtCustomFieldKey.TabIndex = 3;
			// 
			// lblCFKey
			// 
			this.lblCFKey.Location = new System.Drawing.Point(2, 52);
			this.lblCFKey.Name = "lblCFKey";
			this.lblCFKey.Size = new System.Drawing.Size(44, 22);
			this.lblCFKey.TabIndex = 2;
			this.lblCFKey.Text = "Name:";
			this.lblCFKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lvwCustomFields
			// 
			this.lvwCustomFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmhKey,
            this.clmhValue});
			this.lvwCustomFields.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lvwCustomFields.FullRowSelect = true;
			this.lvwCustomFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwCustomFields.LargeImageList = this.imglMain;
			this.lvwCustomFields.Location = new System.Drawing.Point(0, 110);
			this.lvwCustomFields.MultiSelect = false;
			this.lvwCustomFields.Name = "lvwCustomFields";
			this.lvwCustomFields.ShowItemToolTips = true;
			this.lvwCustomFields.Size = new System.Drawing.Size(429, 201);
			this.lvwCustomFields.SmallImageList = this.imglMain;
			this.lvwCustomFields.TabIndex = 1;
			this.lvwCustomFields.TileSize = new System.Drawing.Size(300, 35);
			this.lvwCustomFields.UseCompatibleStateImageBehavior = false;
			this.lvwCustomFields.View = System.Windows.Forms.View.Details;
			this.lvwCustomFields.SelectedIndexChanged += new System.EventHandler(this.lvwCustomFields_SelectedIndexChanged);
			// 
			// clmhKey
			// 
			this.clmhKey.Text = "Name";
			this.clmhKey.Width = 130;
			// 
			// clmhValue
			// 
			this.clmhValue.Text = "Wert";
			this.clmhValue.Width = 260;
			// 
			// buttonArea1
			// 
			this.buttonArea1.Controls.Add(this.btnCancel);
			this.buttonArea1.Controls.Add(this.btnOk);
			this.buttonArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonArea1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.buttonArea1.Location = new System.Drawing.Point(0, 334);
			this.buttonArea1.Name = "buttonArea1";
			this.buttonArea1.Padding = new System.Windows.Forms.Padding(0, 10, 12, 0);
			this.buttonArea1.Size = new System.Drawing.Size(637, 50);
			this.buttonArea1.TabIndex = 25;
			// 
			// bgwBuildPackage
			// 
			this.bgwBuildPackage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBuildPackage_DoWork);
			this.bgwBuildPackage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwBuildPackage_RunWorkerCompleted);
			// 
			// pnlPublish
			// 
			this.pnlPublish.Controls.Add(this.lvwPublishWith);
			this.pnlPublish.Controls.Add(this.lblChoosePublishSource);
			this.pnlPublish.Location = new System.Drawing.Point(196, 12);
			this.pnlPublish.Name = "pnlPublish";
			this.pnlPublish.Size = new System.Drawing.Size(429, 311);
			this.pnlPublish.TabIndex = 26;
			this.pnlPublish.Visible = false;
			// 
			// lvwPublishWith
			// 
			this.lvwPublishWith.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwPublishWith.CheckBoxes = true;
			this.lvwPublishWith.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDummy});
			this.lvwPublishWith.FullRowSelect = true;
			this.lvwPublishWith.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwPublishWith.Location = new System.Drawing.Point(3, 48);
			this.lvwPublishWith.Name = "lvwPublishWith";
			this.lvwPublishWith.Size = new System.Drawing.Size(423, 260);
			this.lvwPublishWith.TabIndex = 3;
			this.lvwPublishWith.UseCompatibleStateImageBehavior = false;
			this.lvwPublishWith.View = System.Windows.Forms.View.Details;
			// 
			// clmDummy
			// 
			this.clmDummy.Text = "Dummy";
			// 
			// lblChoosePublishSource
			// 
			this.lblChoosePublishSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblChoosePublishSource.Location = new System.Drawing.Point(3, 3);
			this.lblChoosePublishSource.Name = "lblChoosePublishSource";
			this.lblChoosePublishSource.Size = new System.Drawing.Size(423, 37);
			this.lblChoosePublishSource.TabIndex = 0;
			this.lblChoosePublishSource.Text = "Wählen Sie hier die Quellen aus, über diese Sie dieses Updatepaket verteilen möch" +
    "ten:";
			// 
			// updatePackageDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(637, 384);
			this.Controls.Add(this.pnlActions);
			this.Controls.Add(this.pnlPublish);
			this.Controls.Add(this.pnlChanges);
			this.Controls.Add(this.pnlGeneral);
			this.Controls.Add(this.buttonArea1);
			this.Controls.Add(this.tvwContent);
			this.Controls.Add(this.pnlBuildPackage);
			this.Controls.Add(this.pnlContent);
			this.Controls.Add(this.pnlAvailability);
			this.Controls.Add(this.pnlCustomFields);
			this.KeyPreview = true;
			this.Name = "updatePackageDialog";
			this.Text = "updatePackageForm";
			this.pnlGeneral.ResumeLayout(false);
			this.pnlGeneral.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmPreviewState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmRevision)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmBuild)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMinor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmMajor)).EndInit();
			this.pnlChanges.ResumeLayout(false);
			this.pnlChanges.PerformLayout();
			this.pnlLanguage.ResumeLayout(false);
			this.pnlLanguage.PerformLayout();
			this.pnlAvailability.ResumeLayout(false);
			this.pnlAvailability.PerformLayout();
			this.pnlCustomVersion.ResumeLayout(false);
			this.pnlCustomVersion.PerformLayout();
			this.pnlActions.ResumeLayout(false);
			this.pnlBuildPackage.ResumeLayout(false);
			this.pnlCustomFields.ResumeLayout(false);
			this.pnlCustomFields.PerformLayout();
			this.buttonArea1.ResumeLayout(false);
			this.buttonArea1.PerformLayout();
			this.pnlPublish.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private UI.Controls.explorerTreeView tvwContent;
		private System.Windows.Forms.Panel pnlContent;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlGeneral;
		private System.Windows.Forms.CheckBox chkServicePack;
		private System.Windows.Forms.Label lblServicePackDescription;
		private System.Windows.Forms.Label lblPublishDescription;
		private System.Windows.Forms.NumericUpDown nmPreviewState;
		private System.Windows.Forms.ComboBox cboReleaseState;
		private System.Windows.Forms.Label lblGeneralReleaseState;
		private System.Windows.Forms.NumericUpDown nmRevision;
		private System.Windows.Forms.NumericUpDown nmBuild;
		private System.Windows.Forms.NumericUpDown nmMinor;
		private System.Windows.Forms.NumericUpDown nmMajor;
		private System.Windows.Forms.Label lblGeneralRevision;
		private System.Windows.Forms.Label lblGeneralBuild;
		private System.Windows.Forms.Label lblGeneralMinor;
		private System.Windows.Forms.Label lblGeneralMajor;
		private System.Windows.Forms.CheckBox chkPublished;
		private System.Windows.Forms.ComboBox cboTargetArchitecture;
		private System.Windows.Forms.Label lblGeneralArchitecture;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblGeneralVersion;
		private System.Windows.Forms.Label lblGeneralDescription;
		private System.Windows.Forms.Panel pnlChanges;
		private System.Windows.Forms.Panel pnlAvailability;
		private System.Windows.Forms.Panel pnlCustomVersion;
		private System.Windows.Forms.ListBox lstCustomVersions;
		private System.Windows.Forms.Button btnRemoveCustomVersion;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnAddCustomVersion;
		private System.Windows.Forms.TextBox txtNewCustomVersion;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.RadioButton rbCustomVersions;
		private System.Windows.Forms.RadioButton rbAllVersions;
		private System.Windows.Forms.FlowLayoutPanel pnlLanguage;
		private System.Windows.Forms.Button btnImportChangeFromFile;
		private System.Windows.Forms.ComboBox cboLanguage;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.TextBox txtChanges;
		private System.Windows.Forms.Panel pnlActions;
		private UI.Controls.extendedListView lvwActions;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.ColumnHeader clmDescription;
		private System.Windows.Forms.ImageList imglMain;
		private System.Windows.Forms.Label lblActionsDescription;
		private System.Windows.Forms.Panel pnlBuildPackage;
		private Controls.actionLabel aclBuildPackage;
		private Controls.seperatorLabel seperatorLabel1;
		private System.Windows.Forms.Panel pnlCustomFields;
		private UI.Controls.extendedListView lvwCustomFields;
		private System.Windows.Forms.ColumnHeader clmhKey;
		private System.Windows.Forms.ColumnHeader clmhValue;
		private System.Windows.Forms.TextBox txtCustomFieldKey;
		private System.Windows.Forms.Label lblCFKey;
		private System.Windows.Forms.TextBox txtCustomFieldValue;
		private System.Windows.Forms.Label lblCFValue;
		private System.Windows.Forms.Button btnRemoveCustomField;
		private System.Windows.Forms.Button btnAddOrUpdateCustomField;
		private System.Windows.Forms.Label lblCFDescription;
		private updateSystemDotNet.Administration.UI.Controls.buttonArea buttonArea1;
		private System.ComponentModel.BackgroundWorker bgwBuildPackage;
		private System.Windows.Forms.Label lblErrorText;
		private System.Windows.Forms.Panel pnlPublish;
		private System.Windows.Forms.Label lblChoosePublishSource;
		private extendedListView lvwPublishWith;
		private System.Windows.Forms.ColumnHeader clmDummy;
	}
}