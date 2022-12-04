using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.EntityFrameworkCore;

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
        var resId = await Nanoid.Nanoid.GenerateAsync("0123456789ABCDEFGHJKLMNOPQRSTUVWXYZ", 7);

        //var isLoyal = await IsLoyalGuest(model);

        var reservation = mapper.Map<Reservation>(model);

        reservation.Id = "R" + resId;

        reservation.CheckedIn = false;

        //reservation.totalPrice = isLoyal
        //    ? reservation.totalPrice - (reservation.totalPrice * 0.05M)
        //    : reservation.totalPrice;

        await context.Reservations.AddAsync(reservation);
        
        var result = await context.SaveChangesAsync();

        if (result!=1)
        {
            return false;
        }

        return true;
    }

    /*
    internal async Task<bool> IsLoyalGuest(BookingModel model)
    {
        var guest = await context.Guests.Where(g => (g.FirstName == model.GuestFirstName && g.LastName == model.GuestLastName && model.GuestEmail == g.Email) || model.GuestPhoneNumber == g.PhoneNumber).FirstOrDefaultAsync();

        if (guest == null)
        {
            var newGuest = new Guest()
            {
                FirstName = model.GuestFirstName,
                LastName = model.GuestLastName,
                Email = model.GuestEmail,
                PhoneNumber = model.GuestPhoneNumber,
                CreatedOn = DateTime.Today
            };

            await context.Guests.AddAsync(newGuest);

            return false;
        }

        return guest.IsLoyalGuest;
        
    }
    */


}