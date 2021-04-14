using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.ValueTypes;

namespace ToDo.Domain.Entities
{
	public class InstituicaoEnsino : BaseEntity<int>
	{
		public InstituicaoEnsino(int id, 
								Nome nome, 
								Endereco endereco, 
								Cnpj cnpj, 
								Telefone telefone,
								Guid? guidFoto,
								bool ativo)
		{
			Id = id;
			Nome = nome;
			Endereco = endereco;
			Cnpj = cnpj;
			Telefone = telefone;
			GuidFoto = guidFoto;
			Ativo = ativo;

			AddNotifications(
				nome.Contract,
				endereco.Contract,
				cnpj.Contract,
				telefone.Contract
				);
		}

		public Nome Nome { get; }
		public Endereco Endereco { get; }
		public Cnpj Cnpj { get; }
		public Telefone Telefone { get; }
		public Guid? GuidFoto { get; }
		public bool Ativo { get; }

		public virtual ICollection<Usuario> Usuarios { get; } = new HashSet<Usuario>();
	}
}
