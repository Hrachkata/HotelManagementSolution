using HotelManagement.Data.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Web.ViewModels.BookingModels;

public class BookingModel
{
    public string RoomType { get; set; }
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsCleaned { get; set; }
    public bool IsOutOfService { get; set; }
    public decimal PricePerPerson { get; set; }

    [Required]
    public string GuestFirstName { get; set; }

    [Required]
    public string GuestLastName { get; set; }

    [Required]
    public string GuestNationality { get; set; }

    [Required]

    public string Address { get; set; }
    public string? GuestPhoneNumber { get; set; }

    [EmailAddress]
    [Required]
    public string GuestEmail { get; set; }

    [Required]
    public int NumberOfGuests { get; set; }

    public int? NumberOfChildren { get; set; }
    
    public decimal totalPrice { get; set; }

    [Required]
    public DateTime? ArrivalDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public bool? LateDeparture { get; set; }
    public int RoomId { get; set; }

}