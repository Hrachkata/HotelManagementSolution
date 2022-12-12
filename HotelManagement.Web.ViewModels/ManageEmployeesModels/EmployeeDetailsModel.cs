namespace HotelManagement.Web.ViewModels.ManageEmployeesModels;

/// <summary>
/// Employee details model
/// </summary>
public class EmployeeDetailsModel
{
    public Guid Id { get; set; }
    public string RFID { get; set; }

    public IEnumerable<string> Departments { get; set; }
    public bool EmailConfirmed { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Salary { get; set; }
    public string EGN { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? DeletedOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? EditedOn { get; set; }
}