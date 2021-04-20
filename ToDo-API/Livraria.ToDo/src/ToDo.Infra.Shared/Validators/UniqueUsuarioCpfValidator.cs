using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class UniqueUsuarioCpfValidator : BaseValidator<Notification>
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly Usuario _usuario;

		public UniqueUsuarioCpfValidator(IUsuarioRepository usuarioRepository, Usuario usuario)
		{
			_usuarioRepository = usuarioRepository;
			_usuario = usuario;
		}

		public override Notification Validar()
		{
			if (_usuarioRepository.Filter(u => u.Cpf.Equals(_usuario.Cpf) &&
										  u.Id != _usuario.Id).Any())
				return new Notification("CPF", $"Já existe um cadastro com o CPF {_usuario.Cpf}.");

			return null;
		}
	}
}
