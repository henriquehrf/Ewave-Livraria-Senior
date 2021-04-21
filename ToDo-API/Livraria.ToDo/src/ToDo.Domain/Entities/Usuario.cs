using System;
using System.Collections.Generic;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class Usuario : BaseEntity<int>
	{
		public Usuario(int id,
					   Nome nome,
					   Endereco endereco,
					   Cpf cpf,
					   Telefone telefone,
					   Email email,
					   string login,
					   string senha,
					   DateTime? dataSuspencao,
					   int idInstituicaoEnsino,
					   int perfilUsuario,
					   Guid? guidFoto,
					   bool ativo)
		{
			Id = id;
			Nome = nome;
			Endereco = endereco;
			Cpf = cpf;
			Telefone = telefone;
			Email = email;
			Login = login;
			Senha = senha;
			DataSuspencao = dataSuspencao;
			IdInstituicaoEnsino = idInstituicaoEnsino;
			PerfilUsuario = perfilUsuario;
			GuidFoto = guidFoto;
			Ativo = ativo;

			AddNotifications(
				nome.Contract,
				endereco.Contract,
				cpf._contract,
				telefone.Contract,
				email._contract);
		}

		public Nome Nome { get; private set; }
		public Endereco Endereco { get; private set; }
		public Cpf Cpf { get; private set; }
		public Telefone Telefone { get; private set; }
		public Email Email { get; private set; }
		public string Login { get; private set; }
		public string Senha { get; private set; }
		public DateTime? DataSuspencao { get; private set; }
		public int PerfilUsuario { get; private set; }
		public Guid? GuidFoto { get; private set; }
		public int IdInstituicaoEnsino { get; private set; }
		public bool Ativo { get; private set; }

		public virtual InstituicaoEnsino InstituicaoEnsino { get; }
		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();
		public virtual ICollection<Reserva> Reservas { get; } = new HashSet<Reserva>();


		public void DefinirDataSuspencaoUsuario(DateTime data)
		{
			DataSuspencao = data;
		}

	}
}
