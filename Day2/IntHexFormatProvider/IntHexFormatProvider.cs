using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IntHexFormatProviderLibrary
{
    public class IntHexFormatProvider : IFormatProvider, ICustomFormatter
    {
        static readonly string[] hex = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split();

        IFormatProvider parent;

        public IntHexFormatProvider() : this(CultureInfo.CurrentCulture) { }
        public IntHexFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg == null || format != "H")
            {
                return string.Format(parent, "{0:" + format + "}", arg);
            }

            string value = string.Format(CultureInfo.InvariantCulture,"{0}", arg);
            StringBuilder result = new StringBuilder();
            int rest;
            int dev;
            int temp;
            if (!Int32.TryParse(value, out temp))
                throw new FormatException();

            do
            {
                dev = temp / 16;
                rest = temp % 16;

                result.Append(hex[rest]);
                temp = dev;
            }
            while (temp >= 16);
            result.Append(hex[dev]);

            var buf = result.ToString();
            var resultReversed = new StringBuilder();
            for (int count = buf.Length - 1; count > -1; count--)
            {
                resultReversed.Append(buf[count]);
            }

            return resultReversed.ToString();

        }
    }
}
