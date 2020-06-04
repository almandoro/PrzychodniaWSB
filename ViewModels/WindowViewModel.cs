using PrzychodniaWSB.ViewModels;
using PrzychodniaWSB.ViewModels.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrzychodniaWSB{
    public class WindowViewModel : ViewModel {

        /// <summary>
        /// Aktualnie wyswietlany widok w glownym oknie
        /// </summary>
        public ViewPage CurrentPage { get; set; } = ViewPage.PreLogin;
        public ViewModel CurrentPageViewModel { get; set; }

        private Window window;

        public WindowViewModel(Window window) {
            this.window = window;

        }

        #region Properties
        /// <summary>
        /// Minimalna szerokosc glownego okna
        /// </summary>
        public double MIN_WIDTH { get; set; } = 500;

        /// <summary>
        /// Minimalan wysokosc glownego okna
        /// </summary>
        public double MIN_HEIGHT { get; set; } = 800;

        #endregion
        public void SwitchView(ViewPage page, ViewModel viewModel = null) {
            
            // Set the view model
            CurrentPageViewModel = viewModel;

            var different = CurrentPage != page;

            CurrentPage = page;

            if(!different)
                OnPropertyChanged(nameof(CurrentPage));

        }

    }
}
