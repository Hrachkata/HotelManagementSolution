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

                try
                {
                    model = await roomServices.GetRoomEditViewModelAsync(model.Id);
                }
                catch (ArgumentNullException ex)
                {
                    TempData["ErrorType"] = ex.GetType().Name;

                    TempData["ErrorMessage"] = ex.Message;

                    return RedirectToAction("Index", "Home");
                }

                return View(model);
            }

            int result;

            try
            {
                result = await roomServices.EditRoomWithRegisterViewModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return RedirectToAction("Details", "Room", new { id = model.Id.ToString() });
        }


        // POST: RoomController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            bool result;
            try
            {
                result = await roomServices.DeleteRoomById(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (OperationCanceledException ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }

        // POST: RoomController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Enable(int id)
        {
            bool result;
            try
            {
                result = await roomServices.EnableRoomById(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }

        [HttpGet]
        public async Task<ActionResult> IsCleaned(int id)
        {
            bool result;
            try
            {
                result = await roomServices.IsCleanedAsync(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }

        [HttpGet]
        public async Task<ActionResult> IsDirty(int id)
        {
            bool result;
            try
            {
                result = await roomServices.IsDirtyAsync(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }


        [HttpGet]
        public async Task<ActionResult> OutOfService(int id)
        {
            bool result;

            try
            {
                result = await roomServices.RoomOutOfServiceByIdAsync(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }

        [HttpGet]
        public async Task<ActionResult> InService(int id)
        {
            bool result;

            try
            {
                result = await roomServices.RoomInServiceByIdAsync(id);
            }
            catch (ArgumentNullException ex)
            {

                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorType"] = ex.GetType().Name;

                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id = id });
        }
    }
}