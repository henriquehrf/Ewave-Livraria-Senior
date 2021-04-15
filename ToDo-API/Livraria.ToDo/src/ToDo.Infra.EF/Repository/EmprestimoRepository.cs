using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.Repository
{
	public class EmprestimoRepository : BaseRepository<Emprestimo, int>, IEmprestimoRepository
	{
		public EmprestimoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public Emprestimo BuscarPorId(int id)
		{
			return ById(id);
		}

		Emprestimo IEmprestimoRepository.Inserir(Emprestimo emprestimo)
		{
			return base.Inserir(emprestimo);
		}

		void IEmprestimoRepository.Alterar(Emprestimo emprestimo)
		{
			base.Alterar(emprestimo);
		}
	}
}
