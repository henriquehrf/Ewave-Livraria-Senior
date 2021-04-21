using FluentAssertions;
using Flunt.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Service.Service;
using ToDo.Service.Test.Mocks;
using Xunit;

namespace ToDo.Service.Test
{
	public class DevolverEmprestimoTest : IDisposable
	{
		private readonly Mock<IUsuarioRepository> _usuarioRepository;
		private readonly Mock<ILivroRepository> _livroRepository;
		private readonly Mock<IEmprestimoRepository> _emprestimoRepository;
		private readonly NotificationContext _notificationContext;


		public DevolverEmprestimoTest()
		{
			_usuarioRepository = new Mock<IUsuarioRepository>();
			_livroRepository = new Mock<ILivroRepository>();
			_emprestimoRepository = new Mock<IEmprestimoRepository>();
			_notificationContext = new NotificationContext();

			SetupTest();
		}

		[Theory]
		[MemberData(nameof(ParametrosEsperados))]
		public void AoSolicitarEmprestimoDeveValidarRegraDeNegocio(Emprestimo emprestimo,
																	bool usuarioRecebeSuspensao,
																	DateTime? dataSuspensao)
		{
			var emprestimoService = new EmprestimoService(_emprestimoRepository.Object,
											_usuarioRepository.Object,
											_livroRepository.Object,
											_notificationContext);

			emprestimoService.DevolverEmprestimo(emprestimo.Id);

			_emprestimoRepository.Object
								 .Filter(e => e.Id == emprestimo.Id)
								 .Single()
								 .DataDevolucao.Value.Date.Should().Be(DateTime.Today.Date);

			if (usuarioRecebeSuspensao)
				_usuarioRepository.Object.Filter(u => u.Id == emprestimo.IdUsuario).Single().DataSuspencao.Value.Date.Should().Be(dataSuspensao.Value.Date);

		}

		private void SetupTest()
		{
			_usuarioRepository.Setup(s => s.Filter(It.IsAny<Expression<Func<Usuario, bool>>>()))
							 .Returns<Expression<Func<Usuario, bool>>>(predicate => MockUsuarioRepository.Filter(predicate));

			_usuarioRepository.Setup(s => s.BuscarPorId(It.IsAny<int>()))
							 .Returns((int id) => MockUsuarioRepository.ObterPorId(id));

			_livroRepository.Setup(s => s.BuscarPorId(It.IsAny<int>()))
							 .Returns((int id) => MockLivroRepository.ObterPorId(id));

			_emprestimoRepository.Setup(s => s.Filter(It.IsAny<Expression<Func<Emprestimo, bool>>>()))
							 .Returns<Expression<Func<Emprestimo, bool>>>(predicate => MockEmprestimoRepository.Filter(predicate));

			_emprestimoRepository.Setup(s => s.BuscarPorId(It.IsAny<int>()))
							 .Returns((int id) => MockEmprestimoRepository.ObterPorId(id));
		}

		public static IEnumerable<object[]> ParametrosEsperados()
		{

			yield return new object[]
			{
				new Emprestimo(id:1,
							idUsuario: 1,
							idLivro:1,
							dataEmprestimo: DateTime.Now,
							dataPrevistaDevolucao: DateTime.Now.AddDays(30),
							dataDevolucao: null),
				false,
				null
			};

			yield return new object[]
			{
				new Emprestimo(id:2,
							idUsuario: 2,
							idLivro:2,
							dataEmprestimo: DateTime.Now.AddDays(-60),
							dataPrevistaDevolucao: DateTime.Now.AddDays(-30),
							dataDevolucao: null),
				true,
				DateTime.Now.AddDays(30)
			};
		}

		public void Dispose()
		{
			MockUsuarioRepository.Reset();
			MockLivroRepository.Reset();
			MockEmprestimoRepository.Reset();
		}
	}
}
