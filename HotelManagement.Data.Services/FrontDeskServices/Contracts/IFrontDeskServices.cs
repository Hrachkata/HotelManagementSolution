using HotelManagement.Web.ViewModels.ReservationsModels;

namespace HotelManagement.Data.Services.FrontDeskServices.Contracts;

public interface IFrontDeskServices
{
    public Task<ReservationsViewModel> GenerateReservationViewModelAsync();
}