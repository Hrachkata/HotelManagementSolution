using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using static ModelValidationConstants.AccountConstants.AccountConstants;

namespace HotelManagement.Web.ViewModels.ManageEmployeesModels
{
    /// <summary>
    /// Employee edit dto
    /// </summary>
    public class EmployeeEditViewModel : AccountBaseViewModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }

        [Required]
        [StringLength(MaxPhoneLength, MinimumLength = MinPhoneLength)]
        [DisplayName("Phone number")]
        public string PhoneNumber{ get; set; }

        [Required]
        [StringLength(MaxRFIDLength, MinimumLength = MinRFIDLength)]
        public string RFID { get; set; }
        public ICollection<DepartmentDto> DepartmentsOfEmployee { get; set; } = new List<DepartmentDto>();

        [DisplayName("remove department")]
        public int DepartmentOfEmployeeId { get; set; }

        public ICollection<DepartmentDto> DepartmentsEmployeeDoesntHave { get; set; } = new List<DepartmentDto>();
        [DisplayName("add department")]
        public int DepartmentEmployeeDoesntHaveId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(typeof(decimal), MinSalary, MaxSalary)]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(MaxEGNLength, MinimumLength = MinEGNLength)]
        public string EGN { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? EditedOn { get; set; }
    }
}
