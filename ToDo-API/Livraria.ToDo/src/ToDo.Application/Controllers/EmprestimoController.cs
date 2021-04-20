using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
	[Route("api/[controller]/")]
	public class EmprestimoController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmprestimoService _emprestimoService;
		private readonly IEmprestimoFinder _emprestimoFinder;
		private readonly NotificationContext _notificationContext;

		public EmprestimoController(IUnitOfWork unitOfWork,
									IEmprestimoService emprestimoService,
									IEmprestimoFinder emprestimoFinder,
									NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_emprestimoService = emprestimoService;
			_emprestimoFinder = emprestimoFinder;
			_notificationContext = notificationContext;
		}


		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmprestimoViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirEmprestimo(EmprestimoViewModel emprestimoVm)
		{
			emprestimoVm.DataEmprestimo = DateTime.Now;
			emprestimoVm.DataPrevistaDevolucao = DateTime.Now.AddDays(30);
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
		public IActionResult Devolver(EmprestimoViewModel emprestimoVm)
		{
			_emprestimoService.DevolverEmprestimo(emprestimoVm.Id);
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status200OK);
		}

		[HttpGet("buscar-por-usuario")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<EmprestimoDto>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> BuscarPorUsuario([FromQuery] int idUsuario)
		{
			var emprestimos = await _emprestimoFinder.BuscarEmprestimoAtivoPorUsuario(idUsuario);

			return StatusCode(StatusCodes.Status200OK, emprestimos);
		}

		[HttpGet("todos")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<EmprestimoDto>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> Todos()
		{
			var emprestimos = await _emprestimoFinder.TodosAtivo();

			return StatusCode(StatusCodes.Status200OK, emprestimos);
		}
	}
}
