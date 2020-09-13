using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using wooliesx_prizk.Core;
using wooliesx_prizk.Models;
using wooliesx_prizk.Providers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace woolies_prizk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly IEnumerable<ICalculator> calcs;

        public TrolleyTotalController(IEnumerable<ICalculator> calcs)
        {
            this.calcs = calcs;
        }

        [HttpPost("")]
        public async Task<ActionResult> ExerciseThree(E3Data request, string token= "not required")
        {
            EnsureArg.IsNotNull(request);

            //this is over simplified because of a lack of time.
            return Ok(calcs.Min(c => c.Calculate(request)));
        }
    }
}
