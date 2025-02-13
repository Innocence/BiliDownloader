﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliDownloader.Converters
{
    public class LongToBitrateConverter : BaseConverters<long, string>
    {
        public static LongToBitrateConverter Instance { get; } = new LongToBitrateConverter();
        public override string Convert(long value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0:0.#} {1}/s", GetLargestWholeNumberValue(value), GetLargestWholeNumberSymbol(value));
        }

        public override long ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string GetLargestWholeNumberSymbol(long bytes)
        {
            if (bytes >= 0x100000)
                return "MB";
            else if (bytes is >= 0x400 and < 0x100000)
                return "KB";
            else
                return "B";
        }

        private static double GetLargestWholeNumberValue(long bytes)
        {
            if (bytes >= 0x100000)
                return bytes / 1048576.0;
            else if (bytes is >= 0x400 and < 0x100000)
                return bytes / 1024.0;
            else
                return bytes;
        }
    }
}
