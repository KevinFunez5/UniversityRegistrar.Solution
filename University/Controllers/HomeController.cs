using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult HomePage() 
    { 
      return View(); 
    }
  }
}