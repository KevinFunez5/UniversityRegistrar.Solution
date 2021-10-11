using System.Collections.Generic;

namespace University.Models
{
  public class Course
  {
    public Course()
    {
        this.JoinEntities = new HashSet<StudentCourse>();
        this.JoinEntities2 = new HashSet<DepartmentCourse>();
    }

    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public virtual ICollection<StudentCourse> JoinEntities { get; set;}
    public virtual ICollection<DepartmentCourse> JoinEntities2 { get; set;}
  }
}