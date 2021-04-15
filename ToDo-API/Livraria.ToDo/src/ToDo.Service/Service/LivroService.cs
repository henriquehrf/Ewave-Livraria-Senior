using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class LivroService : ILivroService
	{
		private readonly ILivroRepository _livroRepository;
		private readonly NotificationContext _notificationContext;

		public LivroService(ILivroRepository livroRepository, 
							NotificationContext notificationContext)
		{
			_livroRepository = livroRepository;
			_notificationContext = notificationContext;
		}
		public Livro Inserir(Livro livro)
		{
			_notificationContext.AddNotifications(livro.Notifications);

			if (_notificationContext.Valid)
				return _livroRepository.Inserir(livro);

			return livro;
		}

		public void Alterar(Livro livro)
		{
			_notificationContext.AddNotifications(livro.Notifications);

			if (_notificationContext.Valid)
				_livroRepository.Alterar(livro);
		}
	}
}
