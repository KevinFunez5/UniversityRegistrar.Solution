using Microsoft.EntityFrameworkCore;

namespace University.Models
{
  public class UniversityContext : DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public DbSet<StudentCourse> StudentCourse { get; set; }
    public DbSet<CourseDepartment> CourseDepartment { get; set; }

    public UniversityContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}