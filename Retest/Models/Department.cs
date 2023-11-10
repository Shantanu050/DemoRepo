using System.ComponentModel.DataAnnotations;
using System.Collections;
namespace Retest.Models
{
    public class Department
    {
        [Key]
        public int Id{get;set;}
        public string DeptName{get;set;}
        public string Location{get;set;}
        public ICollection<Employee>Employee{get;set;}
    }
}