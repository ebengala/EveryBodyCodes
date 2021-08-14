
using EveryBodyCodes;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace EveryBodyCodes.CLI
{
    public sealed class CameraMapper : CsvMapping<EntityCamera>
    {
        public CameraMapper() : base()
        {
            MapProperty(0, x => x.Camera);
            MapProperty(1, x => x.Longitude);
            MapProperty(2, x => x.Latitude);
        }
    }
}
