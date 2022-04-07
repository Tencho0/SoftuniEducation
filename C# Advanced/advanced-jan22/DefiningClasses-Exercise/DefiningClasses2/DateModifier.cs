using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int Difference(string first, string second)
        {
            DateTime firstDate = DateTime.Parse(first);
            DateTime secondDate = DateTime.Parse(second);
            int result = (int)(firstDate - secondDate).TotalDays;
            return result;
        }
    }
}
