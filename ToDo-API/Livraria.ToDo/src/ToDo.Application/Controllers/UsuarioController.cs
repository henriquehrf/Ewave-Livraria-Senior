using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Infra.CrossCutting.Filter;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Interfaces.UnitOfWork;
using ToDo.Domain.Models.ViewModels;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Route("api/[controller]/")]
	public class UsuarioController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUsuarioService _usuarioService;
		private readonly NotificationContext _notificationContext;

		public UsuarioController(IUnitOfWork unitOfWork, 
								IUsuarioService usuarioService, 
								NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_usuarioService = usuarioService;
			_notificationContext = notificationContext;
		}

		[HttpPost("inserir-usuario")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirUsuario(UsuarioViewModel usuarioVm)
		{
			var usuario = _usuarioService.Inserir(usuarioVm.ToEntity());
			if(_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, usuario.ToModel());
		}
	}
}
