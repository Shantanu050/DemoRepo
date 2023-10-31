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
            List<Department>data=null;
            try{

                data=context.Departments.ToList();
                if(data.Count==0)
                throw new Exception();
            }
            catch(System.Exception)
            {
                ViewBag.ErrorMessage="No records present";
                return View("Error");
            }
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if(ModelState.IsValid)
            {
                context.Departments.Add(dept);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var data=context.Departments.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Department p)
        {
            Department dept=context.Departments.Find(p.Id);
            dept.DeptName=p.DeptName;
            dept.Location=p.Location;
            context.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var data=context.Departments.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Department dept)
        {
            Department dept1=context.Departments.Find(dept.Id);
            context.Departments.Remove(dept1);
            context.SaveChanges();
            return RedirectToAction("List");
        }


    }
}