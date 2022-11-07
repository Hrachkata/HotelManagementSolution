namespace HotelManagement.Web.ViewModels.ManageEmployeesModels;

public class EmployeeDetailsModel
{
    public string RFID { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Salary { get; set; }
    public string EGN { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? DeletedOn { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? EditedOn { get; set; }
}