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
    public class DetailController:ControllerBase
    {
        MovieContext context=new MovieContext();
        [HttpGet]
        [Route("ListDetails")]
        public IActionResult Get()
        {
            var data=from i in context.Details select new{i.DetailId,i.MovieId,i.Movie.Name,i.Actor,i.Role};
            return Ok(data);
        }

        [HttpGet]
        [Route("MovieDetails/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            return BadRequest("Id cannot be null");
            var data=from i in context.Details where i.MovieId==id select new{i.Actor,i.Role,i.Movie.Name,i.Movie.YearRelease};
            if(data==null)
            return NotFound("Id "+id+" is not present");
            return Ok(data);
        }

        [HttpPost]
        [Route("AddDetails")]
        public IActionResult Post(Detail detail)
        {
           if(ModelState.IsValid)
           {
            context.Details.Add(detail);
            context.SaveChanges();
            return Created("Record added",detail);
           }
           return BadRequest("Data is not valid");
        }

        [HttpPut]
        [Route("EditDetails/{id}")]
        public IActionResult Put(int id, Detail detail)
        {
            if(ModelState.IsValid)
            {
             Detail d=context.Details.Find(id);
             d.Actor=detail.Actor;
             d.MovieId=detail.MovieId;
             d.Role=detail.Role;
             d.Gender=detail.Gender;
             context.SaveChanges();
             return Ok();
            }
            return BadRequest("Unable to edit");
        }
        
        [HttpDelete]
        [Route("DeleteDetails/{id}")]
        public IActionResult Delete(int id)
        {
           var data=context.Details.Find(id);
           context.Details.Remove(data);
           context.SaveChanges();
           return Ok();
        }
        

      
    }
}