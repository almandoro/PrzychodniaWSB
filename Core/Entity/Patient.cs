using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Clinic.Entity {
    public class Patient : AbstractPerson {

        public  Patient(string name, string lastName) : base(name, lastName) {
        }
    }
}
