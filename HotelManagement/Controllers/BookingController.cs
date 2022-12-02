using System.Data;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Models;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;

        private readonly string envir = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
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
            catch(DBConcurrencyException ex)
            {
                if (envir == "Development")
                {
                    throw ex;
                }
                var error = new ErrorViewModel()
                {
                    ErrorMessage = ex.Message,
                };

                return View("Error", error);
            }
            catch (Exception ex)
            {
                if (envir == "Development")
                {
                    throw ex;
                }
                var error = new ErrorViewModel()
                {
                    ErrorMessage = "Critical error occurred try again later, if error persists contact your system administrator."
                };
                
                return View("Error", error);
            }

            

            return RedirectToAction("FreeRooms", "FrontDesk", new{arrivalDate = model.ArrivalDate.Value.ToString("yyyy-MM-dd"), departureDate = model.DepartureDate.Value.ToString("yyyy-MM-dd") });

        }

    

        
    }
}
