using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.ReservationsModels;
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
        public ActionResult Create()
        {
            return View();
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
