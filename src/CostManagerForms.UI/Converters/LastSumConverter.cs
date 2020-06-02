using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Model.RequestItems.CostsByWallet;
using Xamarin.Forms;

namespace CostManagerForms.UI.Converters
{
    public class LastSumConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var wallet = (WalletOfCosts)value;
            return wallet.Sum - wallet.LastSum;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
