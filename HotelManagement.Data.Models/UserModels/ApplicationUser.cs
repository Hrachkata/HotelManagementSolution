using HotelManagement.Data.Common.CommonModels.Contracts;
using HotelManagement.Data.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Models.UserModels
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletableModel, IDateInfoModel
    {
        public string RFID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
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