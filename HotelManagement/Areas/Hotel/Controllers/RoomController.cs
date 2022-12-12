using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Data;

namespace HotelManagement.Areas.Hotel.Controllers
{

    /// <summary>
    /// Room controller that enables viewing and manipulation of rooms.
    /// </summary>
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

        /// <summary>
        /// Gets the room details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View with room details</returns>
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



        /// <summary>
        /// Room edit get.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit view for room.</returns>

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


        /// <summary>
        /// Edit post, edits rooms.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
            Log.Logger.Information("User {0} edited room with number {1}", this.User?.Identity?.Name ?? "NAME MISSING", model.RoomNumber);

            return RedirectToAction("Details", "Room", new { id = model.Id.ToString() });
        }


        /// <summary>
        /// Disables room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

            Log.Logger.Information("User {0} disabled room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }


        /// <summary>
        /// Enables room 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

            Log.Logger.Information("User {0} enabled room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }


        /// <summary>
        /// Sets room status to cleaned
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

            Log.Logger.Information("User {0} set status cleaned to room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }

        /// <summary>
        /// Sets room status to dirty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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

            Log.Logger.Information("User {0} set status dirty to room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }

        /// <summary>
        /// Sets room status to out of service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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


            Log.Logger.Information("User {0} set status OutOfService to room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }

        /// <summary>
        /// Sets room status to in service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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


            Log.Logger.Information("User {0} set status InService to room with id {1}", this.User?.Identity?.Name ?? "NAME MISSING", id);

            return RedirectToAction(result ? "Details" : "Edit", "Room", new { id });
        }
    }
}