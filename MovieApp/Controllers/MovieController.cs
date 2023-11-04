using MovieApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameWork;
using Microsoft.EntityFrameWork.SqlServer;
//using Swashbuckle.AspNetCore;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public  class MovieController:ControllerBase
    {
        MovieContext context=new MovieContext();
    }
}
