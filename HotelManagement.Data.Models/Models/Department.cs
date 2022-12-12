using System.ComponentModel.DataAnnotations;
using System.Reflection;
using HotelManagement.Data.Common.CommonModels;
using static ModelValidationConstants.DepartmentConstants.DepartmentConstants;


namespace HotelManagement.Data.Models.Models
{
    /// <summary>
    /// Department entity
    /// </summary>
    public class Department : BaseModel<int>
    {

        /// <summary>
        /// Department name
        /// </summary>
        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// Department description
        /// </summary>

        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }
        public int? EmployeeCount { get; set; }

        /// <summary>
        /// Many-many connection rolenames-departments
        /// </summary>
        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();

        /// <summary>
        /// Many-many connection employees-departments
        /// </summary>
        public ICollection<EmployeeDepartment> EmployeeDepartment { get; set; } = new HashSet<EmployeeDepartment>();
    }
}
