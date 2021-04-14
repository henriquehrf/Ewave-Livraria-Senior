using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.UnitOfWork;
using ToDo.Infra.Data.EF.Mapping;

namespace ToDo.Infra.Data.EF.Context
{
	public class ToDoContext : DbContext, IUnitOfWork
	{
		public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Livro> Livro { get; set; }
		public DbSet<Emprestimo> Emprestimo { get; set; }
		public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
		public DbSet<Reserva> Reserva { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
			modelBuilder.Entity<InstituicaoEnsino>(new InstituicaoEnsinoMapping().Configure);
			modelBuilder.Entity<Livro>(new LivroMapping().Configure);
			modelBuilder.Entity<Emprestimo>(new EmprestimoMapping().Configure);
			modelBuilder.Entity<Reserva>(new ReservaMapping().Configure);


			var entites = Assembly
				.Load("ToDo.Domain")
				.GetTypes()
				.Where(w => w.Namespace == "ToDo.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

			foreach (var item in entites)
			{
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
			}
		}

		public void Commit()
		{
			SaveChanges();
		}

		void IDisposable.Dispose()
		{
			Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
