using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IUsuarioService
	{
		Usuario Inserir(Usuario usuario);
		void Alterar(Usuario usuario);
	}
}
