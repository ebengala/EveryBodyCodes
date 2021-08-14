using EveryBodyCodes.ExternalServices.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using EveryBodyCodes;
using System.IO;

namespace EveryBodyCodes.ExternalServices
{
    public class CameraService : ICameraService
    {
        public async Task<List<TinyCsvParser.Mapping.CsvMappingResult<EntityCamera>>> GetCamerasByNameAsync()
        {
            var csvParserOptions = new CsvParserOptions(true, ';');
            var csvMapper = new CameraMapper();

            var filePath = "C:\\cameras-defb.csv";
            
            if (!File.Exists(@filePath))
            {
                return null;
            }

            var csvParser = new CsvParser<EntityCamera>(csvParserOptions, csvMapper);
            return csvParser.ReadFromFile(@"C:\\cameras-defb.csv", Encoding.ASCII)?.ToList();
        }
    }
}

