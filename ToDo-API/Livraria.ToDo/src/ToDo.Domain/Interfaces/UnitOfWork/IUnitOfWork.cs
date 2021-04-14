using System;

namespace ToDo.Domain.Interfaces.UnitOfWork
{
	public interface IUnitOfWork: IDisposable
	{
		void Commit();
	}
}
