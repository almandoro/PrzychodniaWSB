using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Models {

    public class UserModel {

        public int user_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserRole role { get; set; }

        public UserModel() {

        }
    }
}
