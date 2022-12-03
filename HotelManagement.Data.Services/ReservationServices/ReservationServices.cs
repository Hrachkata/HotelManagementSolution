using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using static HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels.ReservationSortingClass;

namespace HotelManagement.Data.Services.ReservationServices
{
    public class ReservationServices : IReservationServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


   
        public ReservationServices(
            ApplicationDbContext _context,
            IMapper _mapper
        )
        {
            context = _context;

            mapper = _mapper;
        }

        public async Task<ReservationQueryServiceModel> All(
            DateTime? arrivalDateFrom, DateTime? arrivalDateTo,
            ReservationSorting sorting = ReservationSorting.Newest,
            string searchTerm = "", 
            int currentPage = 1,
            int roomsPerPage = 1)
        {
            var reservationQuery = this.context.Reservations.Include(r => r.Room)
               .Where(r =>
                   r.IsActive == true
               ).AsQueryable();
            
          
            var searchToLower = searchTerm?.ToLower() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                reservationQuery = reservationQuery.Where(r => r.Room.RoomNumber.ToString().Contains(searchToLower) ||
                    r.Id.Contains(searchToLower) ||
                    r.GuestFirstName.Contains(searchToLower) ||
                    r.GuestLastName.Contains(searchToLower) ||
                    r.GuestEmail.Contains(searchToLower));

            }

            if (arrivalDateFrom.HasValue && arrivalDateTo.HasValue)
            {
                reservationQuery =
                    reservationQuery.Where(r => r.ArrivalDate >= arrivalDateFrom && r.ArrivalDate <= arrivalDateTo);
            }else if (arrivalDateFrom.HasValue)
            {
                reservationQuery =
                    reservationQuery.Where(r => r.ArrivalDate >= arrivalDateFrom);
            }

            reservationQuery = sorting switch
            {
                ReservationSorting.Newest =>
                    reservationQuery.OrderByDescending(res => res.CreatedOn),
                ReservationSorting.Oldest =>
                    reservationQuery.OrderBy(res => res.CreatedOn),
                ReservationSorting.ByArrivalDate =>
                    reservationQuery.OrderBy(res => res.ArrivalDate),
                ReservationSorting.ByArrivalDateDescending =>
                    reservationQuery.OrderByDescending(res => res.ArrivalDate),
                ReservationSorting.ByDepartureDate =>
                    reservationQuery.OrderBy(res => res.DepartureDate),
                ReservationSorting.ByDepartureDateDescending=>
                    reservationQuery.OrderByDescending(res => res.DepartureDate)
            };

            var result = await reservationQuery.ProjectTo<SingleReservationViewModel>(mapper.ConfigurationProvider).ToListAsync();

            var resultPaged = result.Skip((currentPage) * roomsPerPage)
                .Take(roomsPerPage);



            var totalReservations = result.Count();

            return new ReservationQueryServiceModel()
            {
                Reservations = resultPaged,
                TotalReservationsCount = totalReservations
            };
        }

        public async Task<bool> CheckIn(string reservationId, int roomId)
        {
            var reservation = await context.Reservations.FindAsync(reservationId);

            var room = await context.Rooms.FindAsync(roomId);

            if (reservation == null)
            {
                throw new ArgumentNullException("Reservation id is invalid or reservation doesnt exist.");
            }
            
            reservation.CheckedIn = true;

            room.IsCleaned = false;
            
            room.IsOccupied = true;
            
            var result = await context.SaveChangesAsync();

            if (result != 0)
            {
                
                return true;
            }
            
            return false;
            
        }

        public async Task<bool> CheckOut(string reservationId, int roomId)
        {
            var reservation = await context.Reservations.FindAsync(reservationId);

            var room = await context.Rooms.FindAsync(roomId);

            if (reservation == null)
            {
                throw new ArgumentNullException("Reservation id is invalid or reservation doesnt exist.");
            }

            reservation.IsActive = false;

            reservation.CheckedIn = false;

            room.IsCleaned = false;

            room.IsOccupied = false;

            var result = await context.SaveChangesAsync();

            if (result != 0)
            {

                return true;
            }

            return false;
        }


        public async Task<bool> PrintFolioPaid(string reservationId)
        {
            var reservation = await context.Reservations.FindAsync(reservationId);

            if (reservation == null)
            {
                throw new ArgumentNullException("Reservation id is invalid or reservation doesnt exist.");
            }

            reservation.totalPrice = 0;

            var result = await context.SaveChangesAsync();

            if (result != 0)
            {

                return true;
            }

            return false;

        }
    }
}
