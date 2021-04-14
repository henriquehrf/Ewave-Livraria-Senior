using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Infra.CrossCutting.Filter
{
	public class ErrorResponseExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			context.Result = new ObjectResult(ErroResponse.From(context.Exception)) { StatusCode = StatusCodes.Status500InternalServerError };
		}
	}
}
