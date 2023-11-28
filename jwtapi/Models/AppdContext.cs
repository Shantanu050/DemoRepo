using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace jwtapi.Models
{
    public class AppdContext:DbContext
    {
        public AppdContext(){}

        public AppdContext(DbContextOptions<AppdContext>options):base(options)
        {

        }
        public DbSet<User>Users{get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder obj)=>
        obj.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=AuthDb;trusted_connection=false;Persist Security Info=False;Encrypt=False");
    }
}