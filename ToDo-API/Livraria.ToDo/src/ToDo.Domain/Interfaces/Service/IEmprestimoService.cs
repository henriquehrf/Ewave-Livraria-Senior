using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IEmprestimoService
	{
		Emprestimo Inserir(Emprestimo emprestimo);

		void DevolverEmprestimo(int idEmprestimo);
	}
}
