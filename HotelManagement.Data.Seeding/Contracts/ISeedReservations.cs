using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedReservations 
{
    /// <summary>
    /// Returns reservation entities
    /// </summary>
    /// <returns>ICollection&lt;Reservation&gt;</returns>
    ICollection<Reservation> SeedReservationModels();

}