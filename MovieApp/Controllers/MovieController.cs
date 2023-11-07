using MovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System;
using MovieApp.ViewModel;
//using Swashbuckle.AspNetCore;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public  class MovieController:ControllerBase
    {
        MovieContext context=new MovieContext();
        [HttpGet]
        [Route("ShowMovies")]
        public IActionResult GetShowMovies()
        {
            var data=context.Movie_VMs.FromSqlInterpolated<Movie_VM>($"MovieInfo");
            return Ok(data);
        }

        [HttpGet]
        [Route("DisplayMovies/Rating/Year")]
        public IActionResult GetDisplayMovies(int rating,int year)
        {
           var data=from movie in context.Movies where movie.YearRelease==year && movie.Rating==rating select movie;
           if(data.Count()==0)
           {
            return NotFound("No movies found");
           }
           return Ok(data);
        }

        [HttpGet]
        [Route("DisplayRating")]
        public IActionResult GetDisplayRating([FromQuery] int rating )
        {
            var data=context.Movies.Where(m=>m.Rating==rating);
           if(data.Count()==0)
           {
            return NotFound("No movies found");
           }
           return Ok(data);

        }
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

        [HttpPut]
        [Route("EditMovie/{id}")]
        public IActionResult Put(int id,Movie movie)
        {
           if(ModelState.IsValid)
           {
            Movie omovie=context.Movies.Find(id);
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
             var data=context.Movies.Find(id);
             context.Movies.Remove(data);
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
