using System;
using System.Collections.Generic;
using System.Text;

namespace EveryBodyCodes.Helper
{
    public static class PrimeNumber
    {
        /// <summary>
        /// Look for prime number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPrimeNumber(int num)
        {
            var a = 0;
            var mod = num / 2;
            for (a = 2; a <= mod; a++)
            {
                if (num % a == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Remove all prime numbers from the list.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> RemovePrimeNumbersFromList(List<int> numbers)
        {
            if (numbers == null)
                return numbers;

            var resultWithoutPrimes = new List<int>();
            foreach (var num in numbers)
            {
                if(!IsPrimeNumber(num))
                {
                    resultWithoutPrimes.Add(num);
                }
            }

            return resultWithoutPrimes;
        }



    }
}
