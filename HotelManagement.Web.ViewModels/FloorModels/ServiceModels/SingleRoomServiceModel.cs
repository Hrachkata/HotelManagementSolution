namespace HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

/// <summary>
/// Single room dto
/// </summary>
public class SingleRoomServiceModel
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