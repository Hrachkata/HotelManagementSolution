namespace HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

/// <summary>
/// Employee query model
/// </summary>
public class EmployeeQueryServiceModel
{
    public int TotalEmployeesCount { get; set; }

    /// <summary>
    /// Employees
    /// </summary>

    public IEnumerable<SingleEmployeeServiceModel> Employees { get; set; } = new HashSet<SingleEmployeeServiceModel>();
}