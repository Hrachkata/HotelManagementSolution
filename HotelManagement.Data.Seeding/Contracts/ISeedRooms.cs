using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedRooms
{
    /// <summary>
    /// Returns room entities
    /// </summary>
    /// <returns>  ICollection&lt;Room&gt;</returns>
    ICollection<Room> SeedRoomsOnEveryFloor();
}