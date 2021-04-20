using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Finder;
using ToDo.Domain.Models.Dtos;
using ToDo.Infra.Dapper.Provider;
using ToDo.Infra.Dapper.Queries;

namespace ToDo.Infra.Dapper.Finder
{
	public class EmprestimoFinder : BaseFinder, IEmprestimoFinder
	{
		public EmprestimoFinder(IOptions<DbProvider> provider) : base(provider?.Value?.ConnectionString)
		{
		}
		public async Task<IEnumerable<EmprestimoDto>> BuscarEmprestimoAtivoPorUsuario(int idUsuario)
		{
			var parametros = new DynamicParameters();
			parametros.Add("@IdUsuario", idUsuario, DbType.Int32);
			using (var connection = CreateConnection())
			{
				var result = await connection.QueryAsync<EmprestimoDto, LivroDto, UsuarioDto, EmprestimoDto>(EmprestimoQuery.BuscarEmprestimoAtivoPorUsuario,
					(emprestimo, livro, usuario) =>
					{
						emprestimo.Livro = livro;
						emprestimo.Usuario = usuario;

						return emprestimo;
					},
					parametros,
					splitOn : "IdLivro, IdUsuario"
					);

				return result;
			}
		}

		public async Task<IEnumerable<EmprestimoDto>> TodosAtivo()
		{
			using (var connection = CreateConnection())
			{
				var result = await connection.QueryAsync<EmprestimoDto, LivroDto, UsuarioDto, EmprestimoDto>(EmprestimoQuery.BuscarEmprestimoAtivo,
					(emprestimo, livro, usuario) =>
					{
						emprestimo.Livro = livro;
						emprestimo.Usuario = usuario;

						return emprestimo;
					},
					splitOn: "IdLivro, IdUsuario"
					);

				return result;
			}
		}
	}
}
