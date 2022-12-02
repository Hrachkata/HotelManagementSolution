using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FrontDeskServices.Contracts;

public interface IFrontDeskServices
{


    public Task<FreeRoomQueryServiceModel> All(DateTime? arrivalDate, DateTime? departureDate, RoomSorting sorting = RoomSorting.Newest, 
        string type = "", 
        bool active = true, 
        string searchTerm = "", 
        int currentPage = 1, 
        int roomsPerPage = 1, 
        int floorId = 0);
}