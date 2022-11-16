namespace HotelManagement.Web.ViewModels.RoomModels;

public class RoomDetailsViewModel
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsCleaned { get; set; }
    public bool IsOutOfService { get; set; }

    public int RoomTypeId { get; set; }

    public int NumberOfReservations { get; set; } = 0;

    public DateTime CreatedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public decimal PricePerPerson { get; set; }

    public decimal PriceOnFullCapacity { get; set; }
}