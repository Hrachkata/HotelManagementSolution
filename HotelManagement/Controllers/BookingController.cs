using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [HttpGet]
        public ActionResult Reserve(SingleFreeRoomModel model)
        {
            BookingModel bookingModel = bookingService.projectRoomModelToBookingModel(model);


            return View(bookingModel);

        }

        [HttpPost]
        public async Task<ActionResult> Reserve(BookingModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.DepartureDate <= model.ArrivalDate)
            {
                ModelState.AddModelError("", "Departure date cannot be before arrival date.");

                return View(model);
            }

            var result = await bookingService.reserveRoom(model);

            return RedirectToAction("Index", "Home");

        }
    }
}
