using PrzychodniaWSB.Converters;
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

                case ViewPage.Login:
                    Logger.debug("Pokazuje LoginView");
                    return new LoginView();

                case ViewPage.PreLogin:
                    Logger.debug("Pokazuje PreLoginView");
                    return new PreLoginView();

                default:
                    Logger.error("Strona nieznana!");
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
