using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelManagement.Areas.Hotel.Controllers
{
    [Area("Hotel")]
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
                TempData["status"] = 404;

                throw;
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
                TempData["status"] = 404;

                throw;
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

                return RedirectToAction("Edit", new{id= model.Id});
            }

            int result;

            try
            {
                result = await roomServices.EditRoomWithEditViewModel(model);
            }
            catch (ArgumentNullException e)
            {
                TempData["status"] = 404;

                throw;
            }
            catch (DBConcurrencyException e)
            {
                TempData["status"] = 400;

                throw;
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
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

                TempData["status"] = 404;

                throw;
            }
            catch (OperationCanceledException ex)
            {
                TempData["status"] = 409;

                throw;
            }
            catch (DBConcurrencyException ex)
            {
                TempData["status"] = 400;

                throw;
            }

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }
    }
}