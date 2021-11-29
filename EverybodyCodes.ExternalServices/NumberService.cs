using EveryBodyCodes.ExternalServices.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveryBodyCodes;
using System.IO;

namespace EveryBodyCodes.ExternalServices
{
    public class NumberService : INumberService
    {
        public Task<List<int>> GetNumbersAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

