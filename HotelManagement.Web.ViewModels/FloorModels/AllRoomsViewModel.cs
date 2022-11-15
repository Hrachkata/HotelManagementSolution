using System.ComponentModel;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.FloorModels
{
    public class AllRoomsViewModel
    {
        public const int RoomsPerPage = 12;

        [DisplayName("Room type")]
        public string RoomType { get; set; }

        [DisplayName("Search by Room Number")]
        public string SearchTerm { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; } = true;
        public int CurrentPage { get; set; }
        public IEnumerable<string> RoomTypes { get; set; }

        [DisplayName("Free, clean, in service")]
        public bool IsAvailable { get; set; } = true;

        [DisplayName("Sort Rooms by")]
        public RoomSortingClass.RoomSorting RoomSorting { get; set; }
        public int TotalRoomsCount { get; set; }

        public ICollection<SingleRoomServiceModel> Rooms { get; set; } = new HashSet<SingleRoomServiceModel>();

    }
}
