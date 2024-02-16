using System.Net.Mail;
using System.Net;

namespace HealthOS.Utility.Emails
{
    public class EmailSender
    {
        private readonly string smtpServer = "smtp.office365.com";
        private readonly int smtpPort = 587;
        private readonly string smtpUsername = "services@aoholdings.net";
        private readonly string smtpPassword = "AOHoldings@2022";

        public EmailSender(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                body = "Hello Samson I am AO Holdings";
                to = "codemayeem@gmail.com";
                mailMessage.To.Add(to);
                try
                {
                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
            }
        }
    }
}
