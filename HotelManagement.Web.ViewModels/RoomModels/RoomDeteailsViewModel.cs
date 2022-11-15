namespace HotelManagement.Web.ViewModels.RoomModels;

public class RoomDeteailsViewModel
{
    public int RoomId { get; set; }
    public bool IsActive { get; set; }
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsCleaned { get; set; }
    public bool IsOutOfService { get; set; }
}