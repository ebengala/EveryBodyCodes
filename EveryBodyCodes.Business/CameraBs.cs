
using EveryBodyCodes.ExternalServices.Interfaces;
using EveryBodyCodes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EveryBodyCodes.Business
{
    public class CameraBs : ICameraBs
    {

        private readonly ICameraService cameraService;

        public CameraBs(ICameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        public async Task<List<EntityCamera>> GetCamerasByNameAsync(string Name)
        {            
            var csvResult = await cameraService.GetCamerasByNameAsync();
            if (csvResult == null)
                return null;

            var filterResults = csvResult.Select(item => item.Result).Where(item => item != null && item.Camera.Contains(Name)).ToList();

            return filterResults;
        }
    }
}
