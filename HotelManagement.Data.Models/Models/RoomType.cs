using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.RoomTypeConstants.RoomTypeConstants;

namespace HotelManagement.Data.Models.Models;

/// <summary>
/// Room type entity
/// </summary>
public class RoomType : BaseModel<int>
{
    /// <summary>
    /// RoomType name
    /// </summary>
    [Required]
    [StringLength(MaxRoomTypeNameLength, MinimumLength = MinRoomTypeNameLength)]
    public string Type { get; set; }
    

    /// <summary>
    /// Price for type
    /// </summary>
    [Required]
    [Range(typeof(decimal), MinRoomTypePrice, MaxRoomTypePrice)]
    [Column(TypeName = "decimal(18,4)")]
    public decimal PricePerPerson { get; set; }
    
    /// <summary>
    /// One-many relation with rooms
    /// </summary>
    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}