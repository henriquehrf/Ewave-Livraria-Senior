using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.Repository
{
	public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino, int>, IInstituicaoEnsinoRepository
	{
		public InstituicaoEnsinoRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		InstituicaoEnsino IInstituicaoEnsinoRepository.Inserir(InstituicaoEnsino instituicaoEnsino)
		{
			return base.Inserir(instituicaoEnsino);
		}

		void IInstituicaoEnsinoRepository.Alterar(InstituicaoEnsino instituicaoEnsino)
		{
			base.Alterar(instituicaoEnsino);
		}
	}
}
