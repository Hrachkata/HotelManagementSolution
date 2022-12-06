using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedFloors
{
    ICollection<Floor> SeedFloorsWithoutRooms();
}