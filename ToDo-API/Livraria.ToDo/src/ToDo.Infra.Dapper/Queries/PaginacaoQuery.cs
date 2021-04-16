namespace ToDo.Infra.Dapper.Querie
{
	public static class PaginacaoQuery
	{
		private const string QueryPaginada = @"
											SELECT	* 
											FROM	({0}) AS TAB
											WHERE	Ordem BETWEEN ((@Pagina - 1) * @TamanhoPagina + 1) AND (@Pagina * @TamanhoPagina)
									";

		public static string RetornarQueryPaginada(string query)
		{

			return string.Format(QueryPaginada, query);
		}
	}
}
