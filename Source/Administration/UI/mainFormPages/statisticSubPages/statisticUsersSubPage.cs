#region License
/*
	updateSystem.NET - Easy to use Autoupdatesolution for .NET Apps
	Copyright (C) 2012  Maximilian Krauss <max@kraussz.com>
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

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
			initializeToolStripButtons();
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

		protected override void initializeToolStripButtons() {
			_tsBtnRefresh = createToolStripButton("Aktualisieren", "Aktualisiert die Benutzerliste.");
			_tsBtnAddUser = createToolStripButton("Hinzufügen", "Bietet die Möglichkeit einen neuen Benutzer hinzuzufügen.");
			_tsBtnEditUser = createToolStripButton("Bearbeiten",
			                                       "Bietet die Möglichkeit den aktuell ausgewählten Benutzer zu bearbeiten.");
			_tsBtnRemoveUser = createToolStripButton("Entfernen",
			                                         "Entfernt den aktuell ausgewählten Benutzer vom Statistikserver");

			_tsBtnEditUser.Enabled = false;
			_tsBtnRemoveUser.Enabled = false;

			_tsBtnRefresh.Click += _tsBtnRefresh_Click;
			_tsBtnAddUser.Click += _tsBtnAddUser_Click;
			_tsBtnEditUser.Click += _tsBtnEditUser_Click;
			_tsBtnRemoveUser.Click += _tsBtnRemoveUser_Click;
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
				lviUser.SubItems.Add(user.userIsActive ? "Ja" : "Nein");
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
