using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace dentistry.PageF
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value as string;
            switch (status)
            {
                case "Ожидание": return new SolidColorBrush(Color.FromRgb(0xFF, 0xA0, 0x00));
                case "Подтвержден": return new SolidColorBrush(Color.FromRgb(0x4C, 0xAF, 0x50));
                case "Отменено": return new SolidColorBrush(Color.FromRgb(0xF4, 0x43, 0x36));
                default: return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}