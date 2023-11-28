using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jwtapi.Models;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Collections;
//-------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using jwtapi.Models;

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
         var newRefreshToken=CreateRefreshToken();
         user.RefreshTokenExpiryTime=DateTime.Now.AddDays(2);
         await _authContext.SaveChangesAsync();
         return Ok(new TokenApi(){
            AccessToken=newAccessToken,
            RefreshToken=newRefreshToken
         });
        }
        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] User userObj)
        {
            if(userObj==null) return BadRequest();
            //if any other validation 
            userObj.Role="user";
            userObj.Token="";
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChanges();
            return Ok(new {Status=200,Message="User Added"});

        }
        private string CreateJwt(User user)
        {
            var jwtTokenHandler=new JwtSecurityTokenHandler();
            var key=Encoding.ASCII.GetBytes("LTIM");
            var identify=new ClaimsIdentity(new Claim[]
            {
               new Claim(ClaimsType.Role,user.Role),
               new Claim(ClaimsType.Name,$"(user.Username)")

            });
            var credentials=new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);
            var tokenDescriptor=new SecurityTokenDescriptor
            {
                Subject=identity,
                Expires=DateTime.Now.AddDays(2),
                SigningCredentials=credentials

            };
            var token=jwtTokenHandler.CreateTokent(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }
        private string CreateRefreshToken()
        {
            var tokenBytes=RandomNumberGenerator.GetBytes(64);
            var refreshtoken=Convert.ToBase64String(tokenBytes);
            var tokenUser=_authContext.Users.Any(a=>a.RefreshToken==refreshtoken);
            if(tokenUser)
            {
                return CreateRefreshToken();
            }
            return refreshtoken;
        }
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authContext.Users.ToListAsync());
        }
        
    }
    
}