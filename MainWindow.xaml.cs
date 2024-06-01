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
using EasySave_V3._0.Views;
using EasySave_V3._0.Models;
using System.Threading;

namespace EasySave_V3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.Connexion();
            
            
            MainView main = new MainView();
            ViewModels.ViewModel.AppStart();
            mwframe.NavigationService.Navigate(main);
            
            
           
            
        }
    }
}
