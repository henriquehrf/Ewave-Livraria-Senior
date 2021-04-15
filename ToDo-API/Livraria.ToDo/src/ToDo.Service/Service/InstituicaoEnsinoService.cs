using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class InstituicaoEnsinoService : IInstituicaoEnsinoService
	{
		private readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;
		private readonly NotificationContext _notificationContext;

		public InstituicaoEnsinoService(IInstituicaoEnsinoRepository instituicaoEnsinoRepository,
										NotificationContext notificationContext)
		{
			_instituicaoEnsinoRepository = instituicaoEnsinoRepository;
			_notificationContext = notificationContext;
		}
		public InstituicaoEnsino Inserir(InstituicaoEnsino instituicaoEnsino)
		{
			_notificationContext.AddNotifications(instituicaoEnsino.Notifications);

			if (_notificationContext.Valid)
				return _instituicaoEnsinoRepository.Inserir(instituicaoEnsino);

			return instituicaoEnsino;
		}

		public void Alterar(InstituicaoEnsino instituicaoEnsino)
		{
			_notificationContext.AddNotifications(instituicaoEnsino.Notifications);

			if (_notificationContext.Valid)
				_instituicaoEnsinoRepository.Alterar(instituicaoEnsino);
		}

	}
}
