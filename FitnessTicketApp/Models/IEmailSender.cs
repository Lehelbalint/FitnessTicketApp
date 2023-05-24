using System.Net.Mail;
using System.Net;
using MailKit.Security;
using MimeKit;



namespace FitnessTicketApp.Models
{
    public interface IEmailService
    {
        void SendEmail(string recipientEmail, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailService(IConfiguration configuration)
        {
            string smtpServer = configuration["EmailSettings:SmtpServer"];
            int smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            string senderEmail = configuration["EmailSettings:SenderEmail"];
            _senderPassword = configuration["EmailSettings:SenderPassword"];

            _senderEmail = senderEmail;

            _smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail, _senderPassword),
                EnableSsl = true
            };
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            var mailMessage = new MailMessage(_senderEmail, recipientEmail, subject, body);
            mailMessage.IsBodyHtml = true;

            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

            _smtpClient.Send(mailMessage);
        }
    }


}
