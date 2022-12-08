using FluentEmail.Core.Models;

namespace HotelManagement.EmailService.Contracts;

public interface ISendGridEmail
{
    public SendResponse fluentMailSend(string mailReceiver, string subject, string tag, string body);

    public SendResponse sendConfirmationEmail(string userId, string token, string email);

    public SendResponse SendForgotPasswordEmail(string userId, string token, string email);
}