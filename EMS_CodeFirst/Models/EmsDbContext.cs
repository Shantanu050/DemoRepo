using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace  EMS_CodeFirst.Models
{
    public class EmsDbContext:DbContext
    {
        public virtual DbSet<Employee>Employee{get;set;}
        public  virtual DbSet<Dept>Dept{get;set;}

        public EmsDbContext(){}
        public EmsDbContext(DbContextOptions<EmsDbContext>options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=Emsdb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
            }
        }
    }
}