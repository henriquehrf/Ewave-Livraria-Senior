using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class EmprestimoService : IEmprestimoService
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly ILivroRepository _livroRepository;
		private readonly NotificationContext _notificationContext;

		public EmprestimoService(IEmprestimoRepository emprestimoRepository, 
								ILivroRepository livroRepository, 
								NotificationContext notificationContext)
		{
			_emprestimoRepository = emprestimoRepository;
			_livroRepository = livroRepository;
			_notificationContext = notificationContext;
		}

		public void DevolverEmprestimo(int idEmprestimo)
		{
			var emprestimo = _emprestimoRepository.BuscarPorId(idEmprestimo);

			var livro = _livroRepository.BuscarPorId(emprestimo.IdLivro);
			livro.DefinirDisponibilidade(true);

			emprestimo.DevolverEmprestimo();
			_emprestimoRepository.Alterar(emprestimo);
		}

		public Emprestimo Inserir(Emprestimo emprestimo)
		{
			_notificationContext.AddNotifications(emprestimo.Notifications);

			var livro = _livroRepository.BuscarPorId(emprestimo.IdLivro);
			livro.DefinirDisponibilidade(false);

			if (_notificationContext.Valid)
				return _emprestimoRepository.Inserir(emprestimo);

			return emprestimo;
		}
	}
}
