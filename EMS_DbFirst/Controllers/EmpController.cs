using Microsoft.AspNetCore.Mvc;
namespace EMS_DbFirst.Controllers
{
    public class EmpController:Controller
    {
         public IActionResult List()
        {
            return View();
        }
    }
}