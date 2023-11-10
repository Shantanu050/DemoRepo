using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Retest.Models
{
    public class RetestDbContezt:DbContext
    {
        public virtual DbSet<Employee>Employees{get;set;}
        public virtual DbSet<Department>Departments{get;set;}

        public RetestDbContezt(){}
        public RetestDbContezt(DbContextOptions<RetestDbContezt>options):base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder obj)=>
        obj.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=RetestDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");


    }
}