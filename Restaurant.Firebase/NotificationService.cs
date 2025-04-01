using FirebaseAdmin.Messaging;
using Restaurant.Application.Interfaces;

namespace Restaurant.Firebase
{
    public class NotificationService : INotificationService
    {
        public async Task Send(string messageTitle, string messageBody, string fcmToken)
        {
            var message = new Message()
            {
                Token = fcmToken,
                Notification = new Notification()
                {
                    Title = messageTitle,
                    Body = messageBody
                },
            };

            try
            {
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
