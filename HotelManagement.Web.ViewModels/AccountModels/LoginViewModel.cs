using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.AccountConstants.AccountConstants;
//using static Library.Constants.UserConstants;


namespace HotelManagement.Web.ViewModels.AccountModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        [DisplayName("Username")]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
