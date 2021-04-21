using FluentAssertions;
using Flunt.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Repository;
using ToDo.Infra.Shared.NotificationContext;
using ToDo.Service.Service;
using ToDo.Service.Test.Mocks;
using Xunit;

namespace ToDo.Service.Test
{
	public class SolicitarEmprestimoTest : IDisposable
	{
		private readonly Mock<IUsuarioRepository> _usuarioRepository;
		private readonly Mock<ILivroRepository> _livroRepository;
		private readonly Mock<IEmprestimoRepository> _emprestimoRepository;
		private readonly NotificationContext _notificationContext;

		public SolicitarEmprestimoTest()
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
																	bool EhUmEmprestimoValido,
																	IList<Notification> notifications)
		{
			var emprestimoService = new EmprestimoService(_emprestimoRepository.Object,
											_usuarioRepository.Object,
											_livroRepository.Object,
											_notificationContext);

			emprestimoService.Inserir(emprestimo);
			_notificationContext.Valid.Should().Be(EhUmEmprestimoValido);
			_notificationContext.Notifications.Should().BeEquivalentTo(notifications);

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
			#region UsuarioEmprestimoValidator
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: 3,
							   idLivro:3,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois o usuário encontra-se inativo.") },
			};
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: -1,
							   idLivro:3,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois não foi possível localizar o usuário.") },
			};
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: 2,
							   idLivro:3,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, $"Não é possível efetivar o empréstimo, pois o usuário encontra-se suspenso até {DateTime.Today.AddDays(5).Date}."),
										 new Notification(string.Empty, $"Não é possível efetivar o empréstimo, pois o usuário tem um empréstimo em atraso.")
										 },
			};
			#endregion

			#region DisponibilidadeLivroEmprestimoValidator
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: 1,
							   idLivro:4,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, "Não é possível efetivar o empréstimo deste livro, pois o mesmo encontra-se indisponível.") },
			};
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: 1,
							   idLivro:2,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, "Não é possível efetivar o empréstimo deste livro, pois o mesmo encontra-se indisponível.") },
			};
			#endregion

			#region LimiteEmprestimoPorUsuarioValidator
			yield return new object[]
			{
				new Emprestimo(id:0,
							   idUsuario: 4,
							   idLivro:3,
							   dataEmprestimo:DateTime.MinValue,
							   dataDevolucao:null,
							   dataPrevistaDevolucao: DateTime.MinValue),
				false,
				new List<Notification>(){new Notification(string.Empty, "Não é possível efetivar o empréstimo, pois o usuário já atingiu o limite de 2 empréstimos.") },
			};
			#endregion

		}

		public void Dispose()
		{
			MockUsuarioRepository.Reset();
			MockLivroRepository.Reset();
			MockEmprestimoRepository.Reset();
		}
	}
}
