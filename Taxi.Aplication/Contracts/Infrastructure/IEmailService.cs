using Taxi.Aplication.Models.Mail;

namespace Taxi.Aplication.Contracts.Infrastructure;
public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}