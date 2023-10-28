using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS_CodeFirst.Models;
using System.Collections.Generic;
namespace EMS_CodeFirst.Models
{
    [Table("Department")]
    public class Dept
    {
        public int Id{get;set;}
        [Required(ErrorMessage="Name cannot be blank")]
        [MaxLength(30)]
        [Column("DeptName")]
        public string Name{get;set;}
        [MaxLength(30)]
        public string Location{get;set;}
        public ICollection<Employee>Employee {get;set;}
    }
}