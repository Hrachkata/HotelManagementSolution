using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.FloorServices.Contracts;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Areas.Hotel.Controllers
{

    /// <summary>
    /// Controller used to see rooms available for reservation.
    /// </summary>

    [Authorize]
    [Area("Hotel")]
    public class FrontDeskController : Controller
    {
        private readonly IFrontDeskServices frontDeskServices;

        private readonly IFloorServices floorServices;

        public FrontDeskController(IFrontDeskServices _frontDeskServices, IFloorServices _floorServices)
        {
            frontDeskServices = _frontDeskServices;

            floorServices = _floorServices;
        }

        /// <summary>
        /// Lists all rooms available for reservation based on query params.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: FrontDeskController/Create
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FreeRooms([FromQuery] AllFreeRoomsViewModel query, int id)
        {
            if (query.ArrivalDate == null)
            {
                query.ArrivalDate = DateTime.Now;
                query.DepartureDate = DateTime.Now.AddDays(1);
            }



            var queryResult = await frontDeskServices
                .All(query.ArrivalDate,
                    query.DepartureDate,
                    query.RoomSorting,
                    query.RoomType,
                    query.Available,
                    query.SearchTerm,
                    query.CurrentPage,
                    AllFreeRoomsViewModel.RoomsPerPage,
                    id);



            query.TotalRoomsCount = queryResult.TotalRoomsCount;

            query.Rooms = queryResult.Rooms.ToList();

            query.RoomTypes = await floorServices.GetRoomTypes();

            if (query.ArrivalDate >= query.DepartureDate || query.DepartureDate.HasValue == false)
            {
                ModelState.AddModelError("", "Departure date cannot be before arrival date.");

                query.ArrivalDate = DateTime.Now;
                query.DepartureDate = DateTime.Now.AddDays(1);

                return View(query);
            }


            foreach (var room in query.Rooms)
            {

                room.ArrivalDate = query.ArrivalDate;

                room.DepartureDate = query.DepartureDate;
            }


            return View(query);
        }


    }
}
