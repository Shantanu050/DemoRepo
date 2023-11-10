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

        public IActionResult Edit(Employee emp)
        {
            Employee e=context.Employees.Find(emp.Id);
            e.EmpName=
        }

    }
}