using AutoMapper;
using System.Reflection;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Internal;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace HotelManagement.Data.Services.Tests;

public class EmailSenderTests
{

    private ApplicationDbContext context;

    private IMapper mapper;

    private SendGridEmail emailService;

    private AccountServices.AccountServices accountServices;

    [SetUp]
    public void Setup()
    {
            
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
                
            .Options;
           
        this.context = new ApplicationDbContext(options);
        this.context.SaveChanges();

        emailService = new SendGridEmail(new ConfigurationRoot(new List<IConfigurationProvider>()));
    }
    

    [Test]
    public void SendConfirmEmail()
    {
        var result = emailService.sendConfirmationEmail("alabala", "2356", "ganchoKapitancho@abv.bg");

        Assert.IsTrue(result.Successful);

    }

    [Test]
    public void SendResetPassword()
    {
        var result = emailService.SendForgotPasswordEmail("alabala", "2356", "ganchoKapitancho@abv.bg");

        Assert.IsTrue(result.Successful);

    }
}