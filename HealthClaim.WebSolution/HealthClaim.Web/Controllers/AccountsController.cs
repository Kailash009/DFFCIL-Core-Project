
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {  
            return Json(new { success = false, message = "Username or Password are wrong!" });
        }
        public IActionResult Registeration()
        {
            return View();
        }
    }
}
