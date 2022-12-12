using System.Net.Mime;
using HotelManagement;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.Password.RequiredLength = 8;
        
        options.SignIn.RequireConfirmedEmail = true;

        options.Password.RequireNonAlphanumeric = false;

        options.Password.RequireUppercase = false;
    })
    .AddRoles<ApplicationUserRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

Log.Logger = logger;

var config = new ProgramConfiguration();

config.AddServicesToBuidler(builder);

builder.Services.ConfigureApplicationCookie(options =>
{
    
    options.AccessDeniedPath = new PathString("/Home/Unauthorized");
    
    options.LogoutPath = "/Account/Account/Logout";
    options.LoginPath = "/Account/Account/Login";
});

//SampleData.Initialize(builder.Services);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development");
    Log.Logger.Information("Development environment.");

    app.UseMigrationsEndPoint();
}
else
{
    Console.WriteLine("Production");

    Log.Logger.Information("Production environment.");

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

config.AddMaps(app);

app.Run();
