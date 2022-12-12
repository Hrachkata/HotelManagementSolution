
using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.AccountConstants.AccountConstants;

namespace HotelManagement.Web.ViewModels.AccountModels;

/// <summary>
/// Edit model dto
/// </summary>
public class EditViewModel : AccountBaseViewModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
    public string PhoneNumber { get; set; }
    
    [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
    public string? UserName { get; set; }

    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    public string? Email { get; set; }


    [StringLength(MaxEGNLength, MinimumLength = MinEGNLength)]
    public string? EGN { get; set; }

    [Required]
    [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }
    
    public DateTime EditedOn { get; set; }
}