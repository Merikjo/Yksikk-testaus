using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yksikkötestaus
{
    public class Pääsiäinen
    {
        public DateTime GetEasterSunday(int year)
        {
            // check that the input year is within range
            if ((year < 1900) || (year > 2100))
            {
                throw new ArgumentOutOfRangeException("year", "The year must be between 1900 and 2100 inclusive.");
            }

            // calculate Easter
            int golden = year % 19; // the "golden" lunar cycle
            int century = year / 100;
            int h = (century - (century / 4) - ((8 * century + 13) / 25) + 19 * golden + 15) % 30;
            int i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * (21 - golden) / 11);

            // convert to day and month
            int day = i - ((year + (year / 4) + i + 2 - century + (century / 4)) % 7) + 28;
            int month = 3;

            // does the day overflow?
            if (day > 31)
            {
                month++;
                day -= 31;
            }

            // convert the result to a DateTime
            DateTime easterSunday = new DateTime(year, month, day);
            return easterSunday;
        }
    }
}
