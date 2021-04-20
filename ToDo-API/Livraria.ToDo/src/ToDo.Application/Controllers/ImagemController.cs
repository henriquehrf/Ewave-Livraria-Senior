using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Infra.CrossCutting.Filter;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Application.Controllers
{
	[ApiController]
	[Authorize("Bearer")]
	[Route("api/imagens/")]
	public class ImagemController : Controller
	{
		private readonly IImagemService _imagemService;
		private readonly NotificationContext _notificationContext;

		public ImagemController(IImagemService imagemService, NotificationContext notificationContext)
		{
			_imagemService = imagemService;
			_notificationContext = notificationContext;
		}

		
		[HttpPost("salvar")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> SalvarImagem([FromForm] IFormFile file)
		{
			return StatusCode(StatusCodes.Status201Created, new { guid = await _imagemService.SalvarImagem(file) }); ;
		}

		[HttpGet()]
		[AllowAnonymous]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VirtualFileResult))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public async Task<IActionResult> RetornarImagem([FromQuery] string guid)
		{
			var imagem = await _imagemService.CarregarImagem(guid);

			if (imagem == null)
				return NotFound();

			return File(imagem, "image/jpeg");
		}

		[HttpDelete("remover")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IList<NotificationResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErroResponse))]
		public IActionResult RemoverImagem([FromQuery]string guid)
		{
			_imagemService.RemoverImagem(guid);
			if (_notificationContext.Notifications.Count > 0)
				return StatusCode(StatusCodes.Status404NotFound, _notificationContext.Notifications);

			return NoContent();
		}
	}
}
