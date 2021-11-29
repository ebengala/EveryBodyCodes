using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveryBodyCodes.Helper;
using Microsoft.AspNetCore.Mvc.Filters;


namespace EveryBodyCodes.WebApi.Filters
{
    public class PrimeNumberActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            var numbers = new object();

            if (context.ActionArguments.TryGetValue("Numbers", out numbers))
            {
                if (numbers != null)
                {
                    context.ActionArguments["Numbers"] = PrimeNumber.RemovePrimeNumbersFromList((List<int>)numbers);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
