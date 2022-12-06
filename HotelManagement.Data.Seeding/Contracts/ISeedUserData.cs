using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedUserData
{
    ICollection<ApplicationUser> SeedUsers(Guid adminGuid);

    ICollection<ApplicationUserRole> SeedRoles(Guid ownerGuid);

    ICollection<RoleName> SeedRoleNameItems();

    ICollection<IdentityUserRole<Guid>> SeedUserRoles(Guid adminGuid, Guid ownerGuid);
}