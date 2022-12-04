using System.ComponentModel.DataAnnotations;
using System.Reflection;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.DepartmentConstants.DepartmentConstants;


namespace HotelManagement.Data.Models.Models
{
    public class Department : BaseModel<int>
    {
        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; }

        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }
        public int? EmployeeCount { get; set; }
        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();
        public ICollection<EmployeeDepartment> EmployeeDepartment { get; set; } = new HashSet<EmployeeDepartment>();
    }
}
