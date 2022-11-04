using FluentEmail.Core.Models;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using Microsoft.Extensions.Configuration;

namespace HotelManagement.EmailService;
public class SendGridEmail
{
    public IConfigurationRoot config { get; set; }
    public SendGridEmail(IConfigurationRoot _config)
    {
        config = _config;  
    }

    public void fluentMailSend(string mailReceiver, string subject, string tag, string body)
    {
        IFluentEmail fluentEmail = Email
            .From("virvoda6@abv.bg")
            .To(mailReceiver)
            .Subject(subject)
            .Tag(tag)
            .Body(body);
        
        SendGridSender sendGridSender = new SendGridSender(config["SendGridApiKey"]);
        SendResponse response = sendGridSender.Send(fluentEmail);

        if (response.Successful)
        {
            Console.WriteLine("The email was sent successfully");
        }
        else
        {
            Console.WriteLine("The email could not be sent. Check the errors: ");
            foreach (string error in response.ErrorMessages)
            {
                Console.WriteLine(error);
            }
        }
    }
}




