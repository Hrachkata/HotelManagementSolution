using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using static HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels.EmployeeSortingClass;


namespace HotelManagement.Data.Services.EmployeeServices.Contracts;

public interface IEmployeeServices
{
    public Task<EmployeeQueryServiceModel> All(
        EmployeeSorting sorting = EmployeeSorting.Newest,
        string department = "",
        bool active = true,
        string searchTerm = "",
        int currentPage = 1,
        int employeesPerPage = 1
        );

    public Task<IEnumerable<string>> AllDeparmentsNames();

    public Task<EmployeeDetailsModel> GetUserDetailsModel(string id);
    public Task<EmployeeEditViewModel>? GetUserEditViewModelByIdAsync(string id);
}