using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMS_DbFirst.Models;

public partial class EmsdbContext : DbContext
{
    public EmsdbContext()
    {
    }

    public EmsdbContext(DbContextOptions<EmsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123;server=localhost;Database=Emsdb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.DeptName).HasMaxLength(30);
            entity.Property(e => e.Location).HasMaxLength(30);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.HasIndex(e => e.DeptId, "IX_Employee_DeptId");

            entity.HasIndex(e => e.Email, "IX_Employee_Email").IsUnique();

            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees).HasForeignKey(d => d.DeptId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
