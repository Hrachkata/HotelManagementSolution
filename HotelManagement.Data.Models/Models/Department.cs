using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Common.CommonModels;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Data.Models.Models
{
    public class Department : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? EmployeeCount { get; set; }
        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();
        public ICollection<EmployeeDepartment> EmployeeDepartment { get; set; } = new HashSet<EmployeeDepartment>();
    }
}
