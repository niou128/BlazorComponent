using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDataGrid.Helpers
{
    public static class DisplayHelper
    {
        public static string DisplayDate(object dt, string format = null)
        {
            string displayDate;
            if (dt.GetType() == typeof(string))
            {
                displayDate = dt.ToString();
            }
            else if (dt.GetType() == typeof(DateTime))
            {
                var rr = Convert.ToDateTime(dt);
                displayDate = rr.ToString(format);
            }
            else
            {
                displayDate = "other";
            }


            return displayDate;
        }
    }
}
