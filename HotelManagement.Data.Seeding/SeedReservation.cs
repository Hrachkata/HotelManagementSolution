using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedReservations : ISeedReservations
{

    public ICollection<Reservation> SeedReservationModels() 
    {
        var models = new List<Reservation>()
                {
                    new Reservation
                    {
                        Id = "R"+ Nanoid.Nanoid.Generate("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7),
                        GuestFirstName = "Jogn",
                        GuestLastName = "Bonbon",
                        GuestNationality = "Ebnasdg",
                        GuestPhoneNumber = "43252352",
                        Address = "Ararwaerawe st. 2",
                        GuestEmail = "bachokiro@abv.bg",
                        totalPrice = 300M,
                        CheckedIn = false,
                        CreatedOn = DateTime.Today,
                        IsActive = true,
                        NumberOfGuests = 2,
                        NumberOfChildren = 1,
                        ArrivalDate = DateTime.Today.AddDays(-20),
                        DepartureDate = DateTime.Today.AddDays(5),
                        RoomId = 1
                    },
                    new Reservation
                    {
                        Id = "R"+ Nanoid.Nanoid.Generate("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7),
                        GuestFirstName = "Gorgon",
                        GuestLastName = "Maimun",
                        GuestNationality = "Etipiq",
                        GuestPhoneNumber = "432522342552",
                        Address = "Berlinm st. 2",
                        GuestEmail = "aeiotawi@abv.bg",
                        IsActive = true,
                        CheckedIn = true,
                        CreatedOn = DateTime.Today,
                        totalPrice = 7000M,
                        NumberOfGuests = 3,
                        NumberOfChildren = 1,
                        ArrivalDate = DateTime.Today.AddDays(-10),
                        DepartureDate = DateTime.Today.AddDays(1),
                        RoomId = 4
                    },
                    new Reservation
                    {
                        Id = "R"+ Nanoid.Nanoid.Generate("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7),
                        GuestFirstName = "Alex",
                        GuestLastName = "Malex",
                        GuestNationality = "Bulgarian",
                        GuestPhoneNumber = "74572",
                        CheckedIn = true,
                        CreatedOn = DateTime.Today,
                        Address = "Avenue 235 st. 2",
                        GuestEmail = "bacro@abv.bg",
                        IsActive = true,
                        totalPrice = 3000M,
                        NumberOfGuests = 5,
                        NumberOfChildren = 1,
                        ArrivalDate = DateTime.Today.AddDays(-5),
                        DepartureDate = DateTime.Today.AddDays(5),
                        RoomId = 6
                    },
                    new Reservation
                    {
                        Id = "R"+ Nanoid.Nanoid.Generate("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7),
                        GuestFirstName = "Kapucin",
                        GuestLastName = "Krava",
                        GuestNationality = "Tigan",
                        GuestPhoneNumber = "4643453453352",
                        Address = "Sofia 34 st. 2",
                        CheckedIn = false,
                        CreatedOn = DateTime.Today,
                        GuestEmail = "karakan@abv.bg",
                        totalPrice = 3840M,
                        NumberOfGuests = 2,
                        IsActive = true,
                        NumberOfChildren = 0,
                        ArrivalDate = DateTime.Today.AddDays(10),
                        DepartureDate = DateTime.Today.AddDays(20),
                        RoomId = 7
                    },
                    new Reservation
                    {
                        Id = "R"+ Nanoid.Nanoid.Generate("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7),
                        GuestFirstName = "Makaron",
                        GuestLastName = "Sharan",
                        GuestNationality = "Lujica",
                        GuestPhoneNumber = "247457452",
                        Address = "Svishtov 532",
                        GuestEmail = "gasgao@abv.bg",
                        CheckedIn = false,
                        totalPrice = 1000M,
                        IsActive = true,
                        NumberOfGuests = 2,
                        NumberOfChildren = 1,
                        ArrivalDate = DateTime.Today.AddDays(20),
                        DepartureDate = DateTime.Today.AddDays(31),
                        RoomId = 3
                    },
                };

        return models;
    }

    
}