using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class DesativarInstituicaoEnsinoValidator : BaseValidator<Notification>
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly InstituicaoEnsino _instituicaoEnsino;

		public DesativarInstituicaoEnsinoValidator(IUsuarioRepository usuarioRepository, InstituicaoEnsino instituicaoEnsino)
		{
			_usuarioRepository = usuarioRepository;
			_instituicaoEnsino = instituicaoEnsino;
		}

		public override Notification Validar()
		{

			if ((!_instituicaoEnsino.Ativo) &&
				_usuarioRepository.Filter(u=> u.IdInstituicaoEnsino == _instituicaoEnsino.Id && u.Ativo).Any())
				return new Notification(string.Empty, "Não pode desativar esta instituição de ensino, pois há usuários ativos vinculado a ela.");

			return null;
		}
	}
}
