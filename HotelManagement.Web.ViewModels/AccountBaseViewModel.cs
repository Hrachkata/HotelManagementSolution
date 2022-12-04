using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static ModelValidationConstants.AccountConstants.AccountConstants;
namespace HotelManagement.Web.ViewModels;

public class AccountBaseViewModel
{
    [Required]
    [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
    [DisplayName("Username")]
    public string UserName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    public string Email { get; set; } = null!;

    [DisplayName("First Name")]
    [Required]
    [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
    public string FirstName { get; set; }


    [DisplayName("Middle Name")]
    [Required]
    [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
    public string MiddleName { get; set; }


    [DisplayName("Last Name")]
    [Required]
    [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
    public string LastName { get; set; }
}