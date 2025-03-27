namespace Restaurant.Application.Interfaces
{
    public interface INotificationService
    {
        void Send(string messageTitle, string messageBody, string fcmToken);
    }
}
