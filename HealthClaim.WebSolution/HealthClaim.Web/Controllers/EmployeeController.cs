using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult Family()
        {
            return View();
        }

    }
}
