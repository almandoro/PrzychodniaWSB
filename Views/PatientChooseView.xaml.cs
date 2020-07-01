using PrzychodniaWSB.ViewModels;
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
    /// Logika interakcji dla klasy PatientChooseView.xaml
    /// </summary>
    public partial class PatientChooseView : Page {
        public PatientChooseView() {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e) {
            WindowViewModel.Instance.SwitchView(ViewPage.PatientLogin, new LoginViewModel());
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e) {
             WindowViewModel.Instance.SwitchView(ViewPage.Register,new RegisterViewModel());
        }
    }
}
