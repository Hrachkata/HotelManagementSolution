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
        var test = await Nanoid.Nanoid.GenerateAsync("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7);

        var reservation = mapper.Map<Reservation>(model);

        reservation.Id = test;

        reservation.CheckedIn = false;

        await context.Reservations.AddAsync(reservation);
        
        var result = await context.SaveChangesAsync();

        if (result!=1)
        {
            return false;
        }

        return true;
    }
}