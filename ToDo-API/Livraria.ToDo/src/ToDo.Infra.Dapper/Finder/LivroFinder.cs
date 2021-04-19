using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Finder;
using ToDo.Domain.Models.Dtos;
using ToDo.Infra.Dapper.Provider;
using ToDo.Infra.Dapper.Querie;
using ToDo.Infra.Dapper.Queries;

namespace ToDo.Infra.Dapper.Finder
{
	public class LivroFinder : BaseFinder, ILivroFinder
	{
		public LivroFinder(IOptions<DbProvider> provider) : base(provider?.Value?.ConnectionString)
		{
		}

		public async Task<IEnumerable<LivroDto>> RetornarLivroPorTitulo(PaginacaoDto pagina, string titulo)
		{
			var parametros = new DynamicParameters();
			parametros.Add("@TamanhoPagina", pagina.TamanhoPagina, DbType.Int32);
			parametros.Add("@Pagina", pagina.Pagina, DbType.Int32);
			parametros.Add("@Titulo", titulo, DbType.String);
			using (var connection = CreateConnection())
			{
				return await connection.QueryAsync<LivroDto>(PaginacaoQuery.RetornarQueryPaginada(LivroQuery.BuscarLivroPorTitulo), parametros);
			}
		}
	}
}
