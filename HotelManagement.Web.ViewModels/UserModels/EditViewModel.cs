using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Web.ViewModels.UserModels;

public class EditViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    //[StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
    public string UserName { get; set; } = null!;

    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    //[StringLength (MaxEmailLength, MinimumLength = MinEmailLength)]
    public string Email { get; set; } = null!;

    [Required]
    //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = null!;

    [Compare(nameof(NewPasswordConfirm))]
    //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Compare(nameof(NewPassword))]
    //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
    [DataType(DataType.Password)]
    public string NewPasswordConfirm { get; set; } = null!;
    public DateTime EditedOn { get; set; }
}