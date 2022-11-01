using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class ManageAccountController : Controller
    {
        public IActionResult Settings()
        {
            return View("../Account/Manage/_ManageNav");
        }
    }
}
