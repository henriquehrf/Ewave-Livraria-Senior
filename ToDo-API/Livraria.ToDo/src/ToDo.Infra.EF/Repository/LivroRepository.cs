using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.Repository
{
	public class LivroRepository : BaseRepository<Livro, int>, ILivroRepository
	{
		public LivroRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		Livro ILivroRepository.Inserir(Livro livro)
		{
			return base.Inserir(livro);
		}

		void ILivroRepository.Alterar(Livro livro)
		{
			base.Alterar(livro);
		}

		public Livro BuscarPorId(int id)
		{
			return ById(id);
		}
	}
}
