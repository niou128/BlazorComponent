using System;
using System.Globalization;

namespace BlazorDataGrid.Helpers
{
    public static class DisplayHelper
    {
        public static string DisplayDate(object dt, string format = null, string cultureInfo = null)
        {
            if (dt is null)
            {
                return string.Empty;
            }

            CultureInfo culture;
            if (cultureInfo == null)
            {
                culture = CultureInfo.InvariantCulture;
            }
            else
            {
                try
                {
                    culture = new CultureInfo(cultureInfo);
                }
                catch (CultureNotFoundException)
                {
                    culture = CultureInfo.InvariantCulture;
                }
            }

            string displayDate;

            if (dt.GetType() == typeof(DateTime))
            {
                var rr = Convert.ToDateTime(dt);
                if (string.IsNullOrEmpty(format))
                {
                    displayDate = rr.ToString(culture);
                }
                else
                {
                    displayDate = rr.ToString(format, culture);
                }
            }
            else
            {
                DateTime dateTime;
                try
                {

                    dateTime = DateTime.Parse(dt.ToString(), culture);

                    displayDate = string.IsNullOrEmpty(format) ? dateTime.ToString(culture) : dateTime.ToString(format);
                }
                catch (FormatException)
                {
                    return string.Empty;
                }
            }
            return displayDate;
        }
    }
}
