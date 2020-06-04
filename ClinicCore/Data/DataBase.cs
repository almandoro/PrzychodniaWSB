using Dapper;
using PrzychodniaWSB.Core.Entity;
using PrzychodniaWSB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ClinicCore.Data {
    public class DataBase {

        private static string cStr = AppSettings.connectionString;
        public static List<DoctorModel> LoadPeople() {
            using (IDbConnection cnn = new SQLiteConnection(cStr)) {
                var output = cnn.Query<DoctorModel>("select name from doctors", new DynamicParameters());
                foreach(var item in output) {
                    Console.WriteLine(item.ToString());
                }
                return output.ToList();
            }
        }

    }
}
