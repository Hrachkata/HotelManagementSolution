using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.FloorConstants.FloorConstants;

namespace HotelManagement.Data.Models.Models
{
    public class Floor : BaseModel<int>
    {
        [Required]
        [Range(MinFloor, MaxFloor)]
        public int FloorNumber { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();


    }
}
