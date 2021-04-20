namespace ToDo.Infra.Dapper.Queries
{
	public struct EmprestimoQuery
	{
		public const string BuscarEmprestimoAtivo = @"
														SELECT	e.Id,
																e.DataPrevistaDevolucao,
																e.DataEmprestimo,
																l.Id as IdLivro,
																l.Titulo,
																l.Genero,
																l.Autor,
																l.Sinopse,
																l.GuidCapa,
																u.Id as IdUsuario,
																u.Nome
														FROM	Emprestimo e
																INNER JOIN [Livro] l ON
																	l.Id = e.IdLivro
																INNER JOIN [Usuario] u ON
																	u.Id = e.IdUsuario
														WHERE	(e.DataDevolucao IS NULL)
													";

		public const string BuscarEmprestimoAtivoPorUsuario =  BuscarEmprestimoAtivo + " AND	(e.Idusuario = @IdUsuario)";
	}
}
