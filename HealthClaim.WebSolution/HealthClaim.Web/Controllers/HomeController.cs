using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdvanceRequest()
        {
            return View();
        }
    }
}
