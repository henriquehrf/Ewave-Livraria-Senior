namespace ToDo.Infra.Dapper.Queries
{
	public struct InstituicaoEnsinoQuery
	{
		public const string BuscarInstituicoesAtivaDropDown = @"
														SELECT	ie.Id,
																ie.Nome
														FROM	InstituicaoEnsino ie
														WHERE	(ie.Ativo = 1)
													";

		public const string BuscarInstituicoesPorNome = @"
														SELECT	ROW_NUMBER() OVER(ORDER BY ie.Nome) AS Ordem,
																ie.Id,
																ie.Nome,
																ie.Endereco,
																ie.CNPJ as Cnpj,
																ie.Telefone,
																ie.Ativo
														FROM	InstituicaoEnsino ie
														WHERE	(ie.Nome like '%'+ @NomeInstituicao +'%') OR (@NomeInstituicao is null)
													";
	}
}
