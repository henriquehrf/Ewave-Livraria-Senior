using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.Validators;

namespace ToDo.Service.Service
{
	public class UsuarioService : IUsuarioService
	{

		private readonly IUsuarioRepository _usuarioRepository;
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public UsuarioService(IUsuarioRepository usuarioRepository, IEmprestimoRepository emprestimoRepository, NotificationContext notificationContext)
		{
			_usuarioRepository = usuarioRepository;
			_emprestimoRepository = emprestimoRepository;
			_notificationContext = notificationContext;
		}

		public Usuario Inserir(Usuario usuario)
		{
			_notificationContext.AddNotifications(usuario.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosUsuarioValidator(usuario).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new UniqueUsuarioCpfValidator(_usuarioRepository, usuario).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new UniqueLoginUsuarioValidator(_usuarioRepository, usuario).Validar());

			if (_notificationContext.Valid)
				return _usuarioRepository.Inserir(usuario);

			return usuario;
		}

		public void Alterar(Usuario usuario)
		{
			_notificationContext.AddNotifications(usuario.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new CamposObrigatoriosUsuarioValidator(usuario).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new UniqueUsuarioCpfValidator(_usuarioRepository, usuario).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new UniqueLoginUsuarioValidator(_usuarioRepository, usuario).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new DesativarUsuarioValidator(_emprestimoRepository, usuario).Validar());


			if (_notificationContext.Valid)
				_usuarioRepository.Alterar(usuario);
		}

	}
}
