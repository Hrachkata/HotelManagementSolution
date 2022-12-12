using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedRoomTypes
{
    /// <summary>
    /// Returns roomtype entities
    /// </summary>
    /// <returns>ICollection&lt;RoomType&gt;</returns>
    ICollection<RoomType> SeedRoomTypesWithoutRooms();
}