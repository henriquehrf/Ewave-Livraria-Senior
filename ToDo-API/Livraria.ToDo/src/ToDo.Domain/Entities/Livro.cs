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
					bool disponivel,
					bool reservado,
					bool ativo)
		{
			Id = id;
			Titulo = titulo;
			Genero = genero;
			Autor = autor;
			Sinopse = sinopse;
			Disponivel = disponivel;
			Reservado = reservado;
			Ativo = ativo;
			GuidCapa = guidCapa;
		}

		public string Titulo { get; private set; }
		public string Genero { get; private set; }
		public string Autor { get; private set; }
		public string Sinopse { get; private set; }
		public Guid GuidCapa { get; private set; }
		public bool Disponivel { get; private set; }
		public bool Reservado { get; private set; }
		public bool Ativo { get; private set; }

		public void DefinirDisponibilidade(bool disponibilidade)
		{
			Disponivel = disponibilidade;
		}

		public void DefinirReservado(bool reservado)
		{
			Reservado = reservado;
		}

		public virtual ICollection<Emprestimo> Emprestimos { get; } = new HashSet<Emprestimo>();
		public virtual ICollection<Reserva> Reservas { get; } = new HashSet<Reserva>();

	}
}
