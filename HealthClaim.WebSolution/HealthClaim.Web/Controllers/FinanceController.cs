using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BillPassing()
        {
            return View();
        }
        public IActionResult Banking()
        {
            return View();
        }
    }
}
