using Flunt.Notifications;
using System.Collections.Generic;

namespace ToDo.Infra.Shared.NotificationContext
{
	public class NotificationContext : Notifiable
	{
		public void AddNotificationIgnoreIsEmpty(Notification notification)
		{
			if (notification == null)
				return;

			AddNotification(notification);
		}

		public void AddNotificationsIgnoreIsEmpty(IList<Notification> notification)
		{
			if (notification == null || notification.Count == 0)
				return;

			AddNotifications(notification);
		}
	}
}
