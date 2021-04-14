using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EF.Mapping
{
	public class InstituicaoEnsinoMapping : IEntityTypeConfiguration<InstituicaoEnsino>
	{

		public void Configure(EntityTypeBuilder<InstituicaoEnsino> builder)
		{
			builder.ToTable(nameof(InstituicaoEnsino));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Endereco)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Endereco")
			   .HasColumnType("varchar(200)");

			builder.Property(prop => prop.Cnpj)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("CNPJ")
			   .HasColumnType("varchar(18)");

			builder.Property(prop => prop.Telefone)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Telefone")
			   .HasColumnType("varchar(20)");

			builder.Property(prop => prop.GuidFoto)
			   .HasColumnName("GuidFoto")
			   .HasColumnType("Guid");

			builder.Property(prop => prop.Ativo)
			   .IsRequired()
			   .HasColumnName("Ativo")
			   .HasColumnType("bit");

		}
	}
}
