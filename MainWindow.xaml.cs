using PrzychodniaWSB.ViewModels;
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

namespace PrzychodniaWSB {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e) {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        
    }
}
