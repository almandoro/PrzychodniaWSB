using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Models {
    public class PatientModel {

        public int patient_id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public double phone { get; set; }

        public UserRole role = UserRole.Patient;

        public PatientModel() {

        }

    }
}
