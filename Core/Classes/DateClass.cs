using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace Core
{
    public class DateClass
    {
        public static int GetDate()
        {
            // persian date

            DateTime miladi = DateTime.Today;

            PersianCalendar shamsi = new PersianCalendar();

            int y = shamsi.GetYear(miladi);
            int m = shamsi.GetMonth(miladi);
            int d = shamsi.GetDayOfMonth(miladi);

            int sha = y * 10000 + m * 100 + d;

            return sha;
        } 
    }
}
