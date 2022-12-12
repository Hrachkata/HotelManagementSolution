using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using System.ComponentModel;
using HotelManagement.Data.Models.Models;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.ReservationsModels;

/// <summary>
/// All reservations view dto
/// </summary>
public class AllReservationsModel
{
    public const int ReservationsPerPage = 12;

    [DisplayName("Room type")]
    public string RoomType { get; set; }

    [DisplayName("Search")]
    public string SearchTerm { get; set; }
    public int CurrentPage { get; set; }
    public DateTime? ArrivalDateFrom { get; set; }
    public DateTime? ArrivalDateTo { get; set; }

    [DisplayName("Sort reservations by")]
    public ReservationSortingClass.ReservationSorting ReservationSorting { get; set; }
    public int TotalReservationsCount { get; set; }

    public ICollection<SingleReservationViewModel> Reservations { get; set; }
}