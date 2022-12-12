using System.Data;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelManagement.Areas.Reservations.Controllers
{
    /// <summary>
    /// Controller used to book reservations
    /// </summary>

    [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
    [Area("Reservations")]

    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        /// <summary>
        /// Returns the reserve view for the dates in the front desk controller query.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Reserve(SingleFreeRoomModel model)
        {
            BookingModel bookingModel = bookingService.projectRoomModelToBookingModel(model);


            return View(bookingModel);

        }


        /// <summary>
        /// Post method for room reservation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
            
            Log.Logger.Information("User {0} reserved room with number {1}, ArrivalDate {2} DepartureDate {3}, guest {4}", this.User?.Identity?.Name ?? "NAME MISSING", model.RoomNumber, model.ArrivalDate, model.DepartureDate);
            
            return RedirectToAction("FreeRooms", "FrontDesk", new { area= "Hotel", arrivalDate = model.ArrivalDate.Value.ToString("yyyy-MM-dd"), departureDate = model.DepartureDate.Value.ToString("yyyy-MM-dd") });

        }




    }
}
