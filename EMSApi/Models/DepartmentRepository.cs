using System.Collections.Generic;
using System.Linq;
namespace EMSApi.Models
{
    public class DepartmentRepository:IDept
    {
       EmsdbContext context=new EmsdbContext();
       public void AddDept(Department department)
       {
        context.Departments.Add(department);
        context.SaveChanges();
       }

       public void EditDept(Department dept)
       {
          Department d=context.Departments.Find(dept.Id);
          d.DeptName=dept.DeptName;
          d.Location=dept.Location;
          context.SaveChanges();
       }

       public void DeleteDept(int id)
       {
           Department d=context.Departments.Find(id);
           context.Departments.Remove(d);
           context.SaveChanges();
       }

       public Department FindDept(int id)
       {
          var data=context.Departments.Find(id);
          return data;
       }

       public List<Department> GetDepartments()
       {
         return context.Departments.ToList();
       }
    }
}