
using EveryBodyCodes.ExternalServices.Interfaces;
using EveryBodyCodes.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveryBodyCodes.Business
{
    public class NumberBs : INumberBs
    {

        private readonly Configurations options;

        public NumberBs(IOptions<Configurations> options)
        {
            this.options = options.Value;
        }

        /// <summary>
        /// Do some business logic
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public List<int> DoSomethingWithNumbers(List<int> numbers)
        {

            return numbers;

        }
    }
}
