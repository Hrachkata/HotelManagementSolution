using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedUserData
{
    /// <summary>
    /// Returns user entities but one is with the given id
    /// </summary>
    /// <param name="adminGuid"></param>
    /// <returns>ICollection&lt;ApplicationUser&gt;</returns>
    ICollection<ApplicationUser> SeedUsers(Guid adminGuid);

    /// <summary>
    /// Returns role entities but one is with the given id
    /// </summary>
    /// <param name="ownerGuid"></param>
    /// <returns>ICollection&lt;ApplicationUserRole&gt;</returns>
    ICollection<ApplicationUserRole> SeedRoles(Guid ownerGuid, Guid adminGuid, Guid HRguid, Guid directorGuid);

    /// <summary>
    /// Returns rolename entities
    /// </summary>
    /// <returns>ICollection&lt;RoleName&gt;  </returns>
    ICollection<RoleName> SeedRoleNameItems();

    /// <summary>
    /// Returns userRole entities but with given ids
    /// </summary>
    /// <param name="adminGuid"></param>
    /// <param name="ownerGuid"></param>
    /// <returns>ICollection&lt;IdentityUserRole&lt;Guid&gt;&gt;</returns>
    ICollection<IdentityUserRole<Guid>> SeedUserRoles(Guid adminGuid, Guid ownerGuid, Guid adminRoleGuid, Guid HRRoleGuid, Guid directorRoleGuid);
}