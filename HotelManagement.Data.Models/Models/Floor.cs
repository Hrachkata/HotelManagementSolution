using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.FloorConstants.FloorConstants;

namespace HotelManagement.Data.Models.Models
{
    /// <summary>
    /// Floor entity
    /// </summary>
    public class Floor : BaseModel<int>
    {

        /// <summary>
        /// Floor entity
        /// </summary>
        [Required]
        [Range(MinFloor, MaxFloor)]
        public int FloorNumber { get; set; }

        /// <summary>
        /// Room ICollection one-many relation with room entity
        /// </summary>
        public ICollection<Room> Rooms { get; set; } = new List<Room>();


    }
}
