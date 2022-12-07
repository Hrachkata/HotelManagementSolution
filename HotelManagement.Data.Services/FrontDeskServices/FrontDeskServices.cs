using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.FrontDeskServices
{
    public class FrontDeskServices : IFrontDeskServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FrontDeskServices(
            ApplicationDbContext _context,
            IMapper _mapper
        )
        {
            context = _context;

            mapper = _mapper;
        }
        

       public async Task<FreeRoomQueryServiceModel> All(
       DateTime? arrivalDate, 
       DateTime? departureDate,
       RoomSorting sorting = RoomSorting.Newest,
       string type = "",
       bool isAvailable = true,
       string searchTerm = "",
       int currentPage = 1,
       int roomsPerPage = 1,
       int floorId = 0)
        {
       
            var roomQuery = this.context.Rooms
                 .Include(r => r.RoomType)
                 .Include(r => r.Reservations)
                 .Where(r =>
                     r.IsActive == true
                 ).AsQueryable();
            
           await SetRoomOccupation(roomQuery);

           if (isAvailable)
           {
               roomQuery = roomQuery.Where(r => r.IsOutOfService == false);
           }

            var searchToLower = searchTerm?.ToLower() ?? string.Empty;

            if (!string.IsNullOrEmpty(type))
            {
                roomQuery = roomQuery.Where(r => r.RoomType.Type == type);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                roomQuery = roomQuery.Where(r => r.RoomNumber.ToString().Contains(searchToLower));
            }

            if (floorId != 0)
            {
                roomQuery = roomQuery.Where(r => r.FloorId == floorId);
            }

            

            roomQuery = sorting switch
            {
                RoomSorting.Newest =>
                    roomQuery.OrderByDescending(r => r.CreatedOn),
                RoomSorting.Oldest =>
                    roomQuery.OrderBy(r => r.CreatedOn),
                RoomSorting.ByRoomNumber =>
                    roomQuery.OrderBy(r => r.RoomNumber),
                RoomSorting.ByRoomNumberDescending =>
                    roomQuery.OrderByDescending(r => r.RoomNumber)
            };

            
       

            var rooms = await roomQuery.ProjectTo<SingleFreeRoomModel>(mapper.ConfigurationProvider).ToListAsync();

            var resultRooms = new List<SingleFreeRoomModel>();
            
            foreach (var room in rooms)
            {
                if (room.Reservations.Count == 0 )
                {
                    resultRooms.Add(room);

                    continue;
                }

                if (room.Reservations.Any(r => ((r.ArrivalDate >= arrivalDate && r.ArrivalDate <= departureDate) || (r.DepartureDate >= arrivalDate && r.DepartureDate <= departureDate)) && r.IsActive == true))
                {
                    continue;
                }

                resultRooms.Add(room);
            }


            var roomsPaged = resultRooms.Skip((currentPage) * roomsPerPage)
                .Take(roomsPerPage);


            return new FreeRoomQueryServiceModel()
            {
                Rooms = roomsPaged,
                TotalRoomsCount = resultRooms.Count
            };
        }


       private async Task<int> SetRoomOccupation(IQueryable<Room>? roomQuery)
       {
           foreach (var room in roomQuery)
            {
                if (room.Reservations.Any(r => r.CheckedIn == true && r.IsActive == true))
                {
                    room.IsOccupied = true;
                }
                else
                {
                    room.IsOccupied = false;
                }
                
            }

            return await context.SaveChangesAsync();
        }

      
    }
}
