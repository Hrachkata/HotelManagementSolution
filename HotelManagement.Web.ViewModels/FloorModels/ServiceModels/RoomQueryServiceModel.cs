namespace HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

public class RoomQueryServiceModel
{
    public int TotalRoomsCount { get; set; }

    public IEnumerable<SingleRoomServiceModel> Rooms { get; set; } = new HashSet<SingleRoomServiceModel>();
}