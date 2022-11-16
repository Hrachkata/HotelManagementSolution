using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.EmployeeServices;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.FloorServices.Contracts;
using HotelManagement.Data.Services.UserServices;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Data.Services.ViewServices;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Data.Services.RoomServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;

        options.Password.RequireDigit = false;

        options.Password.RequireUppercase = false;

        options.Password.RequiredLength = 1;

        options.SignIn.RequireConfirmedAccount = false;

        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddRoles<ApplicationUserRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

//My services and configurations

builder.Services.AddScoped<IAccountServices, AccountServices>();

//this is for email sending
IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .AddUserSecrets<SendGridEmail>()
            .Build();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

builder.Services.AddScoped<IFloorServices, FloorServices>();

builder.Services.AddScoped<IRoomServices, RoomServices>();

builder.Services.AddSingleton(configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


builder.Services.AddSingleton<SeedUserData, SeedUserData>();

builder.Services.AddSingleton<SeedDeparments, SeedDeparments>();

builder.Services.AddSingleton<SeedFloors, SeedFloors>();

builder.Services.AddSingleton<SeedRoomTypes, SeedRoomTypes>();

builder.Services.AddSingleton<SeedRooms, SeedRooms>();


builder.Services.AddTransient<SendGridEmail, SendGridEmail>();

builder.Services.AddScoped<FloorVisualisationServices, FloorVisualisationServices>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});

//SampleData.Initialize(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
