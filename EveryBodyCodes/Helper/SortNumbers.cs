using System;
using System.Collections.Generic;
using System.Text;

namespace EveryBodyCodes.Helper
{
    public static class SortNumbers
    {
        public static List<int> GetSortNumbersbyConfiguration(List<int> numbers, string sort)
        {
            if (sort == "asc")
            {
                numbers.Sort();
                return numbers;
            }

            if (sort == "desc")
            {
                numbers.Sort();
                numbers.Reverse();
                return numbers;
            }

            return numbers;
        }
    }
}
