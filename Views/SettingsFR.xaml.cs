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
using EasySave_V3._0.ViewModels;

namespace EasySave_V3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour SettingsFR.xaml
    /// </summary>
    public partial class SettingsFR : Page
    {
        public SettingsFR()
        {
            InitializeComponent();

        }

        private void Francais(object sender, RoutedEventArgs e)
        {
            ViewModel.language = "FR";  //Change the Application global language
            this.NavigationService.Navigate(ViewModel.PageSelector("Settings"));    //Redirect to the page the PageSelector returns
        }

        private void English(object sender, RoutedEventArgs e)
        {
            ViewModel.language = "EN";  //Change the Application global language
            this.NavigationService.Navigate(ViewModel.PageSelector("Settings"));    //Redirect to the page the PageSelector returns
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ViewModel.PageSelector("Index"));   //Redirect to the page the PageSelector returns
        }

        private void extensions_Valid(object sender, RoutedEventArgs e)
        {
            if (extension.Text[0] == '.')   //Check if the user entered the extensions starting with a dot
            {
                ViewModel.AddExtension(extension.Text); 
            }
            else
            {
                ViewModel.AddExtension("." + extension.Text); //if they did not, add the dot & send it to the function
            }

            extension.Text = "";
        }

        private void softwares_Valid(object sender, RoutedEventArgs e)
        {
            ViewModel.AddSoftware(software.Text); //send the user input to the database
            software.Text = "";
        }
    }
}
