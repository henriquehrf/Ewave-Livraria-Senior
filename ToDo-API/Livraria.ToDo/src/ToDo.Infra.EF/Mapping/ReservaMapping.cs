using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Data.EF.Mapping
{
	public class ReservaMapping : IEntityTypeConfiguration<Reserva>
	{

		public void Configure(EntityTypeBuilder<Reserva> builder)
		{
			builder.ToTable(nameof(Reserva));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdUsuario)
				.IsRequired()
			   .HasColumnName("IdUsuario")
			   .HasColumnType("int");

			builder.Property(prop => prop.IdLivro)
				.IsRequired()
			   .HasColumnName("IdLivro")
			   .HasColumnType("int");

			builder.Property(prop => prop.DataReserva)
				.IsRequired()
			   .HasColumnName("DataReserva")
			   .HasColumnType("datetime");

			builder.Property(prop => prop.Ativo)
				.IsRequired()
			   .HasColumnName("Ativo")
			   .HasColumnType("bit");

			builder.HasOne(prop => prop.Usuario)
				.WithMany(prop => prop.Reservas)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdUsuario);

			builder.HasOne(prop => prop.Livro)
				.WithMany(prop => prop.Reservas)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdLivro);

		}
	}
}
