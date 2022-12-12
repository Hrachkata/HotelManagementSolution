using System.ComponentModel;
using HotelManagement.Data.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.ReservationConstants.ReservationConstants;
using static ModelValidationConstants.RoomTypeConstants.RoomTypeConstants;


namespace HotelManagement.Web.ViewModels.BookingModels;

/// <summary>
/// Reservation dto
/// </summary>
public class BookingModel
{
    public string RoomType { get; set; }
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsCleaned { get; set; }
    public bool IsOutOfService { get; set; }

    [Required]
    [Range(typeof(decimal), MinRoomTypePrice, MaxRoomTypePrice)]
    public decimal PricePerPerson { get; set; }

    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    [DisplayName("First Name")]
    public string GuestFirstName { get; set; }

    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    [DisplayName("Last Name")]
    public string GuestLastName { get; set; }

    [Required]
    [StringLength(MaxNationalityLength, MinimumLength = MinNationalityLength)]
    [DisplayName("Nationality")]
    public string GuestNationality { get; set; }

    [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
    [DisplayName("Phone number")]
    public string? GuestPhoneNumber { get; set; }

    [Required]
    [StringLength(MaxAddressLength, MinimumLength = MinAddressLength)]
    public string Address { get; set; }

    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    [EmailAddress]
    [Required]
    [DisplayName("Email")]
    public string GuestEmail { get; set; }


    [DisplayName("Total price")]
    public decimal? totalPrice { get; set; }

    [Required]
    [DisplayName("Number of guests")]
    public int NumberOfGuests { get; set; }

    [DisplayName("Children")]
    public int? NumberOfChildren { get; set; }
    
    [Required]
    public DateTime? ArrivalDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public bool? LateDeparture { get; set; }
    public int RoomId { get; set; }

}