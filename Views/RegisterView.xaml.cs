using PrzychodniaWSB.ClinicCore.Utils;
using PrzychodniaWSB.Models;
using PrzychodniaWSB.Utils;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page {

        private RegisterPatient register = null;

        class RegisterPatient {

            internal string name = null;
            internal string lastName = null;
            internal string age = null;
            internal string sex = null;
            internal string email = null;
            internal string phone = null;

            public RegisterPatient() {
                
            }

            public override string ToString() {
                return $"imie {name} nazwisko {lastName} age {age} sex {sex} email {email} phone {phone}";
            }
        }

        public RegisterView() {
            InitializeComponent();
            register = new RegisterPatient();
            SexComboBox.SelectedItem = "Mężczyzna";
        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = (TextBox) sender;
            register.lastName = textBox.Text;
        }

        private void AgeTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = (TextBox)sender;
            register.age = textBox.Text;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = (TextBox)sender;
            register.name = textBox.Text;
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = (TextBox)sender;
            register.email = textBox.Text;
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var textBox = (TextBox)sender;
            register.phone = textBox.Text;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e) {

            Logger.debug(register.ToString());
            if(register.name != "" &&
                register.lastName != "" &&
                register.age != "" &&
                register.email != "" &&
                register.phone != "") {

                // Jeśli żadne pole nie jest null

                // Sprawdź email
                if (!register.email.Contains("@")) {
                    Error.show("Błędny email!", "Proszę wpisać poprawny adres email!");
                    return;
                } else {
                    if (register.email.Split('@')[1].Split('.').Length != 2 && register.email.Split('@')[0].Split('.').Length != 1) {
                        Error.show("Błędny email!", "Proszę wpisać poprawny adres email!");
                        return;
                    }                                           
                }

                // Sprawdź telefon
                try {
                    Double.Parse(register.phone);
                    if (register.phone.ToCharArray().Length != 9) {
                        Error.show("Błędny telefon!", "Telefon powinien składać się z 9 cyfr!");
                        return;
                    }
                    
                } catch (Exception) {
                    Error.show("Błędny telefon!", "Proszę podać poprawny numer telefonu!");
                    return;
                }

                RegisterViewModel vm = (RegisterViewModel)WindowViewModel.Instance.CurrentPageViewModel;

                var phone = Double.Parse(register.phone);
                var email = register.email;
                var name = register.name;
                var lastname = register.lastName;
                var age = Int32.Parse(register.age);
                var sex = ((ComboBoxItem)SexComboBox.SelectedItem).Content as string;
                Console.WriteLine("sex :"+sex);

                var patient = new PatientModel() {
                    phone = phone,
                    email = email,
                    name = name,
                    lastname = lastname,
                    age = age,
                    sex = sex.ToLower()
                };

                vm.registerUser(patient);
            } 
            
            // Jakieś pole jest null!
            else {
                Error.show("Niepełny formularz!", "Proszę uzupełnić pełen formularz!");
                return;
            }
        }

    }
}
