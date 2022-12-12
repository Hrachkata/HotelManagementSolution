namespace HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

/// <summary>
/// Single employee dto
/// </summary>
public class SingleEmployeeServiceModel
{
    public Guid UserId { get; set; }

    public string UserName { get; set; }
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public bool IsActive { get; set; }

    public string DepartmentName { get; set; }

    public string Position { get; set; }

    public string RFID { get; set; }
}