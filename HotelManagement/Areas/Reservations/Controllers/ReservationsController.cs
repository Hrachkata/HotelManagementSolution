using System.Data;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelManagement.Areas.Reservations.Controllers
{
    /// <summary>
    /// This is the controller used for checking in and out guests and viewing reservations
    /// </summary>

    [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
    [Area("Reservations")]
    public class ReservationsController : Controller
    {
        private readonly IReservationServices reservationServices;
        public ReservationsController(IReservationServices _reservationServices)
        {
            reservationServices = _reservationServices;
        }

        /// <summary>
        /// Returns all reservations based on query params
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>

        [HttpGet]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
        public async Task<IActionResult> AllReservations([FromQuery] AllReservationsModel query)
        {

            var queryResult = await reservationServices
                .All(query.ArrivalDateFrom,
                    query.ArrivalDateTo,
                    query.ReservationSorting,
                    query.SearchTerm,
                    query.CurrentPage,
                    AllFreeRoomsViewModel.RoomsPerPage);



            query.TotalReservationsCount = queryResult.TotalReservationsCount;

            query.Reservations = queryResult.Reservations.ToList();

            return View(query);
        }


        /// <summary>
        /// Checks in guests
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]

        public async Task<IActionResult> CheckIn(SingleReservationViewModel model)
        {
            bool result;

            try
            {
                result = await reservationServices.CheckIn(model.Id, model.RoomId);

                if (result == false)
                {
                    throw new DBConcurrencyException("No changes made.");
                }
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (DBConcurrencyException e)
            {
                TempData["status"] = 400;

                throw;
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (Exception e)
            {
                TempData["status"] = 400;

                throw;
            }


            Log.Logger.Information("User {0} checked IN reservation with ID:{1}", this.User?.Identity?.Name ?? "NAME MISSING", model.Id);

            ViewData["Status"] = "Check in";
            return View("ReservationDetails", model);
        }

        /// <summary>
        /// Checks reservation out
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]

        public async Task<IActionResult> CheckOut(SingleReservationViewModel model)
        {
            bool result;

            try
            {
                result = await reservationServices.CheckOut(model.Id, model.RoomId);

                if (result == false)
                {
                    throw new DBConcurrencyException("No changes made.");
                }
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (DBConcurrencyException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (Exception e)
            {
                TempData["status"] = 400;

                throw;
            }



            Log.Logger.Information("User {0} checked OUT reservation with ID:{1}", this.User?.Identity?.Name ?? "NAME MISSING", model.Id);

            ViewData["Status"] = "Check out";
            return View("ReservationDetails", model);
        }

        /// <summary>
        /// Get reservation details view
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
        public async Task<IActionResult> ReservationDetails(SingleReservationViewModel model)
        {
            return View(model);
        }

        /// <summary>
        /// Prints the fiscal folio when guest has paid either on check in or check out
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
        public async Task<IActionResult> PrintFolio(SingleReservationViewModel model)
        {
            bool result;

            try
            {
                result = await reservationServices.PrintFolioPaid(model.Id);

                if (result == false)
                {
                    throw new DBConcurrencyException("No changes made.");
                }
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (DBConcurrencyException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (Exception e)
            {
                TempData["status"] = 400;

                throw;
            }
            
            Log.Logger.Information("User {0} Printed folio for reservation with ID:{1}", this.User?.Identity?.Name ?? "NAME MISSING", model.Id);
            Log.Logger.Information("Reservation with ID: {0}, Total: {1} paid", model.Id, model.totalPrice);

            ViewBag.PaymentSuccess = "true";

            return View("ReservationDetails", model);
        }


        /// <summary>
        /// Cancels reservation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]

        [Authorize(Roles = ("Owner,Director,Manager,Admin,Front Desk,Manager"))]
        public async Task<IActionResult> Cancel(SingleReservationViewModel model)
        {
            bool result;

            try
            {
                result = await reservationServices.CancelReservation(model.Id);

                if (result == false)
                {
                    throw new DBConcurrencyException("No changes made.");
                }
            }
            catch (ArgumentNullException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (DBConcurrencyException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (Exception e)
            {
                TempData["status"] = 400;

                throw;
            }

            Log.Logger.Information("User {0} CANCELED reservation with ID:{1}", this.User?.Identity?.Name ?? "NAME MISSING", model.Id);

            return View("ReservationDetails", model);
        }
    }
}
