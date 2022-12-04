using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.RoomTypeConstants.RoomTypeConstants;

namespace HotelManagement.Data.Models.Models;

public class RoomType : BaseModel<int>
{
    [Required]
    [StringLength(MaxRoomTypeNameLength, MinimumLength = MinRoomTypeNameLength)]
    public string Type { get; set; }
    
    [Required]
    [Range(typeof(decimal), MinRoomTypePrice, MaxRoomTypePrice)]
    [Column(TypeName = "decimal(18,4)")]
    public decimal PricePerPerson { get; set; }
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}