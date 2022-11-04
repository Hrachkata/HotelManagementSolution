using SendGrid.Helpers.Mail;
using SendGrid;

namespace HotelManagement.EmailService
{
    public class SendGridEmail
    {
            public async Task<Response> Execute()
            {
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID");
                var client = new SendGridClient("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");
                var from = new EmailAddress("test@example.com", "Example User");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("virvoda@abv.bg", "Example User");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return response;
            }
        
    }
}