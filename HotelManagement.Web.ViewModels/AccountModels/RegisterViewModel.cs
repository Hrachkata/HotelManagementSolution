using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using static ModelValidationConstants.AccountConstants.AccountConstants;


namespace HotelManagement.Web.ViewModels.AccountModels
{
    public class RegisterViewModel : AccountBaseViewModel
    {
        public Guid Id { get; set; }
        
        [Required]
        [Range(typeof(decimal), MinSalary, MaxSalary)]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(MaxEGNLength, MinimumLength = MinEGNLength)]
        public string EGN { get; set; }

        [Required]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxRFIDLength, MinimumLength = MinRFIDLength)]
        public string RFID { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<DepartmentDto>? Departments { get; set; } = new HashSet<DepartmentDto>();

        [Required]
        public int DepartmentId { get; set; }
    }
}
