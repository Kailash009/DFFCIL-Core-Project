using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdvanceApproved()
        {
            return View();
        }
        public IActionResult ClaimApproved()
        {
            return View();
        }
        public IActionResult ClaimAfterDoctorReview()
        {
            return View();
        }
        public IActionResult ClaimAfterDoctorReviewFinal()
        {
            return View();
        }
        public IActionResult DoctorReview()
        {
            return View();
        }
        public IActionResult DoctorReviewList()
        {
            return View();
        }
        public IActionResult FinanceStep1()
        {
            return View();
        }
        public IActionResult FinanceShiv()
        {
            return View();
        }
    }
}
