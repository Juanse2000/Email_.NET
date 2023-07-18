using SimpleEmailApp.Models;

namespace SimpleEmailApp.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
