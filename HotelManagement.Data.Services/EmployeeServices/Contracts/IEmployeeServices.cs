using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using static HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels.EmployeeSortingClass;


namespace HotelManagement.Data.Services.EmployeeServices.Contracts;

public interface IEmployeeServices
{
    /// <summary>
    /// Returns all employees based on params
    /// </summary>
    /// <param name="sorting"></param>
    /// <param name="department"></param>
    /// <param name="active"></param>
    /// <param name="searchTerm"></param>
    /// <param name="currentPage"></param>
    /// <param name="employeesPerPage"></param>
    /// <returns>Task&lt;EmployeeQueryServiceModel&gt;</returns>
    public Task<EmployeeQueryServiceModel> All(
        EmployeeSorting sorting = EmployeeSorting.Newest,
        string department = "",
        bool active = true,
        string searchTerm = "",
        int currentPage = 1,
        int employeesPerPage = 1
        );

    /// <summary>
    /// returns all department names 
    /// </summary>
    /// <returns>Task&lt;IEnumerable&lt;string&gt;&gt;</returns>
    public Task<IEnumerable<string>> AllDeparmentsNames();

    /// <summary>
    /// Returns user details model
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task&lt;EmployeeDetailsModel&gt;</returns>
    public Task<EmployeeDetailsModel> GetUserDetailsModel(string id);


    /// <summary>
    /// Returns user edit model
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task&lt;EmployeeEditViewModel&gt;</returns>
    public Task<EmployeeEditViewModel>? GetUserEditViewModelByIdAsync(string id);


    /// <summary>
    /// Adds department to user and returns true if successful
    /// </summary>
    /// <param name="departmentId"></param>
    /// <param name="userId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> AddDepartmentToUser(int departmentId, string userId);

    /// <summary>
    /// Removes department to user and returns true if successful
    /// </summary>
    /// <param name="departmentId"></param>
    /// <param name="userId"></param>
    /// <returns>Task&lt;bool&gt;</returns>
    public Task<bool> RemoveDepartmentFromUser(int departmentId, string userId);


    /// <summary>
    /// Edits user from EmployeeEditViewModel
    /// </summary>
    /// <param name="editedModel"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    public Task<IdentityResult> EditUserFromEditViewModel(EmployeeEditViewModel editedModel);


    /// <summary>
    /// Disables user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    public Task<IdentityResult> DisableUser(string userId);


    /// <summary>
    /// Enables user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    public Task<IdentityResult> EnableUser(string userId);
}