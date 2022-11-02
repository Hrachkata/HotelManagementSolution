using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Web.ViewModels.UserModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } = null!;
        public IEnumerable<string> DepartmentNames { get; set; } = new List<string>();
        public string RFID { get; set; }
        public string RoleName { get; set; }

    }
}
