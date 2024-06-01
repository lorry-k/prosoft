using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using EasySave_V3._0.ViewModels;

namespace EasySave_V3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour CreateFR.xaml
    /// </summary>
    public partial class CreateFR : Page
    {
        public CreateFR()
        {
            InitializeComponent();
        }

        private string Type;

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ViewModel.PageSelector("Index")); //Redirect to the page returned by Page Selector
        }

        private void Create_Valid(object sender, RoutedEventArgs e)
        {
            if (ViewModel.BackUpCreator(name.Text, source1.Text, destination.Text, Type))
            {
                this.NavigationService.Navigate(ViewModel.PageSelector("Index")); //Redirect to the page returned by Page Selector if the Creation process succeeded
            }
        }

        private void Full_Checked(object sender, RoutedEventArgs e)
        {
            Type = "Full";
        }

        private void Diff_Checked(object sender, RoutedEventArgs e)
        {
            Type = "Diff";
        }

        private void Source_Button(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog(); //Create a Folder Browser
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String sPath = folderDialog.SelectedPath;
                source1.Text = sPath.Replace(@"\", "/");    //Change the  \ that aren't supported to / in the text box.
            }
        }

        private void Destination_Button(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog(); //Create a Folder Browser
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String sPath = folderDialog.SelectedPath;
                destination.Text = sPath.Replace(@"\", "/");    //Change the  \ that aren't supported to / in the text box.
            }
        }
    }
}
