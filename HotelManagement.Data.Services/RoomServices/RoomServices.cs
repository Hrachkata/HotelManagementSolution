using AutoMapper;
using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;
using HotelManagement.Data.Models.Models;

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

        public async Task<int> EditRoomWithRegisterViewModel(RoomEditViewModel model)
        {
           

            var room = await context.Rooms.FindAsync(model.Id);

            if (room == null)
            {
                throw new ArgumentNullException("Room id is invalid or doesn't correspond to an existing room.");
            }
            
            room.RoomNumber = model.RoomNumber;

            room.Capacity = model.Capacity;

            room.FloorId = model.FloorId;

            room.RoomTypeId = model.RoomTypeDtoId;

            int isChanged = 0;

            try
            {
                 isChanged = await context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isChanged;
        }

        public async Task<RoomDetailsViewModel> GetRoomDetailsModelAsync(int id)
        {
            var model = await context.Rooms.Include(r => r.RoomType).Where(r => r.Id == id).FirstOrDefaultAsync();

            if (model == null)
            {
                throw new ArgumentNullException("Room id doesn't correspond to an existing room.");
            }

            return mapper.Map<RoomDetailsViewModel>(model);
        }

        public async Task<RoomEditViewModel> GetRoomEditViewModelAsync(int id)
        {
            var model = await context.Rooms.Include(r => r.Floor).Include(r => r.RoomType).Where(r => r.Id == id).FirstOrDefaultAsync();

            var allRoomTypes = await context.RoomTypes.ProjectTo<RoomTypeDto>(mapper.ConfigurationProvider).ToListAsync();

            var allFloors = await context.Floors.ProjectTo<FloorDto>(mapper.ConfigurationProvider).ToListAsync();

            if (model == null)
            {
                throw new ArgumentNullException("Room id doesn't correspond to an existing room.");
            }

            var result = mapper.Map<RoomEditViewModel>(model);

            result.FloorDtos = allFloors;

            result.RoomTypeDtos = allRoomTypes;

            return result;

        }



    }
}
