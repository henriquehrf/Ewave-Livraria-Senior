using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public int IdUsuario { get; }
		public int IdLivro { get; }
		public DateTime DataEmprestimo { get; }
		public DateTime? DataDevolucao { get; }
		public DateTime DataPrevistaDevolucao { get; }
		public virtual Usuario Usuario { get; }
		public virtual Livro Livro { get; }
	}
}
