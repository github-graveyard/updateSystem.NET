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

using System.Collections.Generic;
using System.Windows.Forms;
using updateSystemDotNet.Administration.Core.Publishing;
using System;
using updateSystemDotNet.Core;

namespace updateSystemDotNet.Administration.UI.Dialogs {
	internal partial class publishUpdatesDialog : dialogBase {
		private List<IPublishProvider> _provider;
		private int _valueMultiplier;

		public publishUpdatesDialog() {
			InitializeComponent();

			Shown += publishUpdatesDialog_Shown;
			bgwPublish.RunWorkerCompleted += bgwPublish_RunWorkerCompleted;
			bgwPublish.ProgressChanged += bgwPublish_ProgressChanged;
		}

		void bgwPublish_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
			var currentProvider = (e.UserState as IPublishProvider);
			prgPublish.Value = e.ProgressPercentage;
			lblCurrentPublishInformation.Text = string.Format("Veröffentliche Updates für \"{0}\" via {1}.",
			                                                  currentProvider.Settings.Name,
			                                                  Session.publishFactory.availableProvider[currentProvider.GetType()]
			                                                  	.Name);
		}

		void bgwPublish_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if(e.Result is publishResultList) {
				Result = e.Result as publishResultList;
				DialogResult = DialogResult.OK;
				Close();
			}
			else {
				var exception = e.Result as Exception;
				if (exception != null) throw exception;
			}
		}

		void publishUpdatesDialog_Shown(object sender, EventArgs e) {
			bgwPublish.RunWorkerAsync();
		}

		public override void initializeData() {
			_provider = (List<IPublishProvider>) Argument;
		}

		private void bgwPublish_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			try {
				var resultCache = new publishResultList();
				
				//Alle übergebenen Veröffentlichungsschnittstellen ausführen
				foreach (var provider in _provider) {
					try {
						provider.publishUpdateProgressChanged += provider_publishUpdateProgressChanged;
						resultCache.Add(provider.publishUpdates());
					}
					finally {
						provider.publishUpdateProgressChanged -= provider_publishUpdateProgressChanged;
						_valueMultiplier++;
					}
				}
				e.Result = resultCache;
			}
			catch (Exception exc) {
				e.Result = exc;
			}
		}

		void provider_publishUpdateProgressChanged(object sender, publishUpdateProgressChangedEventArgs e) {
			int percentDone = Helper.Percent(Helper.Percent(e.currentFile, e.maxFileCount) + (100*_valueMultiplier),
			                                 (100*_provider.Count));
			bgwPublish.ReportProgress(percentDone, sender);
		}

	}
}
