using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedFloors
{
    /// <summary>
    /// Returns floor entities
    /// </summary>
    /// <returns>ICollection&lt;Floor&gt;</returns>
    ICollection<Floor> SeedFloorsWithoutRooms();
}