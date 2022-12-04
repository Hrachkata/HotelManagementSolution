using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.RoomConstants.RoomConstants;

namespace HotelManagement.Data.Models.Models
{
    
    public class Room : BaseModel<int>
    {
        public int RoomTypeId { get; set; }
        [ForeignKey(nameof(RoomTypeId))]
        public RoomType RoomType { get; set; }

        [Required]
        [Range(MaxRoomNumber, MinRoomNumber)]
        public int RoomNumber { get; set; }

        [Required]
        [Range(MinRoomCapacity, MaxRoomCapacity)]
        public int Capacity { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsCleaned { get; set; }
        public bool IsOutOfService { get; set; }

        public int FloorId { get; set; }
        [ForeignKey(nameof(FloorId))]
        public Floor Floor { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
