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
    }
}
