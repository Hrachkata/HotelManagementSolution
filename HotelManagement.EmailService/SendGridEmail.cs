using System.Text.Encodings.Web;
using FluentEmail.Core.Models;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using Microsoft.AspNetCore.Http.Extensions;

namespace HotelManagement.EmailService;
public class SendGridEmail
{
    public IConfigurationRoot config { get; set; }

    public SendGridEmail(IConfigurationRoot _config)
    {
        config = _config;  
    }

    public SendResponse fluentMailSend(string mailReceiver, string subject, string tag, string body)
    {
        IFluentEmail fluentEmail = Email
            .From("virvoda6@abv.bg")
            .To(mailReceiver)
            .Subject(subject)
            .Tag(tag)
            .Body(body);

        var SendGridApiKey = config["SendGrid:SendGridApiKey"];

        SendGridSender sendGridSender = new SendGridSender(SendGridApiKey);

        SendResponse response = sendGridSender.Send(fluentEmail);

        return response;

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

    public SendResponse sendConfirmationEmail(string userId, string token, string email)
    {

        var values = new[] {
            new KeyValuePair<string,string>("userId",userId),
            new KeyValuePair<string,string>("token", token),
            new KeyValuePair<string,string>("email", email),
        };
        var result = "Click link to verify your account:\n";

        result += UriHelper.BuildAbsolute("https", new HostString("localhost", 7132), pathBase: "/Account/ConfirmEmail",
            PathString.Empty, QueryString.Create(values), FragmentString.Empty);


        return fluentMailSend(email, "Hotel Management Email Confirm", "Tag", result);
    }

    public SendResponse SendForgotPasswordEmail(string userId, string token, string email)
    {

        var values = new[] {
            new KeyValuePair<string,string>("userId",userId),
            new KeyValuePair<string,string>("token", token),
            new KeyValuePair<string,string>("email", email),
        };
        var result = "Click link to reset your password:\n";

        result += UriHelper.BuildAbsolute("https", new HostString("localhost", 7132), pathBase: "/Account/ResetPassword",
            PathString.Empty, QueryString.Create(values), FragmentString.Empty);

        Console.WriteLine(result);

        return fluentMailSend(email, "Hotel Management Reset Password", "Tag", result);
    }

}




