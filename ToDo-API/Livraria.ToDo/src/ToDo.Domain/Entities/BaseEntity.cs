using Flunt.Notifications;

namespace ToDo.Domain.Entities
{
	public class BaseEntity<T> : Notifiable
	{
		protected BaseEntity(T id = default)
		{
			Id = id;
		}

		public virtual T Id { get; protected set; }
	}
}
