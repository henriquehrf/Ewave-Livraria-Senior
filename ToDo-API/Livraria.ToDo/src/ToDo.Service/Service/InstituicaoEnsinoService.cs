using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.Validators;

namespace ToDo.Service.Service
{
	public class InstituicaoEnsinoService : IInstituicaoEnsinoService
	{
		private readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly NotificationContext _notificationContext;

		public InstituicaoEnsinoService(IInstituicaoEnsinoRepository instituicaoEnsinoRepository,
										IUsuarioRepository usuarioRepository,
										NotificationContext notificationContext)
		{
			_instituicaoEnsinoRepository = instituicaoEnsinoRepository;
			_usuarioRepository = usuarioRepository;
			_notificationContext = notificationContext;
		}

		public InstituicaoEnsino Inserir(InstituicaoEnsino instituicaoEnsino)
		{
			_notificationContext.AddNotifications(instituicaoEnsino.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosInstituicaoEnsinoValidator(instituicaoEnsino).Validar());

			if (_notificationContext.Valid)
				return _instituicaoEnsinoRepository.Inserir(instituicaoEnsino);

			return instituicaoEnsino;
		}

		public void Alterar(InstituicaoEnsino instituicaoEnsino)
		{
			_notificationContext.AddNotifications(instituicaoEnsino.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosInstituicaoEnsinoValidator(instituicaoEnsino).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new DesativarInstituicaoEnsinoValidator(_usuarioRepository, instituicaoEnsino).Validar());


			if (_notificationContext.Valid)
				_instituicaoEnsinoRepository.Alterar(instituicaoEnsino);
		}

	}
}
