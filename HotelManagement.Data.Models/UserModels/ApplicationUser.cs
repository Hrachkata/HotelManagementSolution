using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels.Contracts;
using HotelManagement.Data.Models.Models;
using Microsoft.AspNetCore.Identity;
using static ModelValidationConstants.AccountConstants.AccountConstants;


namespace HotelManagement.Data.Models.UserModels
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletableModel, IDateInfoModel
    {
        [Required]
        [StringLength(MaxRFIDLength, MinimumLength = MinRFIDLength)]
        public string RFID { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(typeof(decimal), MinSalary, MaxSalary)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }

        [Required]
        [StringLength(MaxEGNLength, MinimumLength = MinEGNLength)]
        public string EGN { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? EditedOn { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartment { get; set; } = new HashSet<EmployeeDepartment>();

        //public ApplicationUser Manager { get; set; }
        //public int? ManagerID { get; set; }

    }
}