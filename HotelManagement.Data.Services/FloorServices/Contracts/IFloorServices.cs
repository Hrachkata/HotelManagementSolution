using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FloorServices.Contracts;

public interface IFloorServices
{
    Task<RoomQueryServiceModel> All(
        RoomSorting sorting = RoomSorting.Newest,
        string type = "",
        bool active = true,
        string searchTerm = "",
        bool isAvailable = true,
        int currentPage = 1,
        int roomsPerPage = 1,
        int floorId = 0);


    Task<IEnumerable<string>> GetRoomTypes();
}