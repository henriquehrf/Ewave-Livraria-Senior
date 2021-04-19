using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class ImagemService : IImagemService
	{
		private readonly string _serverPath;
		private readonly NotificationContext _notificationContext;
		public ImagemService(IConfiguration configuration, NotificationContext notificationContext)
		{
			_serverPath = configuration["DireitorioImagens"];
			_notificationContext = notificationContext;
		}

		public async Task<byte[]> CarregarImagem(string guid)
		{
			var pathFile = string.Concat(_serverPath, guid, "\\");

			if (!Directory.Exists(pathFile) || string.IsNullOrEmpty(guid))
				return default;

			return await File.ReadAllBytesAsync(Directory.GetFiles(pathFile).SingleOrDefault());
		}

		public void RemoverImagem(string guid)
		{
			var pathFile = string.Concat(_serverPath, guid.ToString(), "\\");

			if (!Directory.Exists(pathFile))
				_notificationContext.AddNotification("Imagem", "Imagem não encontrada e/ou recurso já foi excluído!");

			if (_notificationContext.Valid)
				Directory.Delete(pathFile, true);
		}

		public async Task<Guid> SalvarImagem(IFormFile file)
		{
			var guid = Guid.NewGuid();
			var pathFile = string.Concat(_serverPath, guid.ToString(), "\\");

			if (!Directory.Exists(pathFile))
				Directory.CreateDirectory(pathFile);

			string path = Path.Combine(pathFile, file.FileName);
			using var stream = new FileStream(path, FileMode.Create);
			await file.CopyToAsync(stream);
			return guid;
		}
	}
}
