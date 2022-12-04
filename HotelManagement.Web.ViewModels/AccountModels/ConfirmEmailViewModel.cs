namespace HotelManagement.Web.ViewModels.UserModels;

public class ConfirmEmailViewModel
{
    public string Email { get; set; }

    public bool IsConfirmed { get; set; }

    public bool EmailSent { get; set; }

    public bool EmailVerified { get; set; }
}