using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Infra.CrossCutting.Filter;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models.Dtos;
using ToDo.Domain.Models.ViewModels;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Route("api/[controller]/")]
	public class LoginController : Controller
	{
		private readonly ILoginService _loginService;
		private readonly NotificationContext _notificationContext;

		public LoginController(ILoginService loginService, 
							   NotificationContext notificationContext)
		{
			_loginService = loginService;
			_notificationContext = notificationContext;
		}

		[AllowAnonymous]
		[HttpPost("autenticar")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CredencialDto))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult EfetuarLogin(
			[FromBody] CredenciaisViewModel credenciais)
		{
			var credencial = _loginService.EfetuarLogin(credenciais);

			if (_notificationContext.Notifications.Count > 0)
				return Unauthorized(_notificationContext.Notifications);

			return StatusCode(StatusCodes.Status200OK, credencial);

		}

	}
}
