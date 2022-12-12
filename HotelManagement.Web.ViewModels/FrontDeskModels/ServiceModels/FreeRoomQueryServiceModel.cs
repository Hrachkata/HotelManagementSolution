namespace HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

/// <summary>
/// Free rooms dto
/// </summary>
public class FreeRoomQueryServiceModel
{
    public int TotalRoomsCount { get; set; }
    /// <summary>
    /// Rooms
    /// </summary>

    public IEnumerable<SingleFreeRoomModel> Rooms { get; set; } = new HashSet<SingleFreeRoomModel>();
}