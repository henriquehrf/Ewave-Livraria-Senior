using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IInstituicaoEnsinoService
	{
		InstituicaoEnsino Inserir(InstituicaoEnsino instituicaoEnsino);
		void Alterar(InstituicaoEnsino instituicaoEnsino);
	}
}
