using FluentEmail.Core.Models;
using HotelManagement.EmailService;
using HotelManagement.EmailService.Contracts;
using Moq;

namespace HotelManagement.MockedLibraries;

public class MockEmailService
{
    public ISendGridEmail SendGridEmailMocked()
    {
        var emailService = new Mock<ISendGridEmail>();
       
        emailService.Setup(s => s.sendConfirmationEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new SendResponse());

        return emailService.Object;
    }
}