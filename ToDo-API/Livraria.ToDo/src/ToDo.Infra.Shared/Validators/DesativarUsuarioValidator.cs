using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class DesativarUsuarioValidator : BaseValidator<Notification>
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly Usuario _usuario;

		public DesativarUsuarioValidator(IEmprestimoRepository emprestimoRepository,
											Usuario usuario)
		{
			_emprestimoRepository = emprestimoRepository;
			_usuario = usuario;
		}

		public override Notification Validar()
		{

			if ((!_usuario.Ativo) &&
				_emprestimoRepository.Filter(e => e.IdUsuario == _usuario.Id && e.DataDevolucao == null).Any())
				return new Notification(string.Empty, "Não pode desativar este usuário possui empréstimos ativos");

			return null;
		}
	}
}
