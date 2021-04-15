using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface IUsuarioRepository
	{
		Usuario Inserir(Usuario usuario);
		//void Alterar(UsuarioModel usuario);
		//void Excluir(int id);
		//UsuarioModel UsuarioPorLogin(string login);
		//UsuarioModel UsuarioPorId(int id);
		//IEnumerable<UsuarioModel> Todos();
		//IEnumerable<UsuarioModel> UsuarioPorNome(string nome);
	}
}
