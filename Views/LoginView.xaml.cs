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
using Microsoft.Extensions.Logging;
using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels;

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : Page {
        public LoginView() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            if(!string.IsNullOrEmpty(LoginTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text)) {
                var loginVM = new LoginViewModel();
                var isValidLogin = loginVM.performLogin(LoginTextBox.Text, PasswordTextBox.Text);

                if(isValidLogin) {
                    //
                }

            } else {
                MessageBox.Show("Proszę podać login i hasło!");
                Logger.error("Nie podano loginu lub hasla!");
            }
            Logger.debug($"Login: [{LoginTextBox.Text}] Hasło: [{PasswordTextBox.Text}]");

        }
    }
}
