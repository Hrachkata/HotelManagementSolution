using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.RoomModels;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
    }
}
