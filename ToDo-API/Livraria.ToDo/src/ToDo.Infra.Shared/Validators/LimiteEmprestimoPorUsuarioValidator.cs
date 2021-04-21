using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;

namespace ToDo.Infra.Shared.Validators
{
	public class LimiteEmprestimoPorUsuarioValidator : BaseValidator<Notification>
	{
		private readonly IEmprestimoRepository _emprestimoRepository;
		private readonly Emprestimo _emprestimo;

		public LimiteEmprestimoPorUsuarioValidator(IEmprestimoRepository emprestimoRepository, Emprestimo emprestimo)
		{
			_emprestimoRepository = emprestimoRepository;
			_emprestimo = emprestimo;
		}

		public override Notification Validar()
		{
			if (_emprestimoRepository.Filter(e => (e.IdUsuario == _emprestimo.IdUsuario && e.DataDevolucao == null)).Count() >= 2)
				return new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois o usuário já atingiu o limite de 2 empréstimos.");

			return null;
		}
	}
}
