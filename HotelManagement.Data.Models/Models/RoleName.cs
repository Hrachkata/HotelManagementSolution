using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.RoleNameConstants.RoleNameConstants;
using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models
{
    public class RoleName : BaseModel<int>
    {
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string NameOfRole { get; set; }

        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();
    }
}
