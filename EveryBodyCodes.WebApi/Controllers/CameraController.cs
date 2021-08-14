using EveryBodyCodes.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EveryBodyCodes.WebApi.Controllers
{
    [ApiController]
    [Route("Camera")]
    public class CameraController : ControllerBase
    {
        private readonly ILogger<CameraController> _logger;
        private readonly ICameraBs cameraBs;

        public CameraController(ICameraBs cameraBs, ILogger<CameraController> logger)
        {
            this.cameraBs = cameraBs;
            _logger = logger;
        }

        [HttpGet("{Name}")]
        [ProducesResponseType(typeof(List<EntityCameraResponse>), 200)]
        public async Task<IActionResult> Get([Required] string Name)
        {
            if (string.IsNullOrEmpty(Name))
                return BadRequest($"Name '{Name}'");

            var result = await cameraBs.GetCamerasByNameAsync(Name);


            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"There are no results for the camera name:'{Name}' ");

        }
    }
}


