using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models
{
    public class Floor : BaseModel<int>
    {
        public int FloorNumber { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();


    }
}
