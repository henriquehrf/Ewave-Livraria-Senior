using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;

namespace ToDo.Service.Service
{
	public class EmprestimoService : IEmprestimoService
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public EmprestimoService(IEmprestimoRepository emprestimoRepository, NotificationContext notificationContext)
		{
			_emprestimoRepository = emprestimoRepository;
			_notificationContext = notificationContext;
		}

		public void DevolverEmprestimo(int idEmprestimo, int idUsuario)
		{
			var emprestimo = _emprestimoRepository.BuscarPorId(idEmprestimo);

			emprestimo.DevolverEmprestimo();
			_emprestimoRepository.Alterar(emprestimo);
		}

		public Emprestimo Inserir(Emprestimo emprestimo)
		{
			_notificationContext.AddNotifications(emprestimo.Notifications);

			if (_notificationContext.Valid)
				return _emprestimoRepository.Inserir(emprestimo);

			return emprestimo;
		}
	}
}
