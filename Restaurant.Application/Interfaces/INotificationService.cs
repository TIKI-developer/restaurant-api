namespace Restaurant.Application.Interfaces
{
    public interface INotificationService
    {
        Task Send(string messageTitle, string messageBody, string fcmToken);
    }
}
