using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Models.UserModels;
/// <summary>
/// Role entity
/// </summary>
public class ApplicationUserRole : IdentityRole<Guid>
{
    public ApplicationUserRole()
    {
        
    }
}