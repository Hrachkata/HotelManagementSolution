using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Models.UserModels;

public class ApplicationUserRole : IdentityRole<Guid>
{
    public ApplicationUserRole()
    {
    
    }
}