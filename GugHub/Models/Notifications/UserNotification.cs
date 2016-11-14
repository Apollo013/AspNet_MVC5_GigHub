using GugHub.Models.Application;

namespace GugHub.Models.Notifications
{
    public class UserNotification
    {
        public string UserId { get; private set; }
        public int NotificationId { get; private set; }

        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; private set; }

        private UserNotification() { }

        public static UserNotification Create(ApplicationUser user, Notification notification)
        {
            return new UserNotification()
            {
                User = user,
                Notification = notification
            };
        }

        public void MarkRead()
        {
            IsRead = true;
        }
    }
}