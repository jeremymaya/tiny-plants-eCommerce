using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TinyPlants.Models.Services;

public class EmailSender : IEmailSender
{
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment WebHostEnvironment { get; }

    public EmailSender(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        WebHostEnvironment = webHostEnvironment;
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
        string sendgrid = WebHostEnvironment.IsDevelopment()
            ? Configuration["SENDGRID"]
            : Environment.GetEnvironmentVariable("SENDGRID");

        SendGridClient client = new SendGridClient(sendgrid);
        SendGridMessage msg = new SendGridMessage();

        msg.SetFrom("donotreply@tinyplants.com", "Tiny Plants Admin");
        msg.AddTo(email);
        msg.SetSubject(subject);
        msg.AddContent(MimeType.Html, htmlMessage);

        await client.SendEmailAsync(msg);
    }
}
