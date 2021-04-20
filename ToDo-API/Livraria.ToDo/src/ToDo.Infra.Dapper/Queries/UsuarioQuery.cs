namespace ToDo.Infra.Dapper.Queries
{
	public struct UsuarioQuery 
	{
		public const string BuscarUsuariosPorNome = @"
														SELECT	ROW_NUMBER() OVER(ORDER BY u.Nome) AS Ordem,
																u.Id,
																u.Nome,
																u.Cpf,
																u.Telefone,
																u.Email,
																ie.Id as IdInstituicaoEnsino,
																ie.Nome as InstituicaoEnsinoDescricao,
																u.Endereco,
																u.PerfilUsuario,
																u.Login,
																u.Senha,
																u.Ativo
														FROM	Usuario u
															INNER JOIN InstituicaoEnsino ie on
																ie.Id = u.idInstituicaoEnsino
														WHERE	(u.Nome like '%'+ @NomeUsuario +'%') OR (@NomeUsuario is null)
													";
	}
}
