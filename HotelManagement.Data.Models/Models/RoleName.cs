using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.RoleNameConstants.RoleNameConstants;
using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models
{

    /// <summary>
    /// Role name entity used to manage rights
    /// </summary>
    public class RoleName : BaseModel<int>
    {
        /// <summary>
        /// Name of role
        /// </summary>
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string NameOfRole { get; set; }


        /// <summary>
        /// Many-many relation with departments
        /// </summary>
        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();
    }
}
