using HotelManagement.Web.ViewModels.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Services.RoomServices.Contracts
{
    public interface IRoomServices
    {
        public Task<RoomDetailsViewModel> GetRoomDetailsModel(int id);

   

    }
}
