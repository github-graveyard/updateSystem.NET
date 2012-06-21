/**
 * updateSystem.NET
 * Copyright (c) 2008-2012 Maximilian Krauss <http://coffeeInjection.com> eMail: max@coffeeInjection.com
 *
 * This library is licened under The Code Project Open License (CPOL) 1.02
 * which can be found online at <http://www.codeproject.com/info/cpol10.aspx>
 * 
 * THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT
 * ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU,
 * THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT,
 * PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL
 * EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING
 * WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY,
 * MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY
 * WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY
 * PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES.
 * YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR
 * DERIVATIVE WORKS.
 */
using System.Drawing;
using updateSystemDotNet.Administration.Core.updateLog;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using updateSystemDotNet.Administration.Core;
namespace updateSystemDotNet.Administration.UI.mainFormPages.statisticSubPages {
	internal sealed partial class statisticUsersSubPage : statisticSubBasePage {

		private readonly List<userAccount> _userCache;

		private ToolStripButton _tsBtnRefresh;
		private ToolStripButton _tsBtnAddUser;
		private ToolStripButton _tsBtnEditUser;
		private ToolStripButton _tsBtnRemoveUser;

		public statisticUsersSubPage() {
			_userCache = new List<userAccount>();
			InitializeComponent();
			extendsToolStrip = true;
			lvwUser.ColumnWidthChanged += lvwUser_ColumnWidthChanged;
			bgwRefreshUser.RunWorkerCompleted += bgwRefreshUser_RunWorkerCompleted;
			pageSymbol = resourceHelper.getImage("usermgmt.png");
			Id = "130cd18f-f644-4250-9d88-603f51d70f23";
		}

		void bgwRefreshUser_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			pnlUsrBase.Enabled = true;
			if (e.Result is List<userAccount>) {
				_userCache.Clear();
				_userCache.AddRange(e.Result as List<userAccount>);
				loadUser();
			}
			else
				showServerError(e.Result as Exception);
		}

		void lvwUser_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e) {
			saveColumnHeaderSizes(lvwUser);
		}

		public override void initializeData() {
			restoreColumnHeaderSizes(lvwUser);
			loadUser();
		}

		public override void initializeToolStripButtons() {
			_tsBtnRefresh = createToolStripButton("tsBtnRefresh");
			_tsBtnAddUser = createToolStripButton("tsBtnAddUser");
			_tsBtnEditUser = createToolStripButton("tsBtnEditUser");
			_tsBtnRemoveUser = createToolStripButton("tsBtnRemoveUser");

			_tsBtnEditUser.Enabled = false;
			_tsBtnRemoveUser.Enabled = false;

			_tsBtnRefresh.Click += _tsBtnRefresh_Click;
			_tsBtnAddUser.Click += _tsBtnAddUser_Click;
			_tsBtnEditUser.Click += _tsBtnEditUser_Click;
			_tsBtnRemoveUser.Click += _tsBtnRemoveUser_Click;
		}

		public override void initializeLocalization() {
			base.initializeLocalization();
			lvwUser.Columns[0].Text = localizeListViewColumn(lvwUser, "clmName");
			lvwUser.Columns[1].Text = localizeListViewColumn(lvwUser, "clmMaxProjects");
			lvwUser.Columns[2].Text = localizeListViewColumn(lvwUser, "clmActive");
			lvwUser.Groups[0].Header = localizeListViewColumn(lvwUser, "grpAdmins");
			lvwUser.Groups[1].Header = localizeListViewColumn(lvwUser, "grpUser");
		}

		void _tsBtnRemoveUser_Click(object sender, EventArgs e) {
			if (isBusy) return;
			
			if (lvwUser.SelectedItems.Count != 1)
				return;

			if (Session.showMessage(this,
				"Sind Sie sicher, dass Sie den ausgewählten Benutzer mitsammt seinen Projekten und Statistikdaten löschen möchten?",
				"Löschen bestätigen", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) == DialogResult.Yes) {

				pnlUsrBase.Enabled = false;
				bgwDeleteUser.RunWorkerAsync(((userAccount)lvwUser.SelectedItems[0].Tag).Username);
			}
		}

		void _tsBtnEditUser_Click(object sender, EventArgs e) {
			if (isBusy) return;

			if (lvwUser.SelectedItems.Count == 0)
				return;

			var selectedAccount = (userAccount)lvwUser.SelectedItems[0].Tag;
			bool selfUpdate = (selectedAccount.Username == Session.currentProject.updateLogUser.Username);

			if (Session.showDialog<Dialogs.manageUpdateLogUserDialog>(lvwUser.SelectedItems[0].Tag as userAccount) == DialogResult.OK) {
				var dialogResultEx = Session.dialogResultCache[typeof(Dialogs.manageUpdateLogUserDialog)] as string[];
				if (dialogResultEx != null && selfUpdate) {
					Session.currentProject.updateLogUser.Username = dialogResultEx[0];
					if (!string.IsNullOrEmpty(dialogResultEx[1]))
						Session.currentProject.updateLogUser.Password = dialogResultEx[1];
					Session.saveProject();
				}
				loadUserList();
			}
		}

		void _tsBtnAddUser_Click(object sender, EventArgs e) {
			if (isBusy) return;
			if (Session.showDialog<Dialogs.manageUpdateLogUserDialog>() == DialogResult.OK)
				loadUserList();
		}

		void _tsBtnRefresh_Click(object sender, EventArgs e) {
			if (isBusy) return;
			loadUserList();
		}

		private bool isBusy {
			get { return bgwDeleteUser.IsBusy || bgwDeleteUser.IsBusy; }
		}

		private void loadUser() {
			lvwUser.Items.Clear();
			foreach(var user in _userCache) {
				var lviUser = new ListViewItem(user.Username);
				lviUser.SubItems.Add(user.userIsAdmin ? "n/a" : user.maxProjects.ToString());
				lviUser.SubItems.Add(user.userIsActive ? Session.localizeMessage("Yes") : Session.localizeMessage("No"));
				lviUser.Group = user.userIsAdmin ? lvwUser.Groups[0] : lvwUser.Groups[1];
				lviUser.Tag = user;
				if (user.Username == Session.currentProject.updateLogUser.Username)
					lviUser.Font = new Font(lviUser.Font, FontStyle.Bold);
				lvwUser.Items.Add(lviUser);
			}
			
		}

		private void bgwRefreshUser_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				e.Result = Session.updateLogFactory.getUsers();
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void loadUserList() {
			if (!bgwRefreshUser.IsBusy) {
				pnlUsrBase.Enabled = false;
				bgwRefreshUser.RunWorkerAsync();
			}
		}

		private void lvwUser_SelectedIndexChanged(object sender, EventArgs e) {
			_tsBtnEditUser.Enabled = lvwUser.SelectedItems.Count == 1;
			_tsBtnRemoveUser.Enabled = lvwUser.SelectedItems.Count == 1;
		}

		private void bgwDeleteUser_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				Session.updateLogFactory.deleteUser(e.Argument.ToString());
			}
			catch(Exception exc) {
				e.Result = exc;
			}
		}

		private void bgwDeleteUser_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if (e.Result != null) { //Bei der Anfrage ist ein Fehler aufgetreten
				pnlUsrBase.Enabled = true;
				showServerError((Exception) e.Result);
			}
			else {
				loadUserList();
			}
		}
	}
}
