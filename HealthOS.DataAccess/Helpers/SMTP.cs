using System.Net.Mail;
using System.Net;
using HealthOS.DataAccess.Helpers;
using HealthOS.Models.Users;

namespace HealthOS.DataAccess.Helpers
{
    public class SMTP
    {
        private static readonly string smtpServer = "smtp.gmail.com";
        private static readonly int smtpPort = 587;
        private static readonly string senderEmail = "codes_ticket@gmail.com";
        private static string senderPassword = "AutoCode1";

        public static void SendEmail(string recipient, string subject, string body)
        {
            using (var client = new SmtpClient(smtpServer))
            {
                client.Port = smtpPort;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage(senderEmail, recipient))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true; // Set the email body to be in HTML format

                    // Send the email
                    client.Send(mailMessage);
                }
            }
        }


        public static void SendPasswordResetEmail(User user)
        {
            if(!user.PasswordResetCodeExpiry.HasValue)
            {
                throw new AppException("The password reset code has not been successfully generated!");
            }

            string resetLink = $"http://localhost:4200/resetpassword/{user.UserName}/{user.PasswordResetCode}";

            string emailBody = ComposePasswordResetEmail(user.FirstName, user.Email, resetLink, user.PasswordResetCodeExpiry.Value);
            string emailSubject = "Reset Password (" + user.UserName + ") - Health Operating System";
            string emailRecipient = user.Email;

            SendEmail(emailRecipient, emailSubject, emailBody);
        }

        private static string ComposePasswordResetEmail(string firstName, string email, string resetLink, DateTime expiryDate)
        {
            return $@"
                <html>
                <head>
                    <style>
                        /* Add your custom email styles here */
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            background: #fff;
                        }}
                        .button {{
                            display: inline-block;
                            padding: 10px 20px;
                            background-color: #007BFF;
                            color: #fff;
                            text-decoration: none;
                            border-radius: 4px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Password Reset Request</h2>
                        <p>Hello {firstName},</p>
                        <p>We received a request to reset your password for your account associated with the email: <strong>{email}</strong></p>
                        <p>If you did not make this request, please ignore this email.</p>
                        <p>To reset your password, click the button below:</p>
                        <a class='button' href='{resetLink}'>Reset Password</a>
                        <p>If the button does not work, you can copy and paste the following URL into your browser:</p>
                        <p>{resetLink}</p>
                        <p>This link will expire on {expiryDate}.</p>
                        <p>If you have any questions or need assistance, please contact our support team.</p>
                        <p>Thank you,<br>Health OS Team</p>
                    </div>
                </body>
                </html>";
        }
    }
}
