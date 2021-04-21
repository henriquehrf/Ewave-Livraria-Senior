using System;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Domain.Interfaces.Service;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Infra.Shared.Validators;

namespace ToDo.Service.Service
{
	public class EmprestimoService : IEmprestimoService
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly ILivroRepository _livroRepository;
		private readonly NotificationContext _notificationContext;

		public EmprestimoService(IEmprestimoRepository emprestimoRepository,
								IUsuarioRepository usuarioRepository,
								 ILivroRepository livroRepository,
								NotificationContext notificationContext)
		{
			_emprestimoRepository = emprestimoRepository;
			_usuarioRepository = usuarioRepository;
			_livroRepository = livroRepository;
			_notificationContext = notificationContext;
		}

		public void DevolverEmprestimo(int idEmprestimo)
		{
			var emprestimo = _emprestimoRepository.BuscarPorId(idEmprestimo);
			var usuarioEmprestimo = _usuarioRepository.BuscarPorId(emprestimo.IdUsuario);

			emprestimo.DefinirDataDevolucao();

			if (emprestimo.DataPrevistaDevolucao.Date < DateTime.Today)
				usuarioEmprestimo.DefinirDataSuspencaoUsuario(emprestimo.DataDevolucao.Value.AddDays(30));
		}

		public Emprestimo Inserir(Emprestimo emprestimo)
		{
			_notificationContext.AddNotifications(emprestimo.Notifications);
			_notificationContext.AddNotificationsIgnoreIsEmpty(new UsuarioEmprestimoValidator(_usuarioRepository, _emprestimoRepository, emprestimo).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new DisponibilidadeLivroEmprestimoValidator(_livroRepository, _emprestimoRepository, emprestimo).Validar());
			_notificationContext.AddNotificationIgnoreIsEmpty(new LimiteEmprestimoPorUsuarioValidator(_emprestimoRepository, emprestimo).Validar());

			emprestimo.DefinirDataEmprestimo();
			emprestimo.DefinirDataPrevistaDevolucao();

			if (_notificationContext.Valid)
				return _emprestimoRepository.Inserir(emprestimo);

			return emprestimo;
		}
	}
}
