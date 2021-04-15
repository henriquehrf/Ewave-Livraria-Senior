using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Service
{
	public interface ILivroService
	{
		Livro Inserir(Livro livro);
		void Alterar(Livro livro);
	}
}
