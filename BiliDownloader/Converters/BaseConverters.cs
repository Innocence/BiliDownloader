﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BiliDownloader.Converters
{
    public abstract class BaseConverters<TFrom, TTo> : IValueConverter
    {
        public abstract TTo Convert(TFrom value, Type targetType, object parameter, CultureInfo culture);
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Convert((TFrom)value, targetType, parameter, culture);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public abstract TFrom ConvertBack(TTo value, Type targetType, object parameter, CultureInfo culture);

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ConvertBack((TTo)value, targetType, parameter, culture);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
