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
    /// Logika interakcji dla klasy DoctorHome.xaml
    /// </summary>
    public partial class DoctorHome : Page {

        DoctorHomeViewModel vm = (DoctorHomeViewModel)WindowViewModel.Instance.CurrentPageViewModel;

        public DoctorHome() {
            InitializeComponent();
            fillPatients(PatientsComboBox);
        }

        private void fillPatients(ComboBox box) {
            var patients = vm.getAllPatients();
            foreach (var patient in patients) {
                box.Items.Add(patient.name);
            }
        }

        private void PatientsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            // Znajdz pacjenta
            var name = PatientsComboBox.SelectedValue.ToString();
            var patient = vm.findPatientByName(name);
            vm.currentPatient = patient;

            // Znajdz jego rejestracje
            fillQue(VisitsGrid, patient);

            // Aktualizuj info wybranego pacjenta
            NameTextBox.Text = patient.name;
            LastNameTextBox.Text = patient.lastname;
            AgeTextBox.Text = patient.age.ToString();
            SexTextBox.Text = patient.sex;

        }

        private void fillQue(DataGrid grid, PatientModel patient) {


            var visits = vm.getVisitById(patient.patient_id);

            foreach (var visit in visits) {

                var q = new Visit() {
                    date = visit.date,
                    disease = visit.disease,
                    visit_id = visit.que_id
                };

                if (!grid.Items.Contains(q))
                    grid.Items.Add(q);
            }
            
        }

        public class Visit {
            public string disease { get; set; }
            public string date { get; set; }
            public int visit_id { get; set; }
        }

        private void AdviceButton_Click(object sender, RoutedEventArgs e) {

            var patient = vm.currentPatient;
            var visit = (Visit)VisitsGrid.SelectedItem;
            if (visit == null || patient == null) {
                Error.show("Błąd!", "Proszę wybrać pacjenta i jego konkretną wizytę!");
                return;
            }

            // Aktualizuj bazę
            var text = $"Porada Lekarska dla {patient.name}:\n" +
                    $"Porada na chorobę : {visit.disease}" +
                    $"Proszę nie wychodzić z domu i brać leki!\n" +
                    $"Pozdrawiam ;)";
            vm.makeAdvice(patient, text, visit.visit_id);

            // Aktualizuj UI
            VisitsGrid.Items.Remove(visit);
        }

        private void TreatmentButton_Click(object sender, RoutedEventArgs e) {

            var patient = vm.currentPatient;
            var visit = (Visit)VisitsGrid.SelectedItem;
            if (visit == null || patient == null) {
                Error.show("Błąd!", "Proszę wybrać pacjenta i jego konkretną wizytę!");
                return;
            }
            
            // Aktualizuj bazę
            var text = $"Badanie Lekarskie dla {patient.name}:\n" +
                    $"Przebadana choroba : {visit.disease}" +
                    $"Proszę nie wychodzić z domu i brać leki!\n" +
                    $"Pozdrawiam ;)";
            vm.makeAdvice(patient, text,visit.visit_id);

            // Aktualizuj UI
            VisitsGrid.Items.Remove(visit);

        }
    }
}
