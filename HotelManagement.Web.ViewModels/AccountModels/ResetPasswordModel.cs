﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Web.ViewModels.AccountModels;

/// <summary>
/// Reset password dto
/// </summary>
public class ResetPasswordModel
{
    [Required]
    public string UserId { get; set; }

    [Required]
    public string Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(ConfirmPassword))]
    public string NewPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}