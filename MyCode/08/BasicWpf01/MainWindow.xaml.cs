using CommonLib;
using Microsoft.Extensions.Logging;
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

namespace BasicWpf01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILogger<MainWindow> _logger;
        public MainWindow(ILogger<MainWindow> logger)
        {
            _logger = logger;
            _logger.LogInformation("Enter MainWindows");
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            if (button == null) return;

            if (button.Name == nameof(btnRunLongTask))
            {
                btnRunLongTask.IsEnabled = false;
                AsyncDemo asyncDemo = new AsyncDemo(_logger);
                await asyncDemo.LongTask();
                MessageBox.Show("LongTask done");
                btnRunLongTask.IsEnabled = true;
            }
        }
    }
}
