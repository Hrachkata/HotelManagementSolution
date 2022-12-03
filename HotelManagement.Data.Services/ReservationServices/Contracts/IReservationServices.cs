using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using static HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels.ReservationSortingClass;

namespace HotelManagement.Data.Services.ReservationServices.Contracts;

public interface IReservationServices
{
    public Task<ReservationQueryServiceModel> All(DateTime? arrivalDateFrom, DateTime? arrivalDateTo, ReservationSorting sorting = ReservationSorting.Newest,
        string searchTerm = "",
        int currentPage = 1,
        int roomsPerPage = 1);

    public Task<bool> CheckIn(string reservationId, int roomId);

    public Task<bool> CheckOut(string reservationId, int roomId);

    public Task<bool> PrintFolioPaid(string reservationId);
}