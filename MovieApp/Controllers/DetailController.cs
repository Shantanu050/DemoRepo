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
            //var data=context.Details.ToList();
               var data=from m in context.Details select m;
               return Ok(data);
        }

        [HttpGet]
        [Route("ListDetails/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            {
            return BadRequest("Id cannot be null");
            }
            var data=(from m in context.Details where m.Id==id select m).FirstOrDefault();
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
                   context.Details.Add(movie);
                   context.SaveChanges();
                }
                catch(Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }

            }
            return Created("Record Added",movie);
        }

        [HttpPut]
        [Route("EditMovie/{id}")]
        public IActionResult Put(int id,Movie movie)
        {
           if(ModelState.IsValid)
           {
            Movie omovie=context.Details.Find(id);
            omovie.Name=movie.Name;
            omovie.Rating=movie.Rating;
            omovie.YearRelease=movie.YearRelease;
            context.SaveChanges();
            return Ok();
           }
           return BadRequest("Unable to edit record");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
          try
          {
             var detail=context.Details.Where(d=>d.MovieId==id);
             if(detail.Count()!=0)
             {
                throw new Exception("Cannot Delete Movie");
             }
             var data=context.Details.Find(id);
             context.Details.Remove(data);
             context.SaveChanges();
             return Ok();
          }
          catch(Exception e)
          {
            return BadRequest(e.Message);
          }
        }
    }
}