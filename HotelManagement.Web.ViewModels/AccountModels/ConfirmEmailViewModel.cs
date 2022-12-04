namespace HotelManagement.Web.ViewModels.AccountModels;

using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.AccountConstants.AccountConstants;
public class ConfirmEmailViewModel
{

    [Required]
    [EmailAddress]
    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    public string Email { get; set; }

    public bool IsConfirmed { get; set; }

    public bool EmailSent { get; set; }

    public bool EmailVerified { get; set; }
}