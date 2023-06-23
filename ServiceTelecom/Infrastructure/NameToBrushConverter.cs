using ServiceTelecom.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ServiceTelecom.Infrastructure
{
    internal class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, 
            Type targetType, 
            object parameter, CultureInfo culture)
        {
            string input = (string)value;
            switch (input)
            {
                case UserModelStatic.IN_REPAIR_TECHNICAL_SERVICES:
                    return "#D2D235";
                case UserModelStatic.PASSED_TECHNICAL_SERVICES:
                    return Brushes.LightGreen;
                case UserModelStatic.DECOMMISSION_RADIOSTANTION:
                    return "#ed6825";
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
