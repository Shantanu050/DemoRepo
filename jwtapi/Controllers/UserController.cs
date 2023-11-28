using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jwtapi.Models;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Collections;
namespace jwtapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppdContext _authContext;
        public UserController(AppdContext context)
        {
            _authContext=context;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userObj)
        {
         if(userObj==null) return BadRequest();
         var user =await _authContext.Users.FirstOrDefaultAsync(x=>x.Username==userObj.Username);
         if(user==null)
         {
            return NotFound(new {Message="User not found"});
         }
         user.Token=CreateJwt(user);
         var newAccessToken=user.Token;
         user.RefreshToken=CreateRefreshToken();
         user.RefreshTokenExpiryTime=DateTime.Now.AddDays(2);
         await _authContext.SaveChanges();
         return Ok(new TokenApi(){
            AccessToken=newAccessToken,
            RefreshToken=
         }
        }
    }
}