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

        // You need to verify your sender in SendGrid to send emails.
        public async Task SendMail(string sendToEmail)
        {
            #region Variant 1
            //var msg = new SendGridMessage();

            //msg.SetFrom(new EmailAddress("nadarqa@gmail.com", "Nadar Testing purposes"));

            //var recipients = new List<EmailAddress>
            //{
            //    new EmailAddress("nadaralp16@gmail.com", "Nadar Alpenidzesdqw")
            //};

            //// msg.AddTo(); // adds a single recipient to the email.
            //msg.AddTos(recipients);


            //// Set message subject
            //msg.SetSubject("This is a test email from mailgrid nadar test");

            //// Adding content the the email
            //msg.AddContent(MimeType.Text, "Hello world plain text");
            //msg.AddContent(MimeType.Html, "<h1>Hello world h1 tag</h1>");


            //// To send the email we need to create the send grid client with the API key.
            //var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_APIKEY"));


            //// Sending the email
            //await client.SendEmailAsync(msg); 
            #endregion

            #region Variant 2

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("nadarqa@gmail.com", "Example User");
            var subject = "Hi Josh";
            var to = new EmailAddress("nadaralp16@gmail.com", "Example User");
            var plainTextContent = "How are you doing today?";
            var htmlContent = "<strong>Hey anie, how are you?. I wanted to thank you for joining our website. Here is a link to read more about it <br /> <a href=\"https://google.com\">Read more</a></strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            var t = response.Body;

            #endregion



        }
    }
}
