using HotelManagement.Data.Models.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models.Models
{
    public class RoleDepartment
    {
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]

        public Department Department { get; set; }

        public int RoleNameId { get; set; }
        [ForeignKey(nameof(RoleNameId))]
        public RoleName? RoleName { get; set; }
    }
}
