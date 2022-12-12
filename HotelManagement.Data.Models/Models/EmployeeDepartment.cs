using System.ComponentModel.DataAnnotations.Schema;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Data.Models.Models
{
    public class EmployeeDepartment
    {
        /// <summary>
        /// Many-many connection user and department entities
        /// </summary>
        public Guid ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser{ get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

    }
}
