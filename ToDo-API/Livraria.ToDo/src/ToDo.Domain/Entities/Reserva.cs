using System;

namespace ToDo.Domain.Entities
{
	public class Reserva : BaseEntity<int>
	{
		public Reserva(int id, int idUsuario, int idLivro, DateTime dataReserva, bool ativo)
		{
			Id = id;
			IdUsuario = idUsuario;
			IdLivro = idLivro;
			DataReserva = dataReserva;
			Ativo = ativo;
		}

		public int IdUsuario { get; }
		public int IdLivro { get; }
		public DateTime DataReserva { get; }
		public bool Ativo { get; }

		public virtual Usuario Usuario { get; }
		public virtual Livro Livro { get; }
	}
}
