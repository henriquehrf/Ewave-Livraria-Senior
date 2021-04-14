using Microsoft.Extensions.DependencyInjection;
using ToDo.Infra.Shared.NotificationContext;

namespace Todo.Infra.CrossCutting.InversionOfControl
{
	public static class NotificationDependency
	{
		public static void AddNotificationDependency(this IServiceCollection services)
		{
			services.AddScoped<NotificationContext>();
		}
	}
}
