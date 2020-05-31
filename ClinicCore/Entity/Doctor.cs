using PrzychodniaWSB.Core.Clinic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Entity {
    public class Doctor : AbstractPerson {

        private string specialization;

        public string Specialization {
            get { return specialization; }
            set { specialization = value; }
        }

        public Doctor(string name, string lastName, string specialization) : base(name,lastName) {
            this.specialization = specialization;
        }

        public override string ToString() {
            string result = $"[Lekarz]\n" +
                            $"\tImie: {this.Name}\n" +
                            $"\tNazwisko: {this.LastName}\n" +
                            $"\tSpecjalizacja: {this.specialization}\n";
            return result;
        }
    }
}
