﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabularEditor.TOMWrapper;
using TabularEditor.UI.Dialogs;
using TabularEditor.UIServices;

namespace TabularEditor.UI
{
    public partial class UIController
    {
        private const string NEW_DEPLOYMENT_TARGET = "<New deployment target...>";

        public void Database_Deploy()
        {
            var f = new DeployForm();
            var res = f.ShowDialog();
            if (res == DialogResult.Cancel) return;

            Database_Backup();
            UI.FormMain.Cursor = Cursors.WaitCursor;
            UI.StatusLabel.Text = "Deploying...";
            Application.DoEvents();
            var df = new DeployingForm();
            df.Cursor = Cursors.WaitCursor;
            var error = false;
            df.DeployAction = () =>
            {
                try
                {
                    TabularDeployer.Deploy(Handler.Database, f.DeployTargetServer.ConnectionString, f.DeployTargetDatabaseID, f.DeployOptions);
                }
                catch (Exception ex)
                {
                    error = true;
                    df.ThreadClose();
                    MessageBox.Show(ex.Message, "Error occured during deployment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            df.ShowDialog();
            UI.StatusLabel.Text = error ? "Deploy failed!" : "Deploy succeeded!";
            UI.FormMain.Cursor = Cursors.Default;
        }

        private string LocalInstanceName = null;

        public void Database_Connect()
        {
            if (DiscardChangesCheck()) return;

            if (ConnectForm.Show() == DialogResult.Cancel) return;
            LocalInstanceName = ConnectForm.LocalInstanceName;
            if (string.IsNullOrEmpty(LocalInstanceName))
            {
                if (SelectDatabaseForm.Show(ConnectForm.Server) == DialogResult.Cancel) return;
            }
            else
            {
                // embedded mode
                // signal to open the first (and only) database in the list, and use the name provided from the ConnectForm
            }

            UI.StatusLabel.Text = "Opening Model from Database...";
            ClearUI();
            UpdateUIText();
            Cursor.Current = Cursors.WaitCursor;

            var oldHandler = Handler;

            try
            {
                Handler = new TabularModelHandler(ConnectForm.ConnectionString, string.IsNullOrEmpty(LocalInstanceName) ? SelectDatabaseForm.DatabaseName : null);
                LoadTabularModelToUI();
                File_Current = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connecting to database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Handler = oldHandler;
                LoadTabularModelToUI();
            }

            Cursor.Current = Cursors.Default;
        }

        private void Database_Backup()
        {
            if (Preferences.Current.BackupOnSave)
            {
                var backupFilename = string.Format("{0}\\Backup_{1}_{2}.zip", Preferences.Current.BackupLocation, Handler.Database.Name, DateTime.Now.ToString("yyyyMMddhhmmssfff"));
                TabularDeployer.SaveModelMetadataBackup(Handler.Database.Server.ConnectionString, Handler.Database.ID, backupFilename);
            }

        }

        private void Database_Save()
        {
            UI.ErrorLabel.Text = "";

            ExpressionEditor_AcceptEdit();

            var conflictInfo = Handler.CheckConflicts();
            if (conflictInfo.Conflict)
            {
                var res = MessageBox.Show(string.Format("Changes have been made to the deployed version of the model, since it was loaded into Tabular Editor.\n\nDeployed model version: {0} (changed {1})\nCurrent model version: {2}\n\nDo you want to overwrite the deployed model?", 
                    conflictInfo.DatabaseVersion, conflictInfo.DatabaseLastUpdate, conflictInfo.LoadedVersion),
                    "Change conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No) return;
            }

            UI.FormMain.Cursor = Cursors.WaitCursor;
            UI.StatusLabel.Text = "Saving changes to DB...";
            Application.DoEvents();

            Database_Backup();
            Handler.SaveDB();

            UI.TreeView.Refresh();

            UI.FormMain.Cursor = Cursors.Default;
        }
    }
}
