using System.ComponentModel.DataAnnotations;

//using static Library.Constants.UserConstants;


namespace HotelManagement.Web.ViewModels.UserModels
{
    public class LoginViewModel
    {
        [Required]
        //[StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
