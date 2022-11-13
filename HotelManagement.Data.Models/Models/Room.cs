using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models
{
    /// <summary>
    /// This is the room base model which uses the ID as room number.
    /// </summary>
    public class Room : BaseModel<int>
    {
        public int RoomTypeId { get; set; }
        [ForeignKey(nameof(RoomTypeId))]
        public RoomType RoomType { get; set; }

        public int RoomNumber { get; set; }
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
