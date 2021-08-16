
using EveryBodyCodes.ExternalServices.Interfaces;
using EveryBodyCodes.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveryBodyCodes.Business
{
    public class CameraBs : ICameraBs
    {

        private readonly ICameraService cameraService;

        private readonly Configurations options;

        public CameraBs(IOptions<Configurations> options, ICameraService cameraService)
        {
            this.cameraService = cameraService;
            this.options = options.Value;
        }

        public async Task<List<EntityCamera>> GetCamerasByNameAsync(string Name)
        {            
            var csvResult = await cameraService.GetCamerasAsync(options.CamerasCSVPath);
            if (csvResult == null)
                return null;

            var filterResults = csvResult.Select(item => item.Result).Where(item => item != null && item.Camera.Contains(Name)).ToList();

            return filterResults;
        }
    }
}
