using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Infra.CrossCutting.Filter;
using ToDo.Domain.Interfaces.Finder;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Interfaces.UnitOfWork;
using ToDo.Domain.Models.Dtos;
using ToDo.Domain.Models.ViewModels;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.ObjectMapper;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/usuarios/")]
	public class UsuarioController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUsuarioService _usuarioService;
		private readonly IUsuarioFinder _usuarioFinder;
		private readonly NotificationContext _notificationContext;

		public UsuarioController(IUnitOfWork unitOfWork,
								IUsuarioService usuarioService,
								IUsuarioFinder usuarioFinder,
								NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_usuarioService = usuarioService;
			_usuarioFinder = usuarioFinder;
			_notificationContext = notificationContext;
		}

		
		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirUsuario(UsuarioViewModel usuarioVm)
		{
			var usuario = _usuarioService.Inserir(usuarioVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, usuario.ToModel());
		}

		[HttpPut("alterar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Alterar(UsuarioViewModel usuarioVm)
		{
			_usuarioService.Alterar(usuarioVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status204NoContent);
		}


		[HttpGet("buscar-por-nome")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioDto))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> BuscarUsuario([FromQuery] PaginacaoDto paginacao, [FromQuery] string nomeUsuario)
		{
			var usuarios = await _usuarioFinder.RetornarUsuarioPorNome(paginacao, nomeUsuario);
			return StatusCode(StatusCodes.Status200OK, usuarios);
		}
	}
}
