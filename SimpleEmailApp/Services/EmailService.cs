using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using SimpleEmailApp.Models;
using MailKit.Net.Smtp;

namespace SimpleEmailApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            
            foreach(var destinatario in request.Para)
            {
                email.To.Add(MailboxAddress.Parse(destinatario));
            }

            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Cuerpo
            };

            using var smpt = new SmtpClient();
            smpt.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smpt.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smpt.Send(email);
            smpt.Disconnect(true);
        }
    }
}
