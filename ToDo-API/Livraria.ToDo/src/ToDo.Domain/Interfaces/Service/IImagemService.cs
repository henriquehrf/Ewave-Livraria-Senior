using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IImagemService
	{
		Task<Guid> SalvarImagem(IFormFile file);
		Task<byte[]> CarregarImagem(string guid);
		void RemoverImagem(string guid);
	}
}
