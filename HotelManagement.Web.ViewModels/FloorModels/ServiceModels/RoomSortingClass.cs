namespace HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

/// <summary>
/// Room sorting enum
/// </summary>
public class RoomSortingClass
{
    public enum RoomSorting
    {
        Newest = 0,
        Oldest = 1,
        ByRoomNumber = 2,
        ByRoomNumberDescending = 3
    }
}