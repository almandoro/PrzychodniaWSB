using PrzychodniaWSB.Core.Clinic.Entity;
using PrzychodniaWSB.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Clinic {
    class Clinic : IClinic {

        private Doctor doctor;

        public Doctor Doctor {
            get { return doctor; }
            set { doctor = value; }
        }

        private Stack<Patient> patientsStack;

        public Stack<Patient> PatientsStack {
            get { return patientsStack; }
            set { patientsStack = value; }
        }

        public void SetDoctor(string name, string lastName, string specialization) {
            this.doctor = new Doctor(name, lastName, specialization);
        }

        public string DoMedicalAdvice() {
            throw new NotImplementedException();
        }

        public string DoMedicalExamination() {
            throw new NotImplementedException();
        }

        public void GenerateReport() {
            throw new NotImplementedException();
        }

        public uint QueTime() {
            throw new NotImplementedException();
        }

        public void RegisterToDoctor(string name, string lastname, uint age, string disease) {
            var patient = new Patient(age, disease, name, lastname);
            this.patientsStack.Push(patient);
        }
    }
}
