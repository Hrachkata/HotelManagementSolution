using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Web.ViewModels.UserModels;

public class ForgotPasswordViewModel
{

    [Required, EmailAddress, Display(Name = "Registered Email Address")]
    public string Email { get; set; }

    public bool EmailSent { get; set; }
}