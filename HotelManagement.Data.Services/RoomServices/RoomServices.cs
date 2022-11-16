using AutoMapper;
using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Services.RoomServices
{
    public class RoomServices : IRoomServices
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RoomServices(
            ApplicationDbContext _context,
            IMapper _mapper
        )
        {
            context = _context;

            mapper = _mapper;
        }
        public async Task<RoomDetailsViewModel> GetRoomDetailsModel(int id)
        {
            var model = await context.Rooms.FindAsync(id);

            return mapper.Map<RoomDetailsViewModel>(model);
        }


    }
}
