using System.ComponentModel;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;
using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.RoomConstants.RoomConstants;

namespace HotelManagement.Web.ViewModels.RoomModels
{
    public class RoomEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Room number")]
        public int RoomNumber { get; set; }

        [Required]
        [Range(MinRoomCapacity, MaxRoomCapacity)]
        public int Capacity { get; set; }

        [Required]
        public int currentRoomTypeId { get; set; }

        public ICollection<RoomTypeDto> RoomTypeDtos { get; set; } = new List<RoomTypeDto>();


        [Required]
        public int RoomTypeDtoId { get; set; }


        [Required]
        public int currentFloorId { get; set; }

        public ICollection<FloorDto> FloorDtos { get; set; } = new HashSet<FloorDto>();

        public int FloorId { get; set; }
    }
}
