using System;
using System.Linq;
using System.Linq.Expressions;
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

		IQueryable<Usuario> IUsuarioRepository.Filter(Expression<Func<Usuario, bool>> predicate)
		{
			return Filter(predicate);
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
