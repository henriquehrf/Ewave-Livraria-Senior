using System;

namespace ToDo.Domain.Entities
{
	public class Emprestimo : BaseEntity<int>
	{
		public Emprestimo(int id, 
						  int idUsuario, 
						  int idLivro, 
						  DateTime dataEmprestimo, 
						  DateTime? dataDevolucao, 
						  DateTime dataPrevistaDevolucao 
						  )
		{
			Id = id;
			IdUsuario = idUsuario;
			IdLivro = idLivro;
			DataEmprestimo = dataEmprestimo;
			DataDevolucao = dataDevolucao;
			DataPrevistaDevolucao = dataPrevistaDevolucao;
		}

		public int IdUsuario { get; private set; }
		public int IdLivro { get; private set; }
		public DateTime DataEmprestimo { get; private set; }
		public DateTime? DataDevolucao { get; private set; }
		public DateTime DataPrevistaDevolucao { get; private set; }
		public virtual Usuario Usuario { get; private set; }
		public virtual Livro Livro { get; private set; }

		public void DefinirDataEmprestimo()
		{
			DataEmprestimo = DateTime.Now;
		}

		public void DefinirDataPrevistaDevolucao()
		{
			DataPrevistaDevolucao = DateTime.Now.AddDays(30);
		}

		public void DefinirDataDevolucao()
		{
			DataDevolucao = DateTime.Now;
		}
	}
}
