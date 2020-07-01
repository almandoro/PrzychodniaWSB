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
    /// Logika interakcji dla klasy PatientLoginView.xaml
    /// </summary>
    public partial class PatientLoginView : Page {
        public PatientLoginView() {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e) {
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Password;

            if (login == null) {
                Error.show("Błąd", "Proszę podać login");
                return;
            }

            if(password == null) {
                Error.show("Błąd", "Proszę podać hasło");
                return;
            }

            LoginViewModel vm = (LoginViewModel)WindowViewModel.Instance.CurrentPageViewModel;
            vm.performLogin(login, password,ViewPage.PatientHome, new PatientHomeViewModel());
        }
    }
}
