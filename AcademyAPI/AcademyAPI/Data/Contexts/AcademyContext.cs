using AcademyAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Data.Contexts;

public class AcademyContext : DbContext
{
    public AcademyContext()
    {
        
    }

    public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
    {

    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(dep =>
        {
            dep.HasKey(k => k.Id);

            dep.Property(p => p.Name).IsRequired().HasMaxLength(200);

            dep.HasIndex(p => p.Name).IsUnique();

        });

        modelBuilder.Entity<Faculty>(faculty =>
        {
            faculty.HasKey(k => k.Id);
            faculty.Property(p => p.Name).IsRequired().HasMaxLength(200);
            faculty.HasIndex(p =>p.Name).IsUnique();    

            faculty.Property(p => p.DepartmentsNumber).IsRequired();
            faculty.ToTable(t => t.HasCheckConstraint("DepartmentsNumberCheck", "DepartmentsNumber > 0"));

        });

        modelBuilder.Entity<Group>(group =>
        {
            group.HasKey(k => k.Id);
            group.Property(p => p.Name).IsRequired().HasMaxLength(100);
            group.HasIndex(p => p.Name).IsUnique();

            group.Property(p => p.Year).IsRequired();
            group.ToTable(t => t.HasCheckConstraint("YearConstraint", "Year > 0 AND Year < 7"));

            group.HasOne(x => x.Teacher).WithMany(y => y.Groups).HasForeignKey(k => k.TeacherId).OnDelete(DeleteBehavior.Restrict);
            group.HasOne(x => x.Faculty).WithMany(y => y.Groups).HasForeignKey(k => k.FacultyId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Student>(student =>
        {
            student.HasKey(k => k.Id);
            student.Property(p => p.Name).IsRequired().HasMaxLength(100);
            student.Property(p => p.Surname).IsRequired().HasMaxLength(100);
            
            student.Property(p => p.Age).IsRequired();
            student.ToTable(t => t.HasCheckConstraint("AgeCheck", "Age > 15"));

            student.HasOne(x => x.Group).WithMany(y => y.Students).HasForeignKey(k => k.GroupId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Teacher>(teacher =>
        {
            teacher.HasKey(k => k.Id);
            teacher.Property(p => p.Name).IsRequired().HasMaxLength(100);
            teacher.Property(p => p.Surname).IsRequired().HasMaxLength(100);
            teacher.Property(p => p.Subject).IsRequired().HasMaxLength(200);

            teacher.HasOne(x => x.Department).WithMany(y => y.Teachers).HasForeignKey(k => k.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            teacher.Property(p => p.WorkHours).IsRequired();
            teacher.ToTable(t => t.HasCheckConstraint("WorkHoursCheck", "WorkHours > 0"));
        });


    }
}
