using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDo.Infra.Dapper.Finder
{
	public class BaseFinder
	{
		protected readonly string ConnectionString;

		public BaseFinder(string connectionString) => ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

		protected virtual IDbConnection CreateConnection() => new SqlConnection(ConnectionString);
	}
}
