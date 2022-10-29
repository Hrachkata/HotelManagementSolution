namespace HotelManagement.Data.Common.CommonModels.Contracts;

public interface IDeletableModel
{
    bool IsActive { get; set; }
    DateTime? DeletedOn { get; set; }
}