using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Retest.Models;
namespace Retest.Controllers
{
    public class EmpController:Controller
    {
        private readonly RetestDbContezt context;
        public EmpController(RetestDbContezt _context)
        {
            context=_context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       public IActionResult Edit(int id)
       {
          var data=context.Employees.Find(id);
          return View(data);
       }
       [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            Employee e=context.Employees.Find(emp.Id);
            e.EmpName=emp.EmpName;
            e.DeptId=emp.DeptId;
            e.Email=emp.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
      public IActionResult Delete(int id)
       {
          var data=context.Employees.Find(id);
          return View(data);
       }

       [HttpPost]
       public IActionResult Delete(Employee e)
       {
        Employee emp=context.Employees.Find(e.Id);
        context.Employees.Remove(emp);
        context.SaveChanges();
        return RedirectToAction("Index");

       }



    }
}