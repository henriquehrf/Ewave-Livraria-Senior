using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class DesativarLivroValidator : BaseValidator<Notification>
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly Livro _livro;

		public DesativarLivroValidator(IEmprestimoRepository emprestimoRepository, Livro livro)
		{
			_emprestimoRepository = emprestimoRepository;
			_livro = livro;
		}

		public override Notification Validar()
		{

			if ((!_livro.Ativo) &&
				_emprestimoRepository.Filter(e => e.IdUsuario == _livro.Id && e.DataDevolucao == null).Any())
				return new Notification(string.Empty, "Não pode desativar este livro possui empréstimos ativos");

			return null;
		}
	}
}
