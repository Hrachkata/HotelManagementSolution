using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

namespace HotelManagement.Data.Services.BookingServices;

public class BookingService : IBookingService
{
    private readonly IMapper mapper;
    private readonly ApplicationDbContext context;

    public BookingService(
        IMapper _mapper,
        ApplicationDbContext _context)
    {
            mapper = _mapper;

            context = _context;
    }
    public BookingModel projectRoomModelToBookingModel(SingleFreeRoomModel model)
    {
        return mapper.Map<BookingModel>(model);
    }

    public async Task<bool> reserveRoom(BookingModel model)
    {
        await context.Reservations.AddAsync(new Reservation()
        {
            Address = model.Address,
            ArrivalDate = model.ArrivalDate.Value,
            DepartureDate = model.DepartureDate.Value,
            CreatedOn = DateTime.Now,
            GuestEmail = model.GuestEmail,
            GuestFirstName = model.GuestFirstName,
            GuestLastName = model.GuestLastName,
            GuestNationality = model.GuestNationality,
            NumberOfChildren = model.NumberOfChildren,
            NumberOfGuests = model.NumberOfGuests,
            GuestPhoneNumber = model.GuestPhoneNumber,
            RoomId = model.RoomId
        });

        var result = await context.SaveChangesAsync();

        Console.WriteLine(result);

        return true;
    }
}