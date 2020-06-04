using System;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrzychodniaWSB.ViewModels {

    public class ViewModel : INotifyPropertyChanged {

        /// <summary>
        /// Event wywolany, gdy wlasciwosc podana przez <see cref="OnPropertyChanged(string)"/> zmieni wartość
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { } ; 

        /// <summary>
        /// Wywoluje event <see cref="PropertyChanged"/>
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name) {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
