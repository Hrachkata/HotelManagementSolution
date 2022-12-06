using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedRooms
{
    ICollection<Room> SeedRoomsOnEveryFloor();
}