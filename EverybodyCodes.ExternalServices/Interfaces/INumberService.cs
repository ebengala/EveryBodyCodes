using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryBodyCodes.ExternalServices.Interfaces
{
    public interface INumberService
    {
        Task<List<int>> GetNumbersAsync(string id);
    }
}
