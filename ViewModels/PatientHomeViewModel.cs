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
    public class PatientHomeViewModel : ViewModel {

        public class Que {

            public string patientName { get; set; }
            public string doctorName { get; set; }
            public string disease { get; set; }
            public string date { get; set; }

            public Que() {

            }

            public Que(string patientName, string doctorName, string disease, string date) {
                this.patientName = patientName;
                this.doctorName = doctorName;
                this.disease = disease;
                this.date = date;
            }
        }

        public List<DoctorModel> getAllDoctors() {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<DoctorModel>(
                    $"SELECT * " +
                    $"FROM doctors", new DynamicParameters());

                return output.ToList();
            }
        }

        public DoctorModel getDoctorByNameAndSpec(string name, string specialization) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<DoctorModel>(
                    $"SELECT * " +
                    $"FROM doctors " +
                    $"WHERE name='{name}' AND specialization='{specialization}'", new DynamicParameters());

                return output.First();
            }
        }

        public List<PatientQue> getAllVisits() {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientQue>(
                    $"SELECT * " +
                    $"FROM visits", new DynamicParameters());

                return output.ToList();
            }
        }

        public List<PatientQue> addVisit(PatientQue patientQue) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientQue>(
                    $"INSERT INTO visits (patient_id,doctor_id,date,disease) " +
                    $"VALUES (@patient_id,@doctor_id,@date,@disease)", patientQue);

                return output.ToList();
            }
        }

        public string getPatientNameById(int id) {
            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientModel>(
                    $"SELECT name " +
                    $"FROM  patients " +
                    $"WHERE patient_id='{id}'", new DynamicParameters());

                var patient = output.First();
                return patient.name;
            }
        }

        public string getDoctorNameById(int id) {
            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<DoctorModel>(
                    $"SELECT name " +
                    $"FROM  doctors " +
                    $"WHERE doctor_id='{id}'", new DynamicParameters());

                var doctor = output.First();
                return doctor.name;
            }
        }
    }
}
