using PrzychodniaWSB.ClinicCore.Utils;
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

        private Button activatedButton;
        private Ellipse activatedElipse;

        public PreLoginView() {
            InitializeComponent();
            activatedButton = (Button)FindName("PatientButton");
            activatedElipse = (Ellipse)FindName("PatientSelected");
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e) {

            activatedButton.BorderBrush = Brushes.Transparent;
            activatedElipse.Visibility = Visibility.Collapsed;

            var buttonClicked = (Button)sender;
            activatedButton = buttonClicked;
            activatedButton.BorderBrush = Brushes.Violet;

            IEnumerable<Ellipse> ellipse = FindVisualChildren<Ellipse>(this).Where(x => x.Tag != null && x.Tag.ToString() == activatedButton.Name);
            activatedElipse = ellipse.First();
            activatedElipse.Visibility = Visibility.Visible;
            
            
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject {
            if (depObj != null) {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T) {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child)) {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Continue_Click(object sender, RoutedEventArgs e) {

            switch (activatedButton.Name) {
                case "AdminButton":
                    WindowViewModel.Instance.SwitchView(ViewPage.AdminLogin,new LoginViewModel());
                    Logger.debug("Admin selected, will switch to it's LoginPage");
                    break;

                case "DoctorButton":
                    WindowViewModel.Instance.SwitchView(ViewPage.DoctorLogin, new LoginViewModel());
                    Logger.debug("Doctor selected, will switch to it's LoginPage");
                    break;

                case "PatientButton":
                    WindowViewModel.Instance.SwitchView(ViewPage.PatientChoose);
                    Logger.debug("Patient selected, will switch to it's LoginPage");
                    break;

                default:
                    return;
            }

            //WindowViewModel.Instance.SwitchView(ViewPage.Login, new LoginViewModel());
        }
    }
}
