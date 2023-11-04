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
            var data1=data.Select(i=>new })
            return Ok(data);
        }

        [HttpGet]
        [Route("ListDetails/{id}")]
        public IActionResult Get(int id)
        {
            if(id==null)
            return BadRequest("Id cannot be null");
            var data=context.Details.Find(id);
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
            return Created("Record added");
          }
          return BadRequest("Record not adeed");
          
        }

      
    }
}