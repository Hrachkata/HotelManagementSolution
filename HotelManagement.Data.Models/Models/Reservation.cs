using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Data.Models.Models;

/// <summary>
/// This is the Reservation model, it has a one-many connection with rooms.
/// </summary>

public class Reservation : BaseModel<Guid>
{
    [Required]
    public string GuestFirstName { get; set; }

    [Required]
    public string GuestLastName { get; set; }

    [Required]
    public string GuestNationality { get; set; }

    public string? GuestPhoneNumber { get; set; }

    [EmailAddress]
    [Required]
    public string GuestEmail { get; set; }
    
    [Required]
    public int NumberOfGuests { get; set; }

    [Required]
    public DateTime ArrivalDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public bool? LateDeparture { get; set; }
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
}