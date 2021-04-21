using System;
using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Service.Test.Mocks
{
	public class MockEmprestimoRepository : BaseMock<Emprestimo, MockEmprestimoRepository>
	{

		private readonly static IList<Emprestimo> _emprestimos = new List<Emprestimo>()
		{
			new Emprestimo(id:1,
							idUsuario: 1,
							idLivro:1,
							dataEmprestimo: DateTime.Now,
							dataPrevistaDevolucao: DateTime.Now.AddDays(30),
							dataDevolucao: null),
			new Emprestimo(id:2,
							idUsuario: 2,
							idLivro:2,
							dataEmprestimo: DateTime.Now.AddDays(-60),
							dataPrevistaDevolucao: DateTime.Now.AddDays(-30),
							dataDevolucao: null),

			new Emprestimo(id:3,
							idUsuario: 4,
							idLivro:5,
							dataEmprestimo: DateTime.Now,
							dataPrevistaDevolucao: DateTime.Now.AddDays(30),
							dataDevolucao: null),

			new Emprestimo(id:3,
							idUsuario: 4,
							idLivro:6,
							dataEmprestimo: DateTime.Now,
							dataPrevistaDevolucao: DateTime.Now.AddDays(30),
							dataDevolucao: null)

		};

		public override IList<Emprestimo> MassaDeDados => _emprestimos;
	}
}
