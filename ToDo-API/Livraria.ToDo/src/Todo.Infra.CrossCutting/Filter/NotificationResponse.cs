using Flunt.Notifications;

namespace Todo.Infra.CrossCutting.Filter
{
	public sealed class NotificationResponse
	{
		public string Propriedade { get; private set; }
		public string Mensagem { get; private set; }

		public static NotificationResponse From(Notification notification)
		{
			return new NotificationResponse
			{
				Propriedade = notification.Property,
				Mensagem = notification.Message
			};
		}
	}
}
