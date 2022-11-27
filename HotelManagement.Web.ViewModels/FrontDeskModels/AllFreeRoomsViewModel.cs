using System.ComponentModel;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.FrontDeskModels
{
    public class AllFreeRoomsViewModel
    {
        public const int RoomsPerPage = 12;

        [DisplayName("Room type")]
        public string RoomType { get; set; }

        [DisplayName("Search by Room Number")]
        public string SearchTerm { get; set; }

        [DisplayName("Available")]
        public bool Available { get; set; } = true;
        public int CurrentPage { get; set; }
        public IEnumerable<string> RoomTypes { get; set; }

        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }

        [DisplayName("Sort Rooms by")]
        public RoomSortingClass.RoomSorting RoomSorting { get; set; }
        public int TotalRoomsCount { get; set; }
        public ICollection<SingleFreeRoomModel> Rooms { get; set; } = new HashSet<SingleFreeRoomModel>();
    }
}