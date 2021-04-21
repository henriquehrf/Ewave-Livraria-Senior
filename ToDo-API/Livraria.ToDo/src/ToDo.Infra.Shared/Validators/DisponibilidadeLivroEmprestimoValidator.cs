using Flunt.Notifications;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class DisponibilidadeLivroEmprestimoValidator : BaseValidator<Notification>
	{
		private readonly ILivroRepository _livroRepository;
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly Emprestimo _emprestimo;

		public DisponibilidadeLivroEmprestimoValidator(ILivroRepository livroRepository, IEmprestimoRepository emprestimoRepository, Emprestimo emprestimo)
		{
			_livroRepository = livroRepository;
			_emprestimoRepository = emprestimoRepository;
			_emprestimo = emprestimo;
		}

		public override Notification Validar()
		{
			if (!(_livroRepository.BuscarPorId(_emprestimo.IdLivro).Ativo) ||
				(_emprestimoRepository.Filter(e => (e.IdLivro == _emprestimo.IdLivro) && (e.DataDevolucao == null)).Any()))
				return new Notification(string.Empty, "Não é possível efetivar o empréstimo deste livro, pois o mesmo encontra-se indisponível.");


			return null;
		}
	}
}
