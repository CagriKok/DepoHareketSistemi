using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CagriKok.WPF.Converters
{
    internal class MiktarVeBirimConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Tuple<decimal, string> miktarVeBirim)
            {
                decimal miktar = miktarVeBirim.Item1;
                string birim = miktarVeBirim.Item2;
                return $"{miktar} {birim}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
