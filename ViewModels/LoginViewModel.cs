using Dapper;
using PrzychodniaWSB.ClinicCore;
using PrzychodniaWSB.ClinicCore.Utils;
using PrzychodniaWSB.Models;
using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels;
using PrzychodniaWSB.ViewModels.Parents;
using PrzychodniaWSB.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB {
    public class LoginViewModel : ViewModel{

        public LoginViewModel() {

        }
        

        public bool performLogin(string userName, string password, ViewPage page, ViewModel model = null) {
            using(IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {

                var output = cnn.Query<UserModel>(
                    $"SELECT *" +
                    $" FROM users" +
                    $" WHERE login='{userName}'" +
                    $" AND password='{password}'", new DynamicParameters());

                if (output.Count() == 1) {

                
                    var user = output.First();
                    UserCache.currentUser = user;
                
                    if(user.role == UserRole.Patient) {

                        var result = cnn.Query<PatientModel>(
                            $"SELECT * " +
                            $"FROM patients " +
                            $"WHERE user_id=@user_id", user);
                        var temp = result.First();
                        UserCache.currentPatient = temp;

                    } else if(user.role == UserRole.Doctor) {

                        var result = cnn.Query<DoctorModel>(
                            $"SELECT *" +
                            $" FROM doctors" +
                            $" WHERE user_id=@user_id", user);
                        var temp = result.First();
                        UserCache.currentDoctor = temp;

                    } else if(user.role == UserRole.Admin) {

                        var result = cnn.Query<AdminModel>(
                            $"SELECT *" +
                            $" FROM admins " +
                            $" WHERE user_id=@user_id", user);
                        var temp = result.First();
                        UserCache.currentAdmin = temp;
                    }

                    WindowViewModel.Instance.SwitchView(page, model);

                    return true;
                } else {
                    Error.show("Błąd", "Login lub hasło jest błędne!");
                    return false;
                }

            }
        }

    }
}
