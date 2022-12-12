using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.RoomConstants.RoomConstants;

namespace HotelManagement.Data.Models.Models
{
    /// <summary>
    /// Room entity
    /// </summary>
    
    public class Room : BaseModel<int>
    {
        /// <summary>
        /// Many-one relation with room type entity
        /// </summary>
        public int RoomTypeId { get; set; }
        [ForeignKey(nameof(RoomTypeId))]
        public RoomType RoomType { get; set; }

        /// <summary>
        /// Room number
        /// </summary>
        [Required]
        [Range(MaxRoomNumber, MinRoomNumber)]
        public int RoomNumber { get; set; }


        /// <summary>
        /// Capacity
        /// </summary>
        [Required]
        [Range(MinRoomCapacity, MaxRoomCapacity)]
        public int Capacity { get; set; }
        /// <summary>
        /// IsOccupied flag
        /// </summary>
        public bool IsOccupied { get; set; }
        /// <summary>
        /// IsCleaned flag
        /// </summary>
        public bool IsCleaned { get; set; }
        
        /// <summary>
        /// IsOutOfService flag
        /// </summary>
        public bool IsOutOfService { get; set; }


        /// <summary>
        /// Many-one relation with floor entity
        /// </summary>
        public int FloorId { get; set; }
        [ForeignKey(nameof(FloorId))]
        public Floor Floor { get; set; }

        /// <summary>
        /// One-many relation with reservation entity
        /// </summary>
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
