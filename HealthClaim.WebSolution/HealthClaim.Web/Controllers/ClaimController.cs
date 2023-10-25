using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class ClaimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } public IActionResult Advance()
        {
            return View();
        } public IActionResult AdvanceClaim()
        {
            return View();
        }
        public IActionResult DirectClaim()
        {
            return View();
        }

        public IActionResult Consultation()
        {
            return View();
        }
        public IActionResult Investigation()
        {
            return View();
        }
        public IActionResult Medication()
        {
            return View();
        }
    }
}
