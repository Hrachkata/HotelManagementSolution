using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FloorServices.Contracts;

public interface IFloorServices
{

    /// <summary>
    /// Returns all rooms by query params
    /// </summary>
    /// <param name="sorting"></param>
    /// <param name="type"></param>
    /// <param name="active"></param>
    /// <param name="searchTerm"></param>
    /// <param name="isAvailable"></param>
    /// <param name="currentPage"></param>
    /// <param name="roomsPerPage"></param>
    /// <param name="floorId"></param>
    /// <returns>Task&lt;RoomQueryServiceModel&gt;</returns>
    Task<RoomQueryServiceModel> All(
        RoomSorting sorting = RoomSorting.Newest,
        string type = "",
        bool active = true,
        string searchTerm = "",
        bool isAvailable = true,
        int currentPage = 1,
        int roomsPerPage = 1,
        int floorId = 0);

    /// <summary>
    /// Returns Room types as strings
    /// </summary>
    /// <returns>Task&lt;IEnumerable&lt;string&gt;&gt;</returns>
    Task<IEnumerable<string>> GetRoomTypes();
}