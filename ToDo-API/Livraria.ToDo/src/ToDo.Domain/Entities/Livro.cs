using System;
using System.Collections.Generic;

namespace ToDo.Domain.Entities
{
	public class Livro : BaseEntity<int>
	{
		public Livro(int id,
					string titulo,
					string genero,
					string autor,
					string sinopse,
					Guid guidCapa,
					bool ativo)
		{
			Id = id;
			Titulo = titulo;
			Genero = genero;
			Autor = autor;
			Sinopse = sinopse;
			Ativo = ativo;
			GuidCapa = guidCapa;
		}

		public string Titulo { get; }
		public string Genero { get; }
		public string Autor { get; }
		public string Sinopse { get; }
		public Guid GuidCapa { get; }
		public bool Ativo { get; }

		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();
		public virtual ICollection<Reserva> Reservas { get; } = new HashSet<Reserva>();

	}
}
