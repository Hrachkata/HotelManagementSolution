using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HotelManagement.EmailService;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private SendGridEmail _emailService;

        public HomeController(ILogger<HomeController> logger, SendGridEmail emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {

            await _emailService.Execute();
            return View();
        }

        public IActionResult Privacy()
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