namespace HotelManagement.Data.Common.CommonModels.Contracts;

public interface IDateInfoModel
{
     DateTime CreatedOn { get; set; }

     DateTime? EditedOn { get; set; }
}