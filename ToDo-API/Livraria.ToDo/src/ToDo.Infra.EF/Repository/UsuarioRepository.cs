using System.Linq;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.Repository
{
	public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
	{
		public UsuarioRepository(ToDoContext toDoContext) : base(toDoContext)
		{
		}

		public Usuario BuscarPorId(int id)
		{
			return base.ById(id);
		}

		void IUsuarioRepository.Alterar(Usuario usuario)
		{
			base.Alterar(usuario);
		}

		Usuario IUsuarioRepository.Inserir(Usuario usuario)
		{
			return base.Inserir(usuario);
		}

		Usuario IUsuarioRepository.UsuarioPorLogin(string login)
		{
			return Filter(u => u.Login.Equals(login) && u.Ativo.Equals(true)).SingleOrDefault();
		}


	}
}
