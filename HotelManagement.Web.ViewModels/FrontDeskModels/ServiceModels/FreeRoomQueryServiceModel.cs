using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

public class FreeRoomQueryServiceModel
{
    public int TotalRoomsCount { get; set; }

    public IEnumerable<SingleFreeRoomModel> Rooms { get; set; } = new HashSet<SingleFreeRoomModel>();
}