using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

public class FrontDeskRoomQueryServiceModel
{
    public int TotalRoomsCount { get; set; }

    public IEnumerable<SingleFrontDeskRoomModel> Rooms { get; set; } = new HashSet<SingleFrontDeskRoomModel>();
}


