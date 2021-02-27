using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace toplearn.Core.Convertor
{
     public static class ConverToShamsi
    {

        public static String ShamsiDate(this DateTime value)
        {
            PersianCalendar pr = new PersianCalendar();
            return pr.GetYear(value) +"/"+ pr.GetMonth(value).ToString("00") +"/"+ pr.GetDayOfMonth(value).ToString("00");
        }
    }
}
