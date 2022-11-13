using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models;

public class RoomType : BaseModel<int>
{
    public string Type { get; set; }
    public decimal PricePerPerson { get; set; }
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}