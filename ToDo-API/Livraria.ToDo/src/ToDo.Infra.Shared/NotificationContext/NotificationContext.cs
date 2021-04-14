using Flunt.Notifications;

namespace ToDo.Infra.Shared.NotificationContext
{
	public class NotificationContext : Notifiable
	{
		public void AddNotificationIgnoreIsNull(Notification notification)
		{
			if (notification == null)
				return;

			AddNotification(notification);
		}
	}
}
