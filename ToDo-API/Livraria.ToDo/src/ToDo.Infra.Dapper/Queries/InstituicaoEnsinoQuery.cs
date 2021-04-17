using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Infra.Dapper.Queries
{
	public struct InstituicaoEnsinoQuery
	{
		public const string BuscarTodasInstituicoesDropDown = @"
														SELECT	ie.Id,
																ie.Nome
														FROM	InstituicaoEnsino ie
														WHERE	(ie.Ativo = 1)
													";
	}
}
