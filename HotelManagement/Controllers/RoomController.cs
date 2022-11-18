using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomServices roomServices;

        public RoomController(
            IRoomServices _roomServices
            )
        {
            roomServices = _roomServices;
        }

        // GET: RoomController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var result = new RoomDetailsViewModel();

            try
            {
                result = await roomServices.GetRoomDetailsModelAsync(id);
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            

            return View(result);
        }

        // GET: RoomController/Create
       public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
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


        // GET: RoomController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            var model = new RoomEditViewModel();

            try
            {
                model = await roomServices.GetRoomEditViewModelAsync(id);
            }
            catch (ArgumentNullException ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
                   

            return View(model);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoomEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid submit form.");
            }

            int result;

            try
            {
                result = await roomServices.EditRoomWithRegisterViewModel(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View(model);
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
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
