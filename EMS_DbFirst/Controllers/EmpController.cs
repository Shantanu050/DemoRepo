using Microsoft.AspNetCore.Mvc;
using EMS_DbFirst.Models;
namespace EMS_DbFirst.Controllers
{
    public class EmpController:Controller
    {
        private readonly EmsdbContext context;
        public EmpController(EmsdbContext _context)
        {
            context=_context;
        }
       
        public IActionResult List()
        {
            var data=context.Employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.DeptId=new SelectList(context.Departments,"Id","DeptName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if(ModelState.IsValid)
            {
            context.Employees.Add(e);
            context.SaveChanges();
            return RedirectToAction("List");
            }
            ViewBag.DeptId=SelectList(context.Departments,"Id","DeptName");
            return View(e);
        }

        
    }
}