using System;
using System.Collections.Generic;
using Fictisia.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fictisia.Infraestructure.Context
{
    public partial class Clientes_FictisiaContext : DbContext
    {
        public Clientes_FictisiaContext()
        {
        }

        public Clientes_FictisiaContext(DbContextOptions<Clientes_FictisiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adicionale> Adicionales { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adicionale>(entity =>
            {
                entity.HasKey(e => e.AdicionalesId);

                entity.Property(e => e.AdicionalesId).HasColumnName("adicionalesId");

                entity.Property(e => e.Comentarios).HasColumnName("comentarios");

                entity.Property(e => e.EsDiabetico).HasColumnName("esDiabetico");

                entity.Property(e => e.Maneja).HasColumnName("maneja");

                entity.Property(e => e.OtraEnfermedad).HasColumnName("otraEnfermedad");

                entity.Property(e => e.UsaLentes).HasColumnName("usaLentes");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.ActivoId);

                entity.ToTable("Estado");

                entity.Property(e => e.ActivoId).HasColumnName("activoId");

                entity.Property(e => e.Activo).HasColumnName("activo");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.PersonaId).HasColumnName("personaId");

                entity.Property(e => e.ActivoId).HasColumnName("activoId");

                entity.Property(e => e.AdicionalesId).HasColumnName("adicionalesId");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.Activo)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.ActivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Estado");

                entity.HasOne(d => d.Adicionales)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.AdicionalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Adicionales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
