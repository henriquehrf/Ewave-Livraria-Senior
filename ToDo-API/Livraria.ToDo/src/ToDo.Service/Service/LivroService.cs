using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.Validators;

namespace ToDo.Service.Service
{
	public class LivroService : ILivroService
	{
		private readonly ILivroRepository _livroRepository;
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public LivroService(ILivroRepository livroRepository,
							IEmprestimoRepository emprestimoRepository,
							NotificationContext notificationContext)
		{
			_livroRepository = livroRepository;
			_emprestimoRepository = emprestimoRepository;
			_notificationContext = notificationContext;
		}

		public Livro Inserir(Livro livro)
		{
			_notificationContext.AddNotifications(livro.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosLivroValidator(livro).Validar());

			if (_notificationContext.Valid)
				return _livroRepository.Inserir(livro);

			return livro;
		}

		public void Alterar(Livro livro)
		{
			_notificationContext.AddNotifications(livro.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosLivroValidator(livro).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new DesativarLivroValidator(_emprestimoRepository, livro).Validar());

			if (_notificationContext.Valid)
				_livroRepository.Alterar(livro);
		}
	}
}
