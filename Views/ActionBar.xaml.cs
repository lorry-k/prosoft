using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EasySave_V3._0.Models;
using EasySave_V3._0.ViewModels;

namespace EasySave_V3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour ActionBar.xaml
    /// </summary>
    public partial class ActionBar : Window
    {
        public BackUp backupProperties;

        public ActionBar(BackUp backupPro)
        {
            backupProperties = backupPro;
            InitializeComponent();
            BackupName.Text = backupProperties.name;
            Thread.Sleep(200);
            if(backupProperties.currentStatus == "Pause")
            {
                Play_btn.IsEnabled = true;
                Pause_btn.IsEnabled = false;
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();

            
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (backupProperties.currentStatus != "Stop")
            {
                while (backupProperties.currentStatus == "Play")
                {
                    int i = Convert.ToInt32(backupProperties.progression);
                    (sender as BackgroundWorker).ReportProgress(i);
                    Thread.Sleep(100);
                }
            }


            //while (backupProperties.currentStatus == "Play")
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        (sender as BackgroundWorker).ReportProgress(i);
            //        Thread.Sleep(100);
            //    }
            //}
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Prog.Value = e.ProgressPercentage;
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            ViewModel.Stop(backupProperties);
            Pause_btn.IsEnabled = false;
            Play_btn.IsEnabled = false;
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            ViewModel.Pause(backupProperties);
            Play_btn.IsEnabled = true;
            Pause_btn.IsEnabled = false;
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            if (ViewModel.model.ProcessIsRunning())
            {
                Messages.ErrorProcessIsRunning();
            }
            else
            {
                ViewModel.Play(backupProperties);
                Play_btn.IsEnabled = false;
                Pause_btn.IsEnabled = true;
            }
        }
    }
}
