using Dapper;
using PrzychodniaWSB.ClinicCore;
using PrzychodniaWSB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ViewModels {
    public class AdminHomeViewModel :ViewModel {

        public List<UserModel> getAllUsers() {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<UserModel>(
                    $"SELECT * " +
                    $"FROM users", new DynamicParameters());

                return output.ToList();
            }

        }

        public UserModel findUserByLogin(string login) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<UserModel>(
                    $"SELECT * " +
                    $"FROM users " +
                    $"WHERE login='{login}'", new DynamicParameters());

                return output.First();
            }
        }

        public void deleteUser(string login) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query($"DELETE FROM users WHERE login='{login}'", new DynamicParameters());
            }
        }
    }
}
