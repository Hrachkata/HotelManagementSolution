using System.ComponentModel.DataAnnotations;
using HotelManagement.Data.Common.CommonModels;

namespace HotelManagement.Data.Common.CommonModels
{
    public class BaseModel<TKey> : BaseDateInfoModel
    {
        [Key]
        [Required]
        public TKey Id { get; set; }

       
        
    }

}
