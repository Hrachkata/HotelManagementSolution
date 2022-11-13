﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Web.ViewModels.ModelsForVisualization;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.ViewServices;

public class FloorVisualisationServices
{
    private readonly ApplicationDbContext context;

    private readonly IMapper mapper;
    public FloorVisualisationServices(ApplicationDbContext _context,
        IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }
    public async Task<List<FloorViewModel>> GetFloorItems()
    {
        var result = context.Floors.ProjectTo<FloorViewModel>(mapper.ConfigurationProvider).ToListAsync();

        return await result;
    }


}