using Microsoft.AspNetCore.Mvc;
using EMS_DbFirst.Models;
namespace EMS_DbFirst.Controllers
{
    public class DeptController:Controller
    {
       private readonly EmsdbContext context;
       public DeptController(EmsdbContext _context)
       {
          context=_context;
       }
        public IActionResult List()
        {
            var data=context.Departments
            return View();
        }
    }
}