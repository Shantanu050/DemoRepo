using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
       [HttpPost]
       public IActionResult Login([FromBody] LoginModel user)
       {
        if(user is null)
        return BadRequest("Invalid client Request");
       }
       if(user)
    }
}