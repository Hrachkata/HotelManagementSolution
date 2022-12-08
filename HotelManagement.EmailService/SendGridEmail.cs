using System.Text.Encodings.Web;
using FluentEmail.Core.Models;
using FluentEmail.Core;
using FluentEmail.SendGrid;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using HotelManagement.EmailService.Contracts;
using Microsoft.AspNetCore.Http.Extensions;

namespace HotelManagement.EmailService;
public class SendGridEmail : ISendGridEmail
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

        var SendGridApiKey = "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";

        SendGridSender sendGridSender = new SendGridSender(SendGridApiKey);

        SendResponse response = sendGridSender.Send(fluentEmail);

        return response;


    }

    public SendResponse sendConfirmationEmail(string userId, string token, string email)
    {

        var values = new[] {
            new KeyValuePair<string,string>("userId",userId),
            new KeyValuePair<string,string>("token", token),
            new KeyValuePair<string,string>("email", email),
        };
        var result = "Click link to verify your account:\n";

        result += UriHelper.BuildAbsolute("https", new HostString("localhost", 7132), pathBase: "/Account/Account/ConfirmEmail",
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

        result += UriHelper.BuildAbsolute("https", new HostString("localhost", 7132), pathBase: "/Account/Account/ResetPassword",
            PathString.Empty, QueryString.Create(values), FragmentString.Empty);
        

        return fluentMailSend(email, "Hotel Management Reset Password", "Tag", result);
    }

}




