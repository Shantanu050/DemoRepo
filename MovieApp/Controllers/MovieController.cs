using MovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System;
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
            {
            return BadRequest("Id cannot be null");
            }
            var data=(from m in context.Movies where m.Id==id select m).FirstOrDefault();
            if(data==null)
            {
                return NotFound($"Movie {id} not found");
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("AddMovie")]
        public IActionResult Post(Movie movie)
        {
            if(ModelState.IsValid)
            {
                try
                {
                   context.Movies.Add(movie);
                   context.SaveChanges();
                }
                catch(Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }

            }
            return Created("Record Added",movie);
        }

    }
}
