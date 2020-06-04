using Dapper;
using PrzychodniaWSB.ClinicCore;
using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels;
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
        

        public bool performLogin(string userName, string password) {
            using(IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query(
                    $"SELECT login, password, role" +
                    $" FROM users" +
                    $" WHERE login='{userName}'" +
                    $" AND password='{password}'", new DynamicParameters());

                switch(output.Count()) {

                    case 1:
                        Logger.debug($"User found {output}");
                        return true;

                    default:
                        Logger.error("User not found!");
                        return false;
                }
            }
        }

    }
}
