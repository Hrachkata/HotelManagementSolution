using HotelManagement.Web.ViewModels.UserModels;

namespace HotelManagement.Data.Services.UserServices.Contracts;

public interface IUserDataService
{
    public Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync();
}