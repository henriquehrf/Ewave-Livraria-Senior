using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class UsuarioService : IUsuarioService
	{

		private readonly IUsuarioRepository _usuarioRepository;
		private readonly NotificationContext _notificationContext;

		public UsuarioService(IUsuarioRepository usuarioRepository, NotificationContext notificationContext)
		{
			_usuarioRepository = usuarioRepository;
			_notificationContext = notificationContext;
		}

		public Usuario Inserir(Usuario usuario)
		{
			_notificationContext.AddNotifications(usuario.Notifications);

			if (_notificationContext.Valid)
				return _usuarioRepository.Inserir(usuario);

			return usuario;
		}

		public void Alterar(Usuario usuario)
		{
			_notificationContext.AddNotifications(usuario.Notifications);

			if (_notificationContext.Valid)
				_usuarioRepository.Alterar(usuario);
		}

	}
}
