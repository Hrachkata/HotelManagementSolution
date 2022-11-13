using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Services.FloorServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;


namespace HotelManagement.Data.Services.FloorServices;

public class FloorServices : IFloorServices
{

    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public FloorServices(
        ApplicationDbContext _context,
        IMapper _mapper
    )
    {
        context = _context;

        mapper = _mapper;
    }
    public async Task<RoomQueryServiceModel> All(
        RoomSorting sorting = RoomSorting.Newest,
        string type = "",
        bool active = true, 
        string searchTerm = "",
        int currentPage = 1,
        int roomsPerPage = 1)
    {
        var roomQuery = this.context.Rooms
            .Include(r => r.RoomType)
            .Include(r => r.Floor)
            .Where(r => r.IsActive == true).AsQueryable();

        var searchToLower = searchTerm?.ToLower() ?? string.Empty;

        if (!string.IsNullOrEmpty(type))
        {
            roomQuery = this.context.Rooms.Where(r => r.RoomType.Type == type);

        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            roomQuery = roomQuery;
        }

        roomQuery = sorting switch
        {
            RoomSorting.Newest =>
                roomQuery.OrderByDescending(r => r.CreatedOn),
            RoomSorting.Oldest =>
                roomQuery.OrderBy(r => r.CreatedOn),
            RoomSorting.ByRoomNumber =>
                roomQuery.OrderBy(r => r.RoomNumber),
        };

        var rooms = await roomQuery.Skip((currentPage) * roomsPerPage)
            .Take(roomsPerPage)
            .ProjectTo<SingleRoomServiceModel>(mapper.ConfigurationProvider).ToListAsync();


        var totalRooms = roomQuery.Count();

        return new RoomQueryServiceModel()
        {
            Rooms = rooms,
            TotalRoomsCount = totalRooms
        };
    }

    public async Task<IEnumerable<string>> GetRoomTypes()
    {
        return await context.RoomTypes.Select(rt => rt.Type).ToListAsync();
    }
}