using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Finder;
using ToDo.Domain.Models.Dtos;
using ToDo.Infra.Dapper.Provider;
using ToDo.Infra.Dapper.Querie;
using ToDo.Infra.Dapper.Queries;

namespace ToDo.Infra.Dapper.Finder
{
	public class InstituicaoEnsinoFinder : BaseFinder, IInstituicaoEnsinoFinder
	{
		public InstituicaoEnsinoFinder(IOptions<DbProvider> provider) : base(provider?.Value?.ConnectionString)
		{
		}

		public async Task<IEnumerable<DropdownDto>> InstituicaoDropdown()
		{

			using (var connection = CreateConnection())
			{
				return await connection.QueryAsync<DropdownDto>(InstituicaoEnsinoQuery.BuscarInstituicoesAtivaDropDown);
			}
		}

		public async Task<IEnumerable<InstituicaoEnsinoDto>> RetornarInstituicaoPorNome(PaginacaoDto paginacao, string nomeInstituicao)
		{
			var parametros = new DynamicParameters();
			parametros.Add("@TamanhoPagina", paginacao.TamanhoPagina, DbType.Int32);
			parametros.Add("@Pagina", paginacao.Pagina, DbType.Int32);
			parametros.Add("@NomeInstituicao", nomeInstituicao, DbType.String);
			using (var connection = CreateConnection())
			{
				return await connection.QueryAsync<InstituicaoEnsinoDto>(PaginacaoQuery.RetornarQueryPaginada(InstituicaoEnsinoQuery.BuscarInstituicoesPorNome), parametros);
			}
		}
	}
}
