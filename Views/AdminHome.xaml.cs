using PrzychodniaWSB.Models;
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

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Page {

        private AdminHomeViewModel vm = (AdminHomeViewModel)WindowViewModel.Instance.CurrentPageViewModel;
        private UserModel user = null;

        public AdminHome() {
            InitializeComponent();
            fillUsers(UsersComboBox);
        }

        private void fillUsers(ComboBox box) {
            var users = vm.getAllUsers();
            foreach (var user in users) {
                box.Items.Add(user.login);
            }
        }

        private void UsersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            user = vm.findUserByLogin(UsersComboBox.SelectedValue.ToString());
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            vm.deleteUser(user.login);
            UsersComboBox.Items.Remove(user.login);
            Error.show("Sukces!",$"Użytkownik {user.login} został usunięty");
        }
    }
}
