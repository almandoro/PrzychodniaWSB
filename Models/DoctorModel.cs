using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Models {
    public class DoctorModel {

        public int doctor_id { get; set; }
        public int clinic_id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string specialization { get; set; }

        public override string ToString() {
            return $"Doctor id {doctor_id} clinic_id {clinic_id} name {name} lastname {lastName} specialization {specialization}";
        }
    }
}
