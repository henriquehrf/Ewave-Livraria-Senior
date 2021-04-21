using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Service.Test.Mocks
{
	public class MockInstituicaoEnsinoRepository : BaseMock<InstituicaoEnsino, MockInstituicaoEnsinoRepository>
	{
		private readonly IList<InstituicaoEnsino> _instituicoesEnsino = new List<InstituicaoEnsino>()
		{
			new InstituicaoEnsino(id: 1,
								  nome: "UFMT",
								  endereco: "Av Fernando Correia da Costa, Nº s/n",
								  cnpj: "97.502.958/0001-01",
								  telefone:"(65) 3452-0000",
								  guidFoto: null,
								  ativo: true),

			new InstituicaoEnsino(id: 2,
								  nome: "IFMT - Campus Cuiabá",
								  endereco: "Rua Professora Zulmira Canavarros 95",
								  cnpj: "97.502.000/0001-01",
								  telefone:"(65) 3318 1526",
								  guidFoto: null,
								  ativo: false),
		};  

		public override IList<InstituicaoEnsino> MassaDeDados => _instituicoesEnsino;
	}
}
