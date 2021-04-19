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
	public class LivroController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILivroService _livroService;
		private readonly ILivroFinder _livroFinder;
		private readonly NotificationContext _notificationContext;

		public LivroController(IUnitOfWork unitOfWork, 
								ILivroService livroService,
								 ILivroFinder livroFinder,
								NotificationContext notificationContext)
		{
			_unitOfWork = unitOfWork;
			_livroService = livroService;
			_livroFinder = livroFinder;
			_notificationContext = notificationContext;
		}

		[HttpPost("inserir")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LivroViewModel))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult InserirUsuario(LivroViewModel livroVm)
		{
			var livro = _livroService.Inserir(livroVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status201Created, livro.ToModel());
		}

		[HttpPut("alterar")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult Alterar(LivroViewModel livroVm)
		{
			_livroService.Alterar(livroVm.ToEntity());
			if (_notificationContext.Notifications.Count > 0)
				return BadRequest(_notificationContext.Notifications);

			_unitOfWork.Commit();
			_unitOfWork.Dispose();
			return StatusCode(StatusCodes.Status200OK);
		}

		[HttpGet("buscar-por-titulo")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroDto))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> BuscarPorTitulo([FromQuery] PaginacaoDto paginacao, [FromQuery] string titulo)
		{
			var livros = await _livroFinder.RetornarLivroPorTitulo(paginacao, titulo);
			return StatusCode(StatusCodes.Status200OK, livros);
		}
	}
}
