﻿using System.ComponentModel.DataAnnotations;
using static ModelValidationConstants.AccountConstants.AccountConstants;
namespace HotelManagement.Web.ViewModels.AccountModels;

/// <summary>
/// Forgot password dto
/// </summary>
public class ForgotPasswordViewModel
{


    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
    [Required, EmailAddress, Display(Name = "Registered Email Address")]
    public string Email { get; set; }

    public bool EmailSent { get; set; }
}