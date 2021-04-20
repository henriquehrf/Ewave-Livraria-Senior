using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class UniqueLoginUsuarioValidator : BaseValidator<Notification>
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly Usuario _usuario;

		public UniqueLoginUsuarioValidator(IUsuarioRepository usuarioRepository, Usuario usuario)
		{
			_usuarioRepository = usuarioRepository;
			_usuario = usuario;
		}

		public override Notification Validar()
		{
			if (_usuarioRepository.Filter(u => u.Login.Equals(_usuario.Login) &&
										  u.Id != _usuario.Id).Any())
				return new Notification("Login", $"Já existe um cadastro com o Login {_usuario.Login}.");

			return null;
		}
	}
}
