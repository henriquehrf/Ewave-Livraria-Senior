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
	[Route("api/[controller]/")]
	public class InstituicaoEnsinoController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IInstituicaoEnsinoService _instituicaoEnsinoService;
		private readonly IInstituicaoEnsinoFinder _instituicaoEnsinoFinder;
		private readonly NotificationContext _notificationContext;

		public InstituicaoEnsinoController(IUnitOfWork unitOfWork, 
											IInstituicaoEnsinoService instituicaoEnsinoService,
											IInstituicaoEnsinoFinder instituicaoEnsinoFinder,
											NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_instituicaoEnsinoService = instituicaoEnsinoService;
			_instituicaoEnsinoFinder = instituicaoEnsinoFinder;
			_notificationContext = notificationContext;
		}

		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InstituicaoEnsinoViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirUsuario(InstituicaoEnsinoViewModel instituicaoVm)
		{
			var instituicao = _instituicaoEnsinoService.Inserir(instituicaoVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, instituicao.ToModel());
		}

		[HttpPut("alterar")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Alterar(InstituicaoEnsinoViewModel instituicaoVm)
		{
			_instituicaoEnsinoService.Alterar(instituicaoVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status200OK);
		}

		[HttpGet("instituicao-ensino-dropdown")]
		[ProducesResponseType(StatusCodes.Status200OK, Type =typeof(DropdownDto))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> InstituicaoEnsinoDropDown()
		{
			var instituicoes = await _instituicaoEnsinoFinder.InstituicaoDropdown();

			return StatusCode(StatusCodes.Status200OK, instituicoes);
		}
	}
}
