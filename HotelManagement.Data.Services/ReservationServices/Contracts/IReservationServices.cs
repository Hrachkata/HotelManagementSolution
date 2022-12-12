using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using static HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels.ReservationSortingClass;

namespace HotelManagement.Data.Services.ReservationServices.Contracts;

public interface IReservationServices
{
    /// <summary>
    /// Returns all reservations corresponding to params
    /// </summary>
    /// <param name="arrivalDateFrom"></param>
    /// <param name="arrivalDateTo"></param>
    /// <param name="sorting"></param>
    /// <param name="searchTerm"></param>
    /// <param name="currentPage"></param>
    /// <param name="roomsPerPage"></param>
    /// <returns>Task&lt;ReservationQueryServiceModel&gt;</returns>
    public Task<ReservationQueryServiceModel> All(DateTime? arrivalDateFrom, DateTime? arrivalDateTo, ReservationSorting sorting = ReservationSorting.Newest,
        string searchTerm = "",
        int currentPage = 1,
        int roomsPerPage = 1);


    /// <summary>
    /// Checks reservation in
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="roomId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> CheckIn(string reservationId, int roomId);

    /// <summary>
    /// Checks reservation out
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="roomId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> CheckOut(string reservationId, int roomId);

    /// <summary>
    /// Cancels reservations
    /// </summary>
    /// <param name="reservationId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> CancelReservation(string reservationId);

    /// <summary>
    /// When reservation is paid for, and sets total to 0
    /// </summary>
    /// <param name="reservationId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> PrintFolioPaid(string reservationId);
}