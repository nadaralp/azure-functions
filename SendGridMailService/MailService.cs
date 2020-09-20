using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridMailService
{
    public class MailService : IMailService
    {
        // Resource:
        // https://docs.microsoft.com/en-us/azure/sendgrid-dotnet-how-to-send-email

        // Note: you can add email footers, attachments, etc. Check out resource.
        public void SendMail(string sendToEmail)
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("dx@example.com", "Nadar Testing purposes"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("nadaralp16@gmail.com", "Nadar Alpenidzesdqw")
            };

            // msg.AddTo(); // adds a single recipient to the email.
            msg.AddTos(recipients);


            // Set message subject
            msg.SetSubject("This is a test email from mailgrid nadar test");

            // Adding content the the email
            msg.AddContent(MimeType.Text, "Hello world plain text");
            msg.AddContent(MimeType.Html, "<h1>Hello world h1 tag</h1>");


            // To send the email we need to create the send grid client with the API key.
            var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_APIKEY"));


            // Sending the email
            client.SendEmailAsync(msg);

        }
    }
}
