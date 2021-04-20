using System;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Interfaces.Repository
{
	public interface IUsuarioRepository
	{
		Usuario Inserir(Usuario usuario);
		void Alterar(Usuario usuario);
		Usuario BuscarPorId(int id);
		Usuario UsuarioPorLogin(string login);
		IQueryable<Usuario> Filter(Expression<Func<Usuario, bool>> predicate);
	}
}
