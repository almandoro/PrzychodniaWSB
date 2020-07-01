using PrzychodniaWSB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzychodniaWSB.ClinicCore.Utils {
    public class Popup {
        public static void show(string title, string text) {
            Error err = new Error {
                TitleBar = { Text = title },
                Textbar = { Text = text }
            };
        }
    }
}
