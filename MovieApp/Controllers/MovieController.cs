using MovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
//using Swashbuckle.AspNetCore;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public  class MovieController:ControllerBase
    {
        MovieContext context=new MovieContext();

        [HttpGet]
        [Route("ListMovies")]
        public IActionResult Get()
        {
            //var data=context.Details.ToList();
               var data=from m in context.Movies select m;
               return Ok(data);
        }

        [HttpGet]
        [Route("ListMovies/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            return BadRequest("Id cannot be null");
            var data=from m in context.Movies where m.Id==id select m;
            return Ok(data);
        }
    }
}
