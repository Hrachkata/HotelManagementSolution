using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.RoomModels;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public async Task<ReservationsViewModel> GenerateReservationViewModelAsync()
        {
            var roomTypes = await context.RoomTypes.ProjectTo<RoomTypeDto>(mapper.ConfigurationProvider).ToListAsync();

            var rooms = await context.Rooms.ProjectTo<RoomDetailsViewModel>(mapper.ConfigurationProvider).ToListAsync();

            var result = new ReservationsViewModel()
            {
                RoomTypes = roomTypes,
                AllRooms = rooms
            };

            return result;
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
               roomQuery = roomQuery.Where(r => r.IsCleaned == true && r.IsOccupied == false && r.IsOutOfService == false );
            }

            var searchToLower = searchTerm?.ToLower() ?? string.Empty;

            if (!string.IsNullOrEmpty(type))
            {
                roomQuery = this.context.Rooms.Where(r => r.RoomType.Type == type);
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

            var rooms = await roomQuery.Skip((currentPage) * roomsPerPage)
                .Take(roomsPerPage)
                .ProjectTo<SingleFreeRoomModel>(mapper.ConfigurationProvider).ToListAsync();


            var totalRooms = roomQuery.Count();

            return new FreeRoomQueryServiceModel()
            {
                Rooms = rooms,
                TotalRoomsCount = totalRooms
            };
        }


       public async Task<int> SetRoomOccupation(IQueryable<Room>? roomQuery)
       {
           foreach (var room in roomQuery)
           {
               if (room.Reservations.Any(r => r.ArrivalDate == DateTime.Today || (r.ArrivalDate <= DateTime.Today && r.DepartureDate >= DateTime.Today)))
               {
                   room.IsOccupied = true;
               }
               else if (room.Reservations.Any(r => r.DepartureDate == DateTime.Today))
               {
                   room.IsOccupied = false;
               }
           }

           return await context.SaveChangesAsync();
        }
    }
}
