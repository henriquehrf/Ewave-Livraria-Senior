using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDo.Domain.Entities;

namespace ToDo.Service.Test.Mocks
{
	public abstract class BaseMock<T, K>
	{
		private static IList<T> _massaDeDadosSaida;
		public abstract IList<T> MassaDeDados { get; }
		
		private static IList<T> MassaDeDadosSaida
		{
			get
			{
				if (_massaDeDadosSaida == null)
					_massaDeDadosSaida = ObterDados();
				return _massaDeDadosSaida;
			}
		}

		public static void Reset()
		{
			_massaDeDadosSaida = null;
		}

		public static T ObterPorId(int id) => MassaDeDadosSaida.SingleOrDefault(p => (p as BaseEntity<int>).Id.Equals(id));

		public static IQueryable<T> Filter(Expression<Func<T, bool>> predicate) => MassaDeDadosSaida.AsQueryable().Where(predicate);

		private static IList<T> ObterDados()
		{
			if (Activator.CreateInstance<K>() is BaseMock<T, K> t)
				return t.MassaDeDados;

			return default;
		}
	}
}
