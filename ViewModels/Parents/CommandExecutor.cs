using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzychodniaWSB {

    /// <summary>
    /// Nadrzedna klasa do implementowania komend <see cref="Action"/>
    /// </summary>
    class CommandExecutor : ICommand {

        /// <summary>
        /// Komenda do wywolania
        /// </summary>
        private Action action;

        CommandExecutor(Action action) {
            this.action = action;
        }

        /// <summary>
        /// Event, ktory jest wywolywany, gdy <see cref="CanExecute(object)" zostanie wywolane/>
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary> 
        /// Domyslnie komenda moze byc uruchamiana
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) {
            return true;
        }


        /// <summary>
        /// Wywolanie <see cref="Action"/> komendy
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) {
            action();
        }
    }
}
