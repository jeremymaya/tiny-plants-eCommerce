using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models.Services
{
    public class EmailManager : IEmailSender
    {
        public IConfiguration Configuration { get; }
        public EmailManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SendGridAPIKey");
            var client = new SendGridClient(apiKey);

            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("donotreply@tinyplants.com", "Site Admin");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }

        public static async Task PurchaseSummaryEmailAsync()
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridAPIKey");
            var client = new SendGridClient(apiKey);
            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress("donotreply@tinyplants.com", "Site Admin"),
                Subject = "Purchase Summary",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("test@example.com", "Test User"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}
