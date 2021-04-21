using System;
using System.Collections.Generic;
using ToDo.Domain.Entities;
using ToDo.Domain.Enum;

namespace ToDo.Service.Test.Mocks
{
	public class MockUsuarioRepository : BaseMock<Usuario, MockUsuarioRepository>
	{
		private readonly static IList<Usuario> _usuarios = new List<Usuario>()
		{
			new Usuario(id:1,
						nome:"Henrique R. Firmino",
						endereco: "Rua dos testes",
						cpf:"055.820.632-02",
						telefone:"(65) 99661-8401",
						email: "henrique_rfirmino@hotmail.com",
						login:"henrique",
						senha:"123",
						dataSuspencao: null,
						idInstituicaoEnsino:  1,
						perfilUsuario: (int)PerfilUsuarioEnum.Administrador,
						guidFoto: null,
						ativo: true),

			new Usuario(id:2,
						nome:"José das Couves",
						endereco: "Rua das lavouras",
						cpf:"053.820.632-02",
						telefone:"(65) 99861-8401",
						email: "couve.couve@gmail.com",
						login:"couve",
						senha:"123",
						dataSuspencao: DateTime.Now.AddDays(5),
						idInstituicaoEnsino:  1,
						perfilUsuario: (int)PerfilUsuarioEnum.Administrador,
						guidFoto: null,
						ativo: true),

			new Usuario(id:3,
						nome:"Giulia Bueno",
						endereco: "Av. das nações",
						cpf:"053.882.632-02",
						telefone:"(65) 99061-8401",
						email: "giulia.bueno@hotmail.com",
						login:"giulia",
						senha:"123",
						dataSuspencao: null,
						idInstituicaoEnsino:  1,
						perfilUsuario: (int)PerfilUsuarioEnum.Administrador,
						guidFoto: null,
						ativo: false),

			new Usuario(id:4,
						nome:"João João",
						endereco: "Rua das lavouras",
						cpf:"284.820.632-02",
						telefone:"(65) 98861-8401",
						email: "joao.joao@gmail.com",
						login:"joao",
						senha:"123",
						dataSuspencao: null,
						idInstituicaoEnsino:  1,
						perfilUsuario: (int)PerfilUsuarioEnum.Administrador,
						guidFoto: null,
						ativo: true),
		};

		public override IList<Usuario> MassaDeDados => _usuarios;
	}
}
