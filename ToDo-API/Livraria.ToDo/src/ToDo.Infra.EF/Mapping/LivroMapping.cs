using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EF.Mapping
{
	public class LivroMapping : IEntityTypeConfiguration<Livro>
	{
		public void Configure(EntityTypeBuilder<Livro> builder)
		{
			builder.ToTable(nameof(Livro));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Titulo)
			   .IsRequired()
			   .HasColumnName("Titulo")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Genero)
			   .IsRequired()
			   .HasColumnName("Genero")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Autor)
			   .IsRequired()
			   .HasColumnName("Autor")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Sinopse)
			   .IsRequired()
			   .HasColumnName("Sinopse")
			   .HasColumnType("varchar(200)");

			builder.Property(prop => prop.GuidCapa)
			   .IsRequired()
			   .HasColumnName("GuidCapa")
			   .HasColumnType("uniqueidentifier");

			builder.Property(prop => prop.Ativo)
			   .IsRequired()
			   .HasColumnName("Ativo")
			   .HasColumnType("bit");



		}
	}
}
