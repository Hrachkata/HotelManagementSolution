using System.Data;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
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
           
            var queryResult = await this.reservationServices
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
                result = await this.reservationServices.CheckIn(model.Id, model.RoomId);

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

            return View("ReservationDetails");
        }


        [HttpPost]
        [Authorize]

        public async Task<IActionResult> CheckOut(SingleReservationViewModel model)
        {
            bool result;

            try
            {
                result = await this.reservationServices.CheckOut(model.Id, model.RoomId);

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
            
            return View("ReservationDetails");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ReservationDetails(SingleReservationViewModel model)
        {
            return View(model);
        }

    }
}
