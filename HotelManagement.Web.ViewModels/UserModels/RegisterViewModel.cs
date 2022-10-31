﻿using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;

//using static Library.Constants.UserConstants;

namespace HotelManagement.Web.ViewModels.UserModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        [Required]
        //[StringLength(MaxUserNameLength, MinimumLength = MinUserNameLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        //[StringLength (MaxEmailLength, MinimumLength = MinEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        //[StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        public string RFID { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<ApplicationUserRole>? Roles{ get; set; }

        public Guid RoleId { get; set; }

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}