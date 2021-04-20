using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface ILivroRepository
	{
		Livro Inserir(Livro livro);
		void Alterar(Livro livro);
		Livro BuscarPorId(int id);
	}
}
