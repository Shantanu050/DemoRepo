using System.ComponentModel.DataAnnotations;
namespace Retest.Models
{
    public class Employee
    {
        [Key]
        public int Id{get;set;}
        public string EmpName{get;set;}
        public int DeptId{get;set;}
        public string Email{get;set;}
    }

}