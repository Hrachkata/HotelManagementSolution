using System.Data;
using AutoMapper;
using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;

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

        public async Task<int> EditRoomWithEditViewModel(RoomEditViewModel model)
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

            room.EditedOn = DateTime.Today;

            int isChanged = 0;

            try
            {
                 isChanged = await context.SaveChangesAsync();

                 if (isChanged == 0)
                 {
                     throw new DBConcurrencyException("No rows modified.");
                 }

            }
            catch (DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }



            return isChanged;
        }

        public async Task<bool> DeleteRoomById(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            if (model.Reservations.Any())
            {
                throw new OperationCanceledException("There are reservations registered with this room.");
            }

            model.IsActive = false;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");

        }

        public async Task<bool> RoomOutOfServiceByIdAsync(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            model.IsOutOfService = true;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");

        }

        public async Task<bool> IsCleanedAsync(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            model.IsCleaned = true;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");
        }

        public async Task<bool> IsDirtyAsync(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            model.IsCleaned = false;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");

        }

        public async Task<bool> RoomInServiceByIdAsync(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            model.IsOutOfService = false;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");
        }

        public async Task<bool> EnableRoomById(int id)
        {
            var model = await context.Rooms.FindAsync(id);


            if (model == null)
            {
                throw new ArgumentNullException("Room with this Id is non existent or the id is invalid.");
            }

            model.IsActive = true;

            var isOk = await context.SaveChangesAsync();

            if (isOk > 0)
            {
                return true;
            }

            throw new DBConcurrencyException("No rows modified.");

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
