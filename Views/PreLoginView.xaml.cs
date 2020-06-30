﻿using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels.Parents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrzychodniaWSB.Views {
    /// <summary>
    /// Logika interakcji dla klasy PreLoginView.xaml
    /// </summary>
    public partial class PreLoginView : Page {

        private Button activatedButton;
        private Ellipse activatedElipse;

        public PreLoginView() {
            Button activatedButton = (Button)FindName("PatientButton");
            Ellipse activatedElipse = (Ellipse)FindName("PatientSelected");
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e) {
            
        WindowViewModel.Instance.SwitchView(ViewPage.Login, new LoginViewModel());
        }
    }
}
