namespace SurveyBasket.Services.IService;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
}
