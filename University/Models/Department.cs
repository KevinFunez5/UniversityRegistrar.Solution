using System.Collections.Generic;

namespace University.Models
{
  public class Department
  {
    public Department()
    {
        this.JoinEntities2 = new HashSet<CourseDepartment>();
    }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public virtual ICollection<CourseDepartment> JoinEntities2 { get; set;}
  }
}