using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ClinicCore.Utils {
    public class LoginGenerator {

        public static string generateLogin(string name, string lastname) {

            var chars = "0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var uName = name.ToCharArray()[0].ToString().ToLower();
            var uLast = lastname.ToCharArray()[0].ToString().ToLower();

            var login = uName+uLast+new String(stringChars);

            return login;
        }

        public static string generatePassword() {

            var chars = "!@#$%^&*()ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++) {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
