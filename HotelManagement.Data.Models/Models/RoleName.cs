using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models.Models
{
    public class RoleName
    {
        [Key]
        public int Id { get; set; }

        public string NameOfRole { get; set; }

        public ICollection<RoleDepartment> RoleDepartment { get; set; } = new HashSet<RoleDepartment>();
    }
}
