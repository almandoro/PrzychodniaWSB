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
using System.Windows.Shapes;

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy Error.xaml
    /// </summary>
    public partial class Error : Window {

        public static void show(string title, string text) {
            Error err = new Error {
                TitleBar = { Text = title },
                Textbar = { Text = text }
            };
            err.ShowDialog();
        }

        public Error() {
            InitializeComponent();
            if (Application.Current == null) new Application();
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }


        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e) {
            this.MouseDown += delegate { DragMove(); };
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }
    }
}
