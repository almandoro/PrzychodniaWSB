using PrzychodniaWSB.ClinicCore.Utils;
using PrzychodniaWSB.Core.Clinic.Entity;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static PrzychodniaWSB.ViewModels.PatientHomeViewModel;

namespace PrzychodniaWSB.Views {


    /// <summary>
    /// Logika interakcji dla klasy PatientHome.xaml
    /// </summary>
    public partial class PatientHome : Page {

        PatientHomeViewModel vm = (PatientHomeViewModel)WindowViewModel.Instance.CurrentPageViewModel;

        public PatientHome() {
            InitializeComponent();
            fillDoctors(DoctorsComboBox);
            fillQue(QueGrid);
        }

        private void fillDoctors(ComboBox box) {
            var doctors = vm.getAllDoctors();

            foreach (var doc in doctors) {
                box.Items.Add($"{doc.name} - {doc.specialization}" );
            }
        }

        private void fillQue(DataGrid grid) {

          
            var visits = vm.getAllVisits();
            foreach (var visit in visits) {

                var patientName = vm.getPatientNameById(visit.patient_id);
                var doctorName = vm.getDoctorNameById(visit.doctor_id);

                var q = new Que() {
                    date = visit.date,
                    disease = visit.disease,
                    patientName = patientName,
                    doctorName = doctorName
                };

                if (!grid.Items.Contains(q))
                    grid.Items.Add(q);
    
            }

        }

        private void MedicalVisitButton_Click(object sender, RoutedEventArgs e) {

            Logger.debug(QueGrid.Items.Count.ToString());

            if (DoctorsComboBox.SelectedItem == null) {
                Error.show("Błąd", "Proszę wskazać lekarza");
                return;
            }

            if(DiseaseTextBox.Text == "") {
                Error.show("Błąd", "Proszę wskazać chorobę");
                return;
            }

            Logger.debug(VisitDate.SelectedDate.ToString());
            // Sprawdź datę
            if (!VisitDate.SelectedDate.HasValue) {
                Error.show("Błąd", "Proszę wskazać datę");
                return;
            } else {
                if(VisitDate.SelectedDate < DateTime.Now) {
                    Error.show("Błąd", "Data nie może być wcześniejsza niż jutro");
                    return;
                }
            }

           


            var docName = DoctorsComboBox.SelectedValue.ToString().Split('-')[0].Trim();
            var docSpec = DoctorsComboBox.SelectedValue.ToString().Split('-')[1].Trim();
            var doctor = vm.getDoctorByNameAndSpec(docName, docSpec);


            // Aktualizuj Baze danych
            var visit = new PatientQue() {
                date = VisitDate.SelectedDate.ToString(),
                disease = DiseaseTextBox.Text,
                doctor_id = doctor.doctor_id,
                patient_id = UserCache.currentPatient.patient_id                
            };
            vm.addVisit(visit);

            // Aktualizuj UI
            QueGrid.Items.Add(visit);
        }
    }
}
