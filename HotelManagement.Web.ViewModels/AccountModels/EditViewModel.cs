using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Web.ViewModels.UserModels;

public class EditViewModel
{
    public Guid Id { get; set; }

    [DisplayName("First Name")]
    [Required]
    public string FirstName { get; set; }

    [DisplayName("Middle Name")]
    [Required]
    public string MiddleName { get; set; }

    [DisplayName("Last Name")]
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }
    
    public string? UserName { get; set; }
    
    public string? Email { get; set; }

    public string? EGN { get; set; }

    [Required]
    //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }
    
    public DateTime EditedOn { get; set; }
}