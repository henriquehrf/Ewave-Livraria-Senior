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
	[Route("api/instituicoes-ensino/")]
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
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Inserir(InstituicaoEnsinoViewModel instituicaoVm)
		{
			var instituicao = _instituicaoEnsinoService.Inserir(instituicaoVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, instituicao.ToModel());
		}

		[HttpPut("alterar")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Alterar(InstituicaoEnsinoViewModel instituicaoVm)
		{
			_instituicaoEnsinoService.Alterar(instituicaoVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status204NoContent);
		}

		
		[HttpGet("dropdown")]
		[ProducesResponseType(StatusCodes.Status200OK, Type =typeof(DropdownDto))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> InstituicaoEnsinoDropDown()
		{
			var instituicoes = await _instituicaoEnsinoFinder.InstituicaoDropdown();

			return StatusCode(StatusCodes.Status200OK, instituicoes);
		}

		[HttpGet("buscar-por-nome")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InstituicaoEnsinoDto))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> BuscarPorNome([FromQuery] PaginacaoDto paginacao,
														[FromQuery] string nome)
		{
			var instituicoes = await _instituicaoEnsinoFinder.RetornarInstituicaoPorNome(paginacao, nome);
			return StatusCode(StatusCodes.Status200OK, instituicoes);
		}
	}
}
