using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
    
        }

        private void Launch_Selection(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ViewModel.PageSelector("Launch")); //Redirect to the page the PageSelector returns
        }

        private void Create_Selection(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ViewModel.PageSelector("Create"));  //Redirect to the page the PageSelector returns
        }

        private void Settings_Selection(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(ViewModel.PageSelector("Settings"));   //Redirect to the page the PageSelector returns 
        }
    }
}
