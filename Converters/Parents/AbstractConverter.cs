using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace PrzychodniaWSB.Converters {

    /// <summary>
    /// Abstrakcyjny konwerter na potrzeby XAML
    /// </summary>
    /// <typeparam name="T">Typ do konwersji</typeparam>
    public abstract class AbstractConverter<T> : MarkupExtension, IValueConverter where T : class, new() {

        private static T instance = null;

        #region IValueConverter Implementation
        /// <summary>
        /// Metoda do konwersji typu obiektow
        /// </summary>
        /// <param name="value">Obiekt, ktory przeksztalcamy</param>
        /// <param name="targetType">Typ docelowy</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Metoda do przywrocenia bazowego typu obiektu
        /// </summary>
        /// <param name="value">Obiekt, ktory przeksztalcamy</param>
        /// <param name="targetType">Typ docelowy</param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion

        #region MarkupExtension XAML Implementation
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return instance ?? (instance = new T());
        }
        #endregion
    }
}
