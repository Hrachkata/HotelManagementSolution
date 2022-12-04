using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using HotelManagement.Data.Models.UserModels;
using static ModelValidationConstants.ReservationConstants.ReservationConstants;

namespace HotelManagement.Data.Models.Models;

/// <summary>
/// This is the Reservation model, it has a one-many connection with rooms.
/// </summary>

public class Reservation : BaseModel<string>
{
    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    public string GuestFirstName { get; set; }

    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    public string GuestLastName { get; set; }

    [Required]
    [StringLength(MaxNationalityLength, MinimumLength = MinNationalityLength)]
    public string GuestNationality { get; set; }

    [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
    public string? GuestPhoneNumber { get; set; }

    [Required]
    [StringLength(MaxAddressLength, MinimumLength = MinAddressLength)]
    public string Address { get; set; }

    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    [EmailAddress]
    [Required]
    public string GuestEmail { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal? totalPrice { get; set; }

    [Required]
    [Range(MinGuestNumber, MaxGuestNumber)]
    public int NumberOfGuests { get; set; }
    public int? NumberOfChildren { get; set; }

    [Required]
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }

    public bool? CheckedIn { get; set; }
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }

    //public Guid GuestId { get; set; }

    //[ForeignKey(nameof(GuestId))]
    //public Guest Guest { get; set; }
}