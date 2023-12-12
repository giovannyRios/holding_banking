using System;
using System.Collections.Generic;
using Api.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;

public partial class ExerciseOneContext : DbContext
{
    public ExerciseOneContext()
    {
    }

    public ExerciseOneContext(DbContextOptions<ExerciseOneContext> options)
        : base(options)
    {
    }

	public virtual DbSet<Literal_a> VistaRespuestaLiteral_a { get; set; }

	public virtual DbSet<Literal_b> VistaRespuestaLiteral_b { get; set; }

	public virtual DbSet<Literal_c> VistaRespuestaLiteral_c { get; set; }

	public virtual DbSet<Literal_d> VistaRespuestaLiteral_d { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Literal_a>(entity =>
		{
			entity.HasNoKey()
				.ToTable("LITERAL_A");

			entity.Property(e => e.department_name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Literal_b>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("LITERAL_B");

			entity.Property(e => e.department_name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Literal_c>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("LITERAL_C");

			entity.Property(e => e.department_name)
				.HasMaxLength(101)
				.IsUnicode(false);
			entity.Property(e => e.project_name)
				.HasMaxLength(50)
				.IsUnicode(false);
		});

		modelBuilder.Entity<Literal_d>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("LITERAL_D");

			entity.Property(e => e.nameEmployee)
				.HasMaxLength(100)
				.IsUnicode(false);
			entity.Property(e => e.project_name)
				.HasMaxLength(100)
				.IsUnicode(false);
		});
		OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
