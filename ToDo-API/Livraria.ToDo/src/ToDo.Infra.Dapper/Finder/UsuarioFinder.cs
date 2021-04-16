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
	public class UsuarioFinder : BaseFinder, IUsuarioFinder
	{
		public UsuarioFinder(IOptions<DbProvider> provider):base(provider?.Value?.ConnectionString)
		{
		}

		public async Task<IEnumerable<UsuarioDto>> RetornarUsuarioPorNome(PaginacaoDto pagina, string nome)
		{
			var parametros = new DynamicParameters();
			parametros.Add("@TamanhoPagina", pagina.TamanhoPagina, DbType.Int32);
			parametros.Add("@Pagina", pagina.Pagina, DbType.Int32);
			parametros.Add("@NomeUsuario", nome, DbType.String);

			using (var connection = CreateConnection())
			{
				return await connection.QueryAsync<UsuarioDto>(PaginacaoQuery.RetornarQueryPaginada(UsuarioQuery.BuscarUsuariosPorNome), parametros);
			}
		}
	}
}
