using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Retest.Models
{
    public class Employee
    {
        [Key]
        public int Id{get;set;}
        public string EmpName{get;set;}
        [ForeignKey("Department")]
        public int DeptId{get;set;}
        public string Email{get;set;}
        public Department Department{get;set;}
    }

}