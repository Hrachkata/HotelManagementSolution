using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.UserServices;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddControllersWithViews();

//My services and configurations

builder.Services.AddScoped<IAccountServices, AccountServices>();

//this is for email sending
IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IUrlHelper>(x => {
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});


builder.Services.AddSingleton(configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IAccountDataService, AccountDataService>();

builder.Services.AddSingleton<SeedUserData, SeedUserData>();

builder.Services.AddTransient<SendGridEmail, SendGridEmail>();

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
