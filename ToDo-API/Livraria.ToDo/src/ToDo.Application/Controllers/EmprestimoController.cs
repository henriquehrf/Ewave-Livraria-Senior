using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
	public class EmprestimoController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmprestimoService _emprestimoService;
		private readonly NotificationContext _notificationContext;

		public EmprestimoController(IUnitOfWork unitOfWork,
									IEmprestimoService emprestimoService, 
									NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_emprestimoService = emprestimoService;
			_notificationContext = notificationContext;
		}


		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmprestimoViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirUsuario(EmprestimoViewModel emprestimoVm)
		{
			var emprestimo = _emprestimoService.Inserir(emprestimoVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, emprestimo.ToModel());
		}

		[HttpPut("devolver")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Alterar(int idEmprestimo, int idUsuario)
		{
			_emprestimoService.DevolverEmprestimo(idEmprestimo, idUsuario);
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status200OK);
		}
	}
}
