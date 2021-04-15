using System;
using ToDo.Domain.Interfaces.UnitOfWork;
using ToDo.Infra.Data.EF.Context;

namespace ToDo.Infra.Data.EF.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly ToDoContext _todoContext;

		public UnitOfWork(ToDoContext todoContext)
		{
			_todoContext = todoContext;
		}

		public void Commit()
		{
			_todoContext.SaveChanges();
		}

		public void Dispose()
		{
			_todoContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
