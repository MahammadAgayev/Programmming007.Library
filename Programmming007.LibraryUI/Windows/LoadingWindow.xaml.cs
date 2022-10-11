using Programming007.LibraryCore;
using Programming007.LibraryCore.DataAccesLayer.SqlServer;
using Programmming007.LibraryUI.Models.Configs;
using Programmming007.LibraryUI.Utils;
using Programmming007.LibraryUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Programmming007.LibraryUI.Windows
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                ConfigHelper helper = new ConfigHelper();

                DatabaseConfigModel config = helper.ReadFromFile();

                if (config == null)
                {
                    OpenConfigurationPage();
                    return;
                }

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.InitialCatalog = config.Database;
                builder.DataSource = config.Server;
                builder.IntegratedSecurity = config.IntegratedSecurity;

                if (config.IntegratedSecurity == false)
                {
                    builder.UserID = config.Username;
                    builder.Password = config.Password;
                }

                Kernel.DB = new SqlUnitOfWork(builder.ConnectionString);

                Thread.Sleep(300);
                if (Kernel.DB.CheckConnection() == false)
                {
                    OpenConfigurationPage();
                    return;
                }

                Dispatcher.Invoke(() =>
                {
                    LoginWindow window = new LoginWindow();
                    LoginWindowViewModel model = new LoginWindowViewModel();

                    model.Window = window;
                    window.DataContext = model;

                    window.Show();
                    this.Close();
                });
            });
        }

        private void OpenConfigurationPage()
        {
            Dispatcher.Invoke(() =>
            {
                DBConfigurationWindow window = new DBConfigurationWindow();
                DbConfigurationViewModel viewModel = new DbConfigurationViewModel();
                viewModel.Window = window;
                window.DataContext = viewModel;

                window.Show();

                this.Close();
            });
        }
    }
}
