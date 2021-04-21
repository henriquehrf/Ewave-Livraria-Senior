using System;
using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Service.Test.Mocks
{
	public class MockLivroRepository : BaseMock<Livro, MockLivroRepository>
	{
		private readonly IList<Livro> _livros = new List<Livro>()
		{
			new Livro(id:1,
					  titulo: "Design Patterns com C#",
					  genero: "Programação",
					  autor:"Rodrigo Gonçalves Santana",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:true),

			new Livro(id:2,
					  titulo: "Web Services REST com ASP .NET Web API e Windows Azure",
					  genero: "Programação",
					  autor:"Paulo Siécola",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:true),

			new Livro(id:3,
					  titulo: "Test-Driven Development 1º Edição",
					  genero: "Programação",
					  autor:"Mauricio Aniche",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:true),

			new Livro(id:4,
					  titulo: "Test-Driven Development 2º Edição",
					  genero: "Programação",
					  autor:"Mauricio Aniche",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:false),

			new Livro(id:5,
					  titulo: "Web Services REST com ASP .NET Web API e Amazon AWS",
					  genero: "Programação",
					  autor:"Paulo Siécola",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:true),

			new Livro(id:6,
					  titulo: "Design Patterns com Java( C# > Java)",
					  genero: "Programação",
					  autor:"Rodrigo Gonçalves Santana",
					  sinopse:"...",
					  guidCapa: Guid.Parse("EA647A93-0B98-4974-977F-61CF3FC8D8BB"),
					  ativo:true)
		};

		public override IList<Livro> MassaDeDados => _livros;
	}
}
