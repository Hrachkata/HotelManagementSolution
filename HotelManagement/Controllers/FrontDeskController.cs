using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class FrontDeskController : Controller
    {
        private readonly IFrontDeskServices frontDeskServices;

        public FrontDeskController(IFrontDeskServices _frontDeskServices)
        {
            frontDeskServices = _frontDeskServices;
        }

        // GET: FrontDeskController
        [HttpGet]
        public async Task<ActionResult> WalkIn()
        {
            return View(await frontDeskServices.GenerateReservationViewModelAsync());
        }

        [HttpPost]
        public async Task<ActionResult> WalkIn(ReservationsViewModel model)
        {

            var k = model;

            Console.WriteLine(model.Room.RoomType);

            return View(model);
        }

        // GET: FrontDeskController/Details/5
        public ActionResult Reservations()
        {
            return View();
        }

        // GET: FrontDeskController/Create
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BookGuest([FromQuery] AllRoomsViewModel query, int id)
        {
            Console.WriteLine(id);

            var queryResult = await this.floorServices
                .All(query.RoomSorting,
                    query.RoomType,
                    query.Active,
                    query.SearchTerm,
                    query.IsAvailable,
                    query.CurrentPage,
                    AllRoomsViewModel.RoomsPerPage,
            id);

            query.TotalRoomsCount = queryResult.TotalRoomsCount;

            query.Rooms = queryResult.Rooms.ToList();

            query.RoomTypes = await floorServices.GetRoomTypes();



            return View(query);
        }

        // POST: FrontDeskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FrontDeskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FrontDeskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FrontDeskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FrontDeskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
