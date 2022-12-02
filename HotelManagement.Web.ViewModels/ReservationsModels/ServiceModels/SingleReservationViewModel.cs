using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;

public class SingleReservationViewModel
{
    public string Id { get; set; }

    [Required]
    public string GuestFirstName { get; set; }

    [Required]
    public string GuestLastName { get; set; }

    [Required]
    public string GuestNationality { get; set; }

    public string? GuestPhoneNumber { get; set; }

    [Required]

    public string Address { get; set; }

    [EmailAddress]
    [Required]
    public string GuestEmail { get; set; }

    public decimal? totalPrice { get; set; }

    [Required]
    public int NumberOfGuests { get; set; }
    public int? NumberOfChildren { get; set; }

    public bool? CheckedIn { get; set; }

    [Required]
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public bool? LateDeparture { get; set; }
    public int RoomId { get; set; }
    public int RoomNumber { get; set; }

    public bool IsOccupied { get; set; }

}