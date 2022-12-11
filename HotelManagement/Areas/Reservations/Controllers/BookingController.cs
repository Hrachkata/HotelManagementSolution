using System.Data;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Areas.Reservations.Controllers
{
    [Area("Reservations")]
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

            bool result;



            try
            {
                result = await bookingService.reserveRoom(model);

                if (result == false)
                {
                    throw new DBConcurrencyException("No rows modified, data is invalid.");
                }
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }
            catch (Exception ex)
            {
                TempData["status"] = 404;

                throw;
            }



            return RedirectToAction("FreeRooms", "FrontDesk", new { area= "Hotel", arrivalDate = model.ArrivalDate.Value.ToString("yyyy-MM-dd"), departureDate = model.DepartureDate.Value.ToString("yyyy-MM-dd") });

        }




    }
}
