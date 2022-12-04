using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Web.ViewModels.FloorModelForVisualization;
using static ModelValidationConstants.FloorConstants.FloorConstants;
public class FloorViewModel
{

    [Required]
    [Range(MinFloor, MaxFloor)]
    public int FloorNumber { get; set; }

    public int Id { get; set; }

    public int FreeRooms { get; set; }
}