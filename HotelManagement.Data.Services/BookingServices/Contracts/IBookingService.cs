using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

namespace HotelManagement.Data.Services.BookingServices.Contracts;

public interface IBookingService
{
    BookingModel projectRoomModelToBookingModel(SingleFreeRoomModel model);

    Task<bool> reserveRoom(BookingModel model);
}