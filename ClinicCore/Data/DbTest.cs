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
    public class DbTest {

        private static String conStr = "Data Source=C:\\Users\\Maciek\\Desktop\\Przychodnia\\PrzychodniaWSB\\clinic.db";

        public static List<DoctorModel> LoadPeople() {
            using (IDbConnection cnn = new SQLiteConnection(conStr)) {
                var output = cnn.Query<DoctorModel>("select * from doctors", new DynamicParameters());
                foreach(var item in output) {
                    Console.WriteLine(item.ToString());
                }
                return output.ToList();
            }
        }

    }
}
