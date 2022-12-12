using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;

namespace HotelManagement.Data.Services.BookingServices.Contracts;

/// <summary>
/// Booking service
/// </summary>
public interface IBookingService
{

    /// <summary>
    /// Maps single SingleFreeRoomModel to BookingModel
    /// </summary>
    /// <param name="model"></param>
    /// <returns>BookingModel</returns>
    BookingModel projectRoomModelToBookingModel(SingleFreeRoomModel model);


    /// <summary>
    /// Reserves room
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Task<bool></returns>
    Task<bool> reserveRoom(BookingModel model); 
}