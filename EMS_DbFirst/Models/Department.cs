using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EMS_DbFirst.Models;

public partial class Department
{
    public int Id { get; set; }

    public string DeptName { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
