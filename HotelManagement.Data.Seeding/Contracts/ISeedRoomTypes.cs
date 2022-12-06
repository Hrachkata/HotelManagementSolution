using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedRoomTypes
{
    ICollection<RoomType> SeedRoomTypesWithoutRooms();
}