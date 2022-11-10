using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Web.ViewModels.ManageEmployeesModels
{
    public class EmployeeEditViewModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }
        public string PhoneNumber{ get; set; }
        public string RFID { get; set; }
        public ICollection<DepartmentDto> DepartmentsOfEmployee { get; set; }
        public int DepartmentOfEmployeeId { get; set; }

        public ICollection<DepartmentDto> DepartmentsEmployeeDoesntHave { get; set; }
        public int DepartmentEmployeeDoesntHaveId { get; set; }
        
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
        public string EGN { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? EditedOn { get; set; }
    }
}
