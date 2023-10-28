using Microsoft.AspNetCore.Mvc;

namespace EMS_DbFirst.Controllers
{
    public class DeptController:Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}