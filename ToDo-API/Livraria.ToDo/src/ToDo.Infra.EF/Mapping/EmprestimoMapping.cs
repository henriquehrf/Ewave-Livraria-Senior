using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EF.Mapping
{
	public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
	{

		public void Configure(EntityTypeBuilder<Emprestimo> builder)
		{
			builder.ToTable(nameof(Emprestimo));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdUsuario)
				.IsRequired()
			   .HasColumnName("IdUsuario")
			   .HasColumnType("int");

			builder.Property(prop => prop.IdLivro)
				.IsRequired()
			   .HasColumnName("IdLivro")
			   .HasColumnType("int");

			builder.Property(prop => prop.DataEmprestimo)
				.IsRequired()
				.HasColumnName("DataEmprestimo")
				.HasColumnType("Datetime");

			builder.Property(prop => prop.DataPrevistaDevolucao)
				.IsRequired()
			   .HasColumnName("DataPrevistaDevolucao")
			   .HasColumnType("Datetime");


			builder.HasOne(prop => prop.Usuario)
				.WithMany(prop => prop.Emprestimos)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdUsuario);

			builder.HasOne(prop => prop.Livro)
				.WithMany(prop => prop.Emprestimos)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdLivro);

			builder.Property(prop => prop.DataDevolucao)
			   .HasColumnName("DataDevolucao")
			   .HasColumnType("Datetime");
		}
	}
}
