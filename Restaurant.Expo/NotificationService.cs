using Restaurant.Application.Interfaces

namespace Restaurant.Expo
{
    public class NotificationService : INotificationService
    {
        public async void Send(string messageTitle, string messageBody, string fcmToken)
        {
            var message = new Message()
            {
                Token = fcmToken,
                Notification = new Notification()
                {
                    Title = messageTitle,
                    Body = messageBody
                }
            };
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
