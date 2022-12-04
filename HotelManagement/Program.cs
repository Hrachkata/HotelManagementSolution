using HotelManagement;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


var config = new ProgramConfiguration();

config.AddServicesToBuidler(builder);

builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/User/Login"; });

//SampleData.Initialize(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("Development");

    app.UseMigrationsEndPoint();
}
else
{
    Console.WriteLine("Production");

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