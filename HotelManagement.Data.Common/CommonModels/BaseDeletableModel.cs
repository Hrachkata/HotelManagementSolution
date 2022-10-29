using HotelManagement.Data.Common.CommonModels.Contracts;

namespace HotelManagement.Data.Common.CommonModels
{
    public class BaseDeletableModel : IDeletableModel
    {
        public bool IsActive { get; set; } = true;

        public DateTime? DeletedOn { get; set; }
    }
}
