using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wooliesx_prizk.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace woolies_prizk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public UserController()
        {
        }

        [HttpGet("")]
        public ActionResult ExerciseOne()
        {
            return Ok(new E1Response());
        }


    }
}
