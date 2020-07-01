using PrzychodniaWSB.Converters;
using PrzychodniaWSB.Core.Clinic.Entity;
using PrzychodniaWSB.Utils;
using PrzychodniaWSB.ViewModels.Parents;
using PrzychodniaWSB.Views;
using System;
using System.Globalization;

namespace PrzychodniaWSB {

    /// <summary>
    /// Konwertuje enum <see cref="ViewPage"/> na widok WPF
    /// </summary>
    public class ViewPageConverter : AbstractConverter<ViewPageConverter> {

        /// <summary>
        /// Szuka requestowany widok w enumie <see cref="ViewPage"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
           
            switch((ViewPage) value) {

                case ViewPage.PatientHome:
                    return new PatientHome();

                case ViewPage.DoctorHome:
                    return new DoctorHome();

                case ViewPage.AdminHome:
                    return new AdminHome();

                case ViewPage.PreLogin:
                    return new PreLoginView();

                case ViewPage.PatientLogin:
                    return new PatientLoginView();

                case ViewPage.AdminLogin:
                    return new AdminLoginView();

                case ViewPage.DoctorLogin:
                    return new DoctorLoginView();

                case ViewPage.PatientChoose:
                    return new PatientChooseView();

                case ViewPage.Register:
                    return new RegisterView();

                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
