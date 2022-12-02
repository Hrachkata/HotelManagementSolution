using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Models.Models;

public class Guest : BaseModel<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool IsLoyalGuest { get; set; } = false;

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public bool IsChild { get; set; }


}