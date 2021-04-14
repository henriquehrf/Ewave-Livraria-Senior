using System;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Domain.Entities;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.Repository
{
	public class BaseRepository<T, K> where T : BaseEntity<K>
	{
		protected readonly ToDoContext _todoContext;

		public BaseRepository(ToDoContext ToDoContext)
		{
			_todoContext = ToDoContext;
		}

		protected virtual T Inserir(T obj)
		{
			_todoContext.Add(obj);
			return obj;
		}

		protected virtual T Alterar(T obj)
		{
			_todoContext.Update(obj);
			return obj;
		}

		protected virtual T Excluir(int id)
		{
			var obj = ById(id);
			if (obj != null)
				_todoContext.Remove(obj);

			return obj;
		}

		protected virtual IQueryable<T> Todos()
		{
			return _todoContext.Set<T>();

		}

		protected virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
		{
			return _todoContext.Set<T>().Where(predicate);
		}

		protected virtual T ById(int id)
		{
			var obj = _todoContext.Set<T>().Find(id);

			return obj;
		}

	}
}
