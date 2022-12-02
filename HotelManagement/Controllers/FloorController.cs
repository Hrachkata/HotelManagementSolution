using HotelManagement.Data.Services.FloorServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class FloorController : Controller
    {
        private readonly IFloorServices floorServices;

        public FloorController(IFloorServices _floorServices)
        {
            this.floorServices = _floorServices;
        }

        // GET: FloorController
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All([FromQuery] AllRoomsViewModel query, int id)
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

      
    }
}
