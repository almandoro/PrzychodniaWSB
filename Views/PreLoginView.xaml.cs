using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels.Parents;
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

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy PreLoginView.xaml
    /// </summary>
    public partial class PreLoginView : Page {
        public PreLoginView() {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e) {
            var x = WindowViewModel.Instance.Equals(null);
            Logger.debug($"x");

            WindowViewModel.Instance.SwitchView(ViewPage.Login, new LoginViewModel());
        }
    }
}
