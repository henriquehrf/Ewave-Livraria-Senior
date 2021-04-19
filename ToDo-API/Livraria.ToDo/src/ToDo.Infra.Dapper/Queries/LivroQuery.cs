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
																l.Disponibilidade,
																l.Reservado,
																l.Ativo
														FROM	Livro l
														WHERE	(l.Titulo like '%'+ @Titulo +'%') OR (@Titulo is null)
													";
	}
}
