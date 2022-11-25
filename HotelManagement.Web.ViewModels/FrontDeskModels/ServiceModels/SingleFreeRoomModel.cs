using HotelManagement.Data.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

public class SingleFreeRoomModel
{
    public int RoomId { get; set; }
    public string RoomType { get; set; }
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsCleaned { get; set; }
    public bool IsOutOfService { get; set; }
    public decimal PricePerPerson { get; set; }
    public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

    public DateTime? ArrivalDate { get; set; }

    public DateTime? DepartureDate { get; set; }
}