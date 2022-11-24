using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FrontDeskServices.Contracts;

public interface IFrontDeskServices
{
    public Task<ReservationsViewModel> GenerateReservationViewModelAsync();

    public Task<FreeRoomQueryServiceModel> All(RoomSorting sorting = RoomSorting.Newest, string type = "", bool active = true, string searchTerm = "", int currentPage = 1, int roomsPerPage = 1, int floorId = 0);
}