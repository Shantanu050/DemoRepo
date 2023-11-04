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
            var data=context.Details.Include("Movie");
            var data1=data.Select(i=>new {i.Name,i.Actor,i.Role});
            return Ok(data1);
        }

        [HttpGet]
        [Route("MovieDetails/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            return BadRequest("Id cannot be null");
            var data=from i in context.Details select new{i=>i.Actor,}
            if(data==null)
            return NotFound("Id "+id+" is not present");
            return Ok(data);
        }

        

      
    }
}