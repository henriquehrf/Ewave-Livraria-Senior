namespace ToDo.Infra.Dapper.Queries
{
	public struct LivroQuery
	{
		public const string BuscarLivroPorTitulo = @"
														SELECT	ROW_NUMBER() OVER(ORDER BY l.Titulo) AS Ordem,
																l.Id,
																l.Titulo,
																l.Genero,
																l.Autor,
																l.Sinopse,
																l.GuidCapa,
																CASE WHEN(l.Ativo = 0) THEN
																	0
																ELSE
																	ISNULL((
																			SELECT	TOP 1 0
																			FROM	Emprestimo e
																			WHERE	(e.IdLivro = l.Id)
																			AND		(e.DataDevolucao IS NULL)
																		), 1)
																END as Disponibilidade,
																ISNULL((
																		SELECT	TOP 1 1
																		FROM	Reserva r
																		WHERE	(r.IdLivro = l.Id)
																		AND		(r.Ativo = 1)
																	), 0) as Reservado,
																l.Ativo
														FROM	Livro l
														WHERE	(l.Titulo like '%'+ @Titulo +'%') OR (@Titulo is null)
													";
	}
}
