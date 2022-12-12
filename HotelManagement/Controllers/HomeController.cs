using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HotelManagement.EmailService;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;

namespace HotelManagement.Controllers
{
    /// <summary>
    /// Standard Home controller.
    /// </summary>

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

    
        public IActionResult Index()
        {
            Log.Logger.Information("{Info}", "Index page");
            return View();

        }

        public IActionResult Unauthorized()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            Log.Logger.Information("{Info}", "Privacy page");
            return View();

        }


        /// <summary>
        /// Logs every error.
        /// </summary>
        /// <returns>Error handling page</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            Log.Logger.Error(feature.Error, "TraceIdentifier: {0} Error message: {1}", Activity.Current?.Id ?? HttpContext.TraceIdentifier, feature.Error.Message);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}