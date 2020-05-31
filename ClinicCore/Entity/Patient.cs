using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Clinic.Entity {
    public class Patient : AbstractPerson {

        private uint age;

        public uint Age {
            get { return age; }
            set { age = value; }
        }

        private string disease;

        public Patient(uint age, string disease, string name, string lastName) : base(name, lastName) {
            this.age = age;
            this.disease = disease;
        }

        public string Disease {
            get { return disease; }
            set { disease = value; }
        }

        public override string ToString() {
            string result = $"[Pacjent]\n" +
                            $"\tImie: {this.Name}\n" +
                            $"\tNazwisko: {this.LastName}\n" +
                            $"\tWiek: {this.age}\n" +
                            $"\tChoroba: {this.disease}\n";
            return result;
        }
    }
}
