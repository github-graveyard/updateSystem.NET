using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace testApplication
{
    public partial class myDownloadForm : updateSystemDotNet.updateDownloadBaseForm
    {
        public myDownloadForm()
        {
            InitializeComponent();

            this.downloadUpdatesCompleted += new updateSystemDotNet.downloadUpdatesCompletedEventHandler(myDownloadForm_downloadUpdatesCompleted);
            this.downloadUpdatesProgressChanged += new updateSystemDotNet.downloadUpdatesProgressChangedEventHandler(myDownloadForm_downloadUpdatesProgressChanged);
            Shown += new EventHandler(myDownloadForm_Shown);
        }

        void myDownloadForm_Shown(object sender, EventArgs e)
        {
            startDownload();
        }

        void myDownloadForm_downloadUpdatesProgressChanged(object sender, updateSystemDotNet.appEventArgs.downloadUpdatesProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void myDownloadForm_downloadUpdatesCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
