using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface IInstituicaoEnsinoRepository
	{
		InstituicaoEnsino Inserir(InstituicaoEnsino instituicaoEnsino);
		void Alterar(InstituicaoEnsino instituicaoEnsino);
	}
}
