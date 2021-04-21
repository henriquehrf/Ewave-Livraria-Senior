using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class UsuarioEmprestimoValidator : BaseValidator<IList<Notification>>
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly Emprestimo _emprestimo;

		public UsuarioEmprestimoValidator(IUsuarioRepository usuarioRepository, 
										IEmprestimoRepository emprestimoRepository, 
										Emprestimo emprestimo)
		{
			_usuarioRepository = usuarioRepository;
			_emprestimoRepository = emprestimoRepository;
			_emprestimo = emprestimo;
		}

		public override IList<Notification> Validar()
		{
			var validacoes = new List<Notification>();
			var usuarioEmprestimo = _usuarioRepository.BuscarPorId(_emprestimo.IdUsuario);

			if (usuarioEmprestimo == null)
			{
				validacoes.Add(new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois não foi possível localizar o usuário."));
				return validacoes;
			}

			if (!usuarioEmprestimo.Ativo)
				validacoes.Add(new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois o usuário encontra-se inativo."));

			if (usuarioEmprestimo.DataSuspencao.HasValue && usuarioEmprestimo.DataSuspencao.Value.Date >= DateTime.Today)
				validacoes.Add(new Notification(string.Empty, $"Não é possível efetivar o empréstimo, pois o usuário encontra-se suspenso até {usuarioEmprestimo.DataSuspencao.Value.Date}."));

			if (_emprestimoRepository.Filter(e=> ((e.IdUsuario == _emprestimo.IdUsuario) && 
											     (e.DataPrevistaDevolucao.Date < DateTime.Today &&
												 (e.DataDevolucao == null)))).Any())
				validacoes.Add(new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois o usuário tem um empréstimo em atraso."));


			return validacoes;
		}
	}
}
