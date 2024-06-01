using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySave_V3._0.Models;
using EasySave_V3._0.ViewModels;

namespace EasySave_V3._0.Views
{
    /// <summary>
    /// Logique d'interaction pour LaunchFR.xaml
    /// </summary>
    public partial class LaunchFR : Page
    {
        List<BackUp> selected_list;
        Model model = new Model();
        public LaunchFR()
        {
            InitializeComponent();
            this.selected_list = new List<BackUp>();

            SelectedList.ItemsSource = selected_list;

            DBList.ItemsSource = Database.SelectAll();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            SelectedList.ItemsSource = ViewModel.AddToList(name.Text, selected_list); //Add the selected back up tot the selected back up list if the backup name entered is correct
            SelectedList.Items.Refresh(); //Refresh the view object List Box SelectedList
        }

        private void Launch_Valid(object sender, RoutedEventArgs e)
        {
            Play_btn.IsEnabled = false;
            Pause_btn.IsEnabled = true;

            if (selected_list.Count > 0)
            {
                Thread Launching = new Thread(() => {
                    ViewModel.BackUpLauncher(selected_list);
                });
                Launching.Start();

                foreach (BackUp curbackup in selected_list)
                {
                    ActionBar ab = new ActionBar(curbackup);
                    ab.Show();
                }
            }


        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(ViewModel.PageSelector("Index"));
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            selected_list.Clear(); //Clear the list of selected backup
            SelectedList.Items.Refresh(); //Refresh the View object List Box
            Play_btn.IsEnabled = false;
            Pause_btn.IsEnabled = true;
        }

        private void Stop_All(object sender, RoutedEventArgs e)
        {
            ViewModel.StopAll(selected_list);
            Play_btn.IsEnabled = false;
            Pause_btn.IsEnabled = true;
        }

        private void Pause_All(object sender, RoutedEventArgs e)
        {
            ViewModel.PauseAll(selected_list);
            Pause_btn.IsEnabled = false;
            Play_btn.IsEnabled = true;

        }

        private void Play_All(object sender, RoutedEventArgs e)
        {
            ViewModel.PlayAll(selected_list);
            Play_btn.IsEnabled = false;
            Pause_btn.IsEnabled = true;
        }
    }
}
