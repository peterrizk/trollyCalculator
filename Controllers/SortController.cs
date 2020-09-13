using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wooliesx_prizk.Core;
using wooliesx_prizk.Models;
using wooliesx_prizk.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace woolies_prizk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        private readonly ISortStrategyJunction strategyJunction;
        private readonly EndpointProvider endpointProvider;

        public SortController(ISortStrategyJunction strategyJunction
            , EndpointProvider endpointProvider)
        {
            this.strategyJunction = strategyJunction;
            this.endpointProvider = endpointProvider;
        }

        [HttpGet("")]
        public async Task<ActionResult> ExerciseTwo(SortOptions sortOption)
        {
            var strategy = await strategyJunction.Get(sortOption);
            var results = await strategy.Sort();

            return Ok(results);
        }


    }
}
