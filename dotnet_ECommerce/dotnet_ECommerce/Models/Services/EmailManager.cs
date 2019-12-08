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
    /// <summary>
    /// The EmailManager class inherit IEmailSender interface and brings in dependency IConfiguration interface
    /// </summary>
    public class EmailManager : IEmailSender
    {
        public IConfiguration Configuration { get; }
        public EmailManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Brings in string type of email, subject, and message contents
        /// Brings in the sender from configuration and create a new SendGridMessage
        /// Set the message properties to have a sender, an email subject, and email contents
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="htmlMessage"></param>
        /// <returns>Send out an email containing the above information to the user</returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(Configuration["SendGridEmail"]);
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("donotreply@tinyplants.com", "Tiny Plants Admin");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
