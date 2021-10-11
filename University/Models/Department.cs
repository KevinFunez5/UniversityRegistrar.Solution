using System.Collections.Generic;

namespace University.Models
{
  public class Department
  {
    public Department()
    {
        this.JoinEntities2 = new HashSet<DepartmentCourse>();
    }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public virtual ICollection<DepartmentCourse> JoinEntities2 { get; set;}
  }
}