using PrzychodniaWSB.Core.Clinic.Entity;
using PrzychodniaWSB.Core.Entity;
using PrzychodniaWSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ClinicCore.Utils {
    public class UserCache {
        public static UserModel currentUser = null;
        public static PatientModel currentPatient = null;
        public static DoctorModel currentDoctor = null;
        public static AdminModel currentAdmin = null;
    }
}
