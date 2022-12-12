namespace HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

/// <summary>
/// Room query dto
/// </summary>
public class RoomQueryServiceModel
{
    public int TotalRoomsCount { get; set; }
    /// <summary>
    /// Rooms
    /// </summary>
    public IEnumerable<SingleRoomServiceModel> Rooms { get; set; } = new HashSet<SingleRoomServiceModel>();
}