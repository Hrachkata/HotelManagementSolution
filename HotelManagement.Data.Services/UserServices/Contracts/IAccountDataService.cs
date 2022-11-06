using HotelManagement.Web.ViewModels.UserModels;

namespace HotelManagement.Data.Services.UserServices.Contracts;

public interface IAccountDataService
{
    public Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync();


    public IEnumerable<UserViewModel> GetUserViewModelsAsync();
}