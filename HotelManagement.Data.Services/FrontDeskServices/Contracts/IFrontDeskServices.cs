using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FrontDeskServices.Contracts;

public interface IFrontDeskServices
{

    /// <summary>
    /// Returns all free rooms by query params
    /// </summary>
    /// <param name="arrivalDate"></param>
    /// <param name="departureDate"></param>
    /// <param name="sorting"></param>
    /// <param name="type"></param>
    /// <param name="active"></param>
    /// <param name="searchTerm"></param>
    /// <param name="currentPage"></param>
    /// <param name="roomsPerPage"></param>
    /// <param name="floorId"></param>
    /// <returns>Task&lt;FreeRoomQueryServiceModel&gt;</returns>
    public Task<FreeRoomQueryServiceModel> All(DateTime? arrivalDate, DateTime? departureDate, RoomSorting sorting = RoomSorting.Newest, 
        string type = "", 
        bool active = true, 
        string searchTerm = "", 
        int currentPage = 1, 
        int roomsPerPage = 1, 
        int floorId = 0);
}