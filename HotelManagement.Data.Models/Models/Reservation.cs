using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using HotelManagement.Data.Models.UserModels;
using static ModelValidationConstants.ReservationConstants.ReservationConstants;

namespace HotelManagement.Data.Models.Models;

/// <summary>
/// This is the Reservation entity, it has a one-many connection with rooms.
/// </summary>

public class Reservation : BaseModel<string>
{

    /// <summary>
    /// Guest first name
    /// </summary>
    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    public string GuestFirstName { get; set; }


    /// <summary>
    /// Guest last name
    /// </summary>
    [Required]
    [StringLength(MaxGuestNameLength, MinimumLength = MinGuestNameLength)]
    public string GuestLastName { get; set; }


    /// <summary>
    /// Guest nationality
    /// </summary>
    [Required]
    [StringLength(MaxNationalityLength, MinimumLength = MinNationalityLength)]
    public string GuestNationality { get; set; }


    /// <summary>
    /// Guest phone number string
    /// </summary>
    [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
    public string? GuestPhoneNumber { get; set; }


    /// <summary>
    /// Guest address
    /// </summary>
    [Required]
    [StringLength(MaxAddressLength, MinimumLength = MinAddressLength)]
    public string Address { get; set; }


    /// <summary>
    /// Guest email
    /// </summary>
    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    [EmailAddress]
    [Required]
    public string GuestEmail { get; set; }


    /// <summary>
    /// Total price of reservation 
    /// </summary>
    [Column(TypeName = "decimal(18,4)")]
    public decimal? totalPrice { get; set; }


    /// <summary>
    /// Number of guests
    /// </summary>
    [Required]
    [Range(MinGuestNumber, MaxGuestNumber)]
    public int NumberOfGuests { get; set; }
    
    /// <summary>
    /// Number of children
    /// </summary>
    public int? NumberOfChildren { get; set; }


    /// <summary>
    /// Res arrival date
    /// </summary>
    [Required]
    public DateTime ArrivalDate { get; set; }
    
    /// <summary>
    /// Res departure date
    /// </summary>
    public DateTime DepartureDate { get; set; }

    /// <summary>
    /// Check in flag
    /// </summary>
    public bool? CheckedIn { get; set; }
    
    /// <summary>
    /// Reserved room one-one connection
    /// </summary>
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }

    //public Guid GuestId { get; set; }

    //[ForeignKey(nameof(GuestId))]
    //public Guest Guest { get; set; }
}