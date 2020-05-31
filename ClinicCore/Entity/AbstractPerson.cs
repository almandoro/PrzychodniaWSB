using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.Core.Clinic.Entity {

    public class AbstractPerson {

        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string lastName;

        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        protected AbstractPerson(string name, string lastName) {
            this.name = name;
            this.lastName = lastName;
        }


    }
}
