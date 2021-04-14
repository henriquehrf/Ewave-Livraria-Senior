using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Infra.Shared.NotificationContext;

namespace Todo.Infra.CrossCutting.Filter
{
	public class NotificationFilter : IAsyncResultFilter
	{
		private readonly NotificationContext _notificationContext;

		public NotificationFilter(NotificationContext notificationContext)
		{
			_notificationContext = notificationContext;
		}

		public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
		{
			if (_notificationContext.Invalid)
			{
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.HttpContext.Response.ContentType = "application/json";

				var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications
																					.Select(n => NotificationResponse.From(n)));
				await context.HttpContext.Response.WriteAsync(notifications);

				return;
			}

			await next();
		}
	}
}
