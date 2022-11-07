namespace HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

public class EmployeeQueryServiceModel
{
    public int TotalEmployeesCount { get; set; }

    public IEnumerable<SingleEmployeeServiceModel> Employees { get; set; } = new HashSet<SingleEmployeeServiceModel>();
}