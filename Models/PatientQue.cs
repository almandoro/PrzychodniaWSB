using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Models {
    public class PatientQue {

        public int que_id { get; set; }
        public int patient_id { get; set; }
        public int doctor_id { get; set; }
        public string date { get; set; }
        public string disease { get; set; }

        public PatientQue() {

        }

    }
}
