using System;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface IEmprestimoRepository
	{
		Emprestimo Inserir(Emprestimo emprestimo);
		void Alterar(Emprestimo emprestimo);
		Emprestimo BuscarPorId(int id);
		IQueryable<Emprestimo> Filter(Expression<Func<Emprestimo, bool>> predicate);
	}
}
