using Dapper;
using PrzychodniaWSB.ClinicCore;
using PrzychodniaWSB.ClinicCore.Utils;
using PrzychodniaWSB.Models;
using PrzychodniaWSB.ViewModels.Parents;
using PrzychodniaWSB.Views;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace PrzychodniaWSB.ViewModels {
    public class RegisterViewModel : ViewModel {

        public RegisterViewModel() {

        }

        public void registerUser(PatientModel patient) {

            // Generuj login i hasło
            var randomLogin = LoginGenerator.generateLogin(patient.name, patient.lastname);
            var randomPassword = LoginGenerator.generatePassword();

            UserModel userModel = new UserModel {
                login = randomLogin,
                password = randomPassword,
                role = (int)UserRole.Patient
            };

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {

                // Dodaj użytkownika do tabeli 
                var output = cnn.Query<UserModel>(
                    $"INSERT INTO users (login, password, role) " +
                    $"VALUES (@login, @password, @role)", userModel);                
            }

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {

                // Znajdź i ustaw user_id
                var output = cnn.Query<UserModel>(
                    $"SELECT * " +
                    $"FROM users " +
                    $"WHERE login='{randomLogin}'", new DynamicParameters());
                
                var model = output.First();
                patient.user_id = model.user_id;

                UserCache.currentUser = model;
            }
                
            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                
                // Dodaj pacjenta do tabeli
                var output = cnn.Query<PatientModel>(
                    $"INSERT into patients (user_id,name,lastname,age,sex,email,phone) " +
                    $"VALUES (@user_id, @name, @lastname, @age, @sex, @email, @phone)", patient);
            }


            // Wyślij email z loginem i hasłem
            EmailSender.Email($"Login: {randomLogin}, Hasło: {randomPassword}",patient.email);

            // Powiadom o tym
            Error.show("Udana Rejestracja!", "Login i hasło został wysłany na podany adres email!");

            WindowViewModel.Instance.SwitchView(ViewPage.PatientLogin, new LoginViewModel());
        }
    }
}
