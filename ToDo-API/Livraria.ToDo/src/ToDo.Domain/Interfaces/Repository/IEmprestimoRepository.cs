using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface IEmprestimoRepository
	{
		Emprestimo Inserir(Emprestimo emprestimo);

		void Alterar(Emprestimo emprestimo);

		Emprestimo BuscarPorId(int id);
	}
}
