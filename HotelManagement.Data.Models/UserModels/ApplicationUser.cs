using HotelManagement.Data.Common.CommonModels.Contracts;
using HotelManagement.Data.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Models.UserModels
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletableModel, IDateInfoModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartment { get; set; } = new HashSet<EmployeeDepartment>();
        //public int? ManagerID { get; set; }
        //public ApplicationUser Manager { get; set; }

    }
}
