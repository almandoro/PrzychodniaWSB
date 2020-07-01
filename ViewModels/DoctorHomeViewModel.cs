using Dapper;
using PrzychodniaWSB.ClinicCore;
using PrzychodniaWSB.ClinicCore.Utils;
using PrzychodniaWSB.Core.Clinic.Entity;
using PrzychodniaWSB.Models;
using PrzychodniaWSB.Utils;
using PrzychodniaWSB.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ViewModels {
    public class DoctorHomeViewModel : ViewModel {

        public PatientModel currentPatient { get; set; }

        public List<PatientModel> getAllPatients() {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var visits = cnn.Query<PatientQue>(
                    $"SELECT * " +
                    $"FROM visits " +
                    $"WHERE doctor_id='{UserCache.currentDoctor.doctor_id}'", new DynamicParameters());


                List<PatientModel> list = new List<PatientModel>();
                foreach (var item in visits) {
                    var patient = cnn.Query<PatientModel>(
                        $"SELECT * " +
                        $"FROM patients " +
                        $"WHERE patient_id='{item.patient_id}'", new DynamicParameters());
                    list.Add(patient.First());
                }

                return list;
            }
        }

        public PatientModel findPatientByName(string name) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientModel>(
                    $"SELECT * " +
                    $"FROM patients " +
                    $"WHERE name='{name}'", new DynamicParameters());

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

        public List<PatientQue> getVisitById(int id) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientQue>(
                    $"SELECT * " +
                    $"FROM visits", new DynamicParameters());

                return output.ToList();
            }
        }

        public void removeVisit(int id) {

            using (IDbConnection cnn = new SQLiteConnection(AppSettings.connectionString)) {
                var output = cnn.Query<PatientQue>(
                    $"SELECT * " +
                    $"FROM visits " +
                    $"WHERE visit_id='{id}'", new DynamicParameters());

            }
        }

        public void makeAdvice(PatientModel patient, string text, int visitId) {

            var email = patient.email;
            EmailSender.Email(text,email,"Porada Medyczna - MedicalCare");
            Error.show("Sukces!", $"Wykonano poradę lekarską dla {patient.name}");
            Logger.debug($"Mail wysłany na email {email} z treścią {text}");

            removeVisit(visitId);
        }

        public void makeTreatment(PatientModel patient, string text, int visitId) {

            var email = patient.email;
            EmailSender.Email(text, email, "Badanie Lekarskie - MedicalCare");
            Error.show("Sukces!", $"Wykonano badanie lekarskie dla {patient.name}");
            Logger.debug($"Mail wysłany na email {email} z treścią {text}");

            removeVisit(visitId);
        }

    }
}
