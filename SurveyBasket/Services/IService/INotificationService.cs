namespace SurveyBasket.Services.IService;

public interface INotificationService
{
    Task SendNewPollNotification(int? pollId = null);
}
