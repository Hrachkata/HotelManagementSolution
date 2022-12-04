using System.Data;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Areas.Reservations.Controllers
{
    [Area("Reservations")]
    public class ReservationsController : Controller
    {
        private readonly IReservationServices reservationServices;

        private readonly string envir = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public ReservationsController(IReservationServices _reservationServices)
        {
            reservationServices = _reservationServices;
        }


        [HttpGet]
        [Authorize]
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

        [HttpPost]
        [Authorize]

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
                ModelState.AddModelError("", e.Message);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
            }
            catch (Exception e)
            {
                if (envir == "Development")
                {
                    ModelState.AddModelError("", e.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Critical error occurred, please try again later.");
                }
            }

            ViewData["Status"] = "Check in";
            return View("ReservationDetails", model);
        }


        [HttpPost]
        [Authorize]

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
                if (envir == "Development")
                {
                    ModelState.AddModelError("", e.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Critical error occurred, please try again later.");
                }
            }

            ViewData["Status"] = "Check out";
            return View("ReservationDetails", model);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ReservationDetails(SingleReservationViewModel model)
        {
            return View(model);
        }


        [HttpPost]
        [Authorize]
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
                if (envir == "Development")
                {
                    ModelState.AddModelError("", e.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Critical error occurred, please try again later.");
                }
            }

            ViewBag.PaymentSuccess = "true";

            return RedirectToAction("ReservationDetails", model);
        }


        [HttpPost]
        [Authorize]
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
                if (envir == "Development")
                {
                    ModelState.AddModelError("", e.Message);
                }
                else
                {
                    ModelState.AddModelError("", "Critical error occurred, please try again later.");
                }
            }


            return RedirectToAction("ReservationDetails", model);
        }
    }
}
