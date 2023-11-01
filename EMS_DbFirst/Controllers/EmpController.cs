using Microsoft.AspNetCore.Mvc;
using EMS_DbFirst.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var data=context.Employees.Include("Dept").ToList();
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
           
            context.Employees.Add(e);
            context.SaveChanges();
            //context.Update(e);
            return RedirectToAction("List");
            
           
        }

        
    }
}