namespace HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

/// <summary>
/// Employee sorting
/// </summary>
public class EmployeeSortingClass
{
    public enum EmployeeSorting
    {
        Newest = 0,
        Oldest = 1,
        ByFirstName = 2,
        ByLastName = 3,
        ByDepartment = 4
    }

}