using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

namespace HotelManagement.Web.ViewModels.ManageEmployeesModels
{
    public class AllEmployeesViewModel
    {
        public const int EmployeesPerPage = 9;

        [DisplayName("Department name")]
        public string DepartmentName { get; set; }

        [DisplayName("Search by employee Name")]
        public string SearchTerm { get; set; }

        [DisplayName("Show active employees")]
        public bool Active { get; set; } = true;
        public int CurrentPage { get; set; }

        [DisplayName("Sort employees by")]
        public EmployeeSortingClass.EmployeeSorting EmployeeSorting { get; set; }
        public int TotalEmployeesCount { get; set; }

        public IEnumerable<string> Departments { get; set; }

        public IEnumerable<SingleEmployeeServiceModel> Employees { get; set; } = new HashSet<SingleEmployeeServiceModel>();
    }
}
