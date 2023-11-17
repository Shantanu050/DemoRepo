using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        if(user.UserName=="root" && user.Password=="root")
        {
           var secretKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
           var signinCredentials=new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
           var tokenOptions=new JwtSecuriyToken
        }
       }

    }
}