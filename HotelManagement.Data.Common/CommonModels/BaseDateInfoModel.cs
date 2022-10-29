using HotelManagement.Data.Common.CommonModels.Contracts;

namespace HotelManagement.Data.Common.CommonModels;

public class BaseDateInfoModel : BaseDeletableModel, IDateInfoModel
{
    public DateTime CreatedOn { get; set; }

    public DateTime? EditedOn { get; set; }
}