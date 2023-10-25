using HealthClaim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthClaim.Web.Controllers
{
    public class UserClaimController : Controller
    {
        private readonly ILogger<UserClaimController> _logger;

        public UserClaimController(ILogger<UserClaimController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InPatientAdvance()
        {
            return View();
        }

        public IActionResult InPatientAdvanceRequest()
        {
            return View();
        }

        public IActionResult InPatientDirectClaim()
        {
            return View();
        }
        public IActionResult InPatientAdvanceDetails()
        {
            return View();
        }

        public IActionResult InPatientClaim()
        {
            return View();
        }

        public IActionResult OutPatientClaim()
        {
            return View();
        }
        public IActionResult Investigation()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}