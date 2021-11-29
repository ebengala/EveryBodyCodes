using EveryBodyCodes.Interfaces;
using EveryBodyCodes.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EveryBodyCodes.Helper;

namespace EveryBodyCodes.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly ILogger<NumberController> _logger;
        private readonly INumberBs numberBs;
        private readonly Configurations options;

        public NumberController(IOptions<Configurations> options, INumberBs numberBs, ILogger<NumberController> logger)
        {
            this.numberBs = numberBs;
            _logger = logger;
            this.options = options.Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<int>), 200)]
        //[ServiceFilter(typeof(PrimeNumberActionFilter))]
        [ServiceFilter(typeof(PrimeNumberActionFilter))]
        public IActionResult RemovePrimeNumbers([Required] List<int> Numbers)
        {
            if (Numbers == null)
                return BadRequest($"Numbers '{Numbers}'");

            var result = numberBs.DoSomethingWithNumbers(Numbers);

            var sortedResult = SortNumbers.GetSortNumbersbyConfiguration(Numbers, options.NumbersOrder);

            if (sortedResult != null)
            {
                return Ok(sortedResult);
            }
            return NotFound($"There are no results for the numbers:'{Numbers}' ");

        }
    }
}


