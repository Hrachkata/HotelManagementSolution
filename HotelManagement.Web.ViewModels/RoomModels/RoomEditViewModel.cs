using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;


namespace HotelManagement.Web.ViewModels.RoomModels
{
    public class RoomEditViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }

        public int currentRoomTypeId { get; set; }

        public ICollection<RoomTypeDto> RoomTypeDtos { get; set; } = new List<RoomTypeDto>();

        public int RoomTypeDtoId { get; set; }

        public int currentFloorId { get; set; }

        public ICollection<FloorDto> FloorDtos { get; set; } = new HashSet<FloorDto>();

        public int FloorId { get; set; }
    }
}
