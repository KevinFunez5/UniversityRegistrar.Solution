using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Collections.Generic;
using System.Linq;

namespace University
{
  public class DepartmentsController : Controller
    {
      private readonly UniversityContext _db;

      public DepartmentsController(UniversityContext db)
      {
        _db = db;
      }

      public ActionResult Index()
      {
        List<Department> model = _db.Departments.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        return View();
      }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Departments
      .Include(department => department.JoinEntities2)
      .ThenInclude(join => join.Course)
      .FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

      [HttpPost]
      public ActionResult Edit(Department department)
      {
          _db.Entry(department).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
          var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
          return View(thisDepartment);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
        _db.Departments.Remove(thisDepartment);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      [HttpPost]
      public ActionResult DeleteCourse(int joinId)
      {
        var joinEntry = _db.CourseDepartment.FirstOrDefault(entry => entry.CourseDepartmentId == joinId);
        _db.CourseDepartment.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}