using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EveryBodyCodes.ExternalServices.Interfaces
{
    public interface ICameraService
    {
        Task<List<TinyCsvParser.Mapping.CsvMappingResult<EntityCamera>>> GetCamerasByNameAsync();
    }
}
