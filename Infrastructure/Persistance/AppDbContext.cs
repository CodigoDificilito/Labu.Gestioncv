using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<PerfilCV> PerfilCV { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<TipoEstudio> TipoEstudio { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<Habilidad> Habilidad { get; set; }
        public DbSet<Adjunto> Adjunto { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilCV>(entity =>
            {
                entity.ToTable("PerfilCV");
                entity.HasKey(pcvi => pcvi.PerfilCVId);
                entity.Property(pcvi => pcvi.PerfilCVId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ai => ai.AspiranteId)
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                      .IsRequired()
                      .HasMaxLength(500);
                entity.Property(sm => sm.SalarioMinimo);
                entity.Property(i => i.Imagen);

                entity.HasOne<Adjunto>(a=>a.Adjunto)
                      .WithOne(pcv=>pcv.PerfilCV)
                      .HasForeignKey<PerfilCV>(pcv=>pcv.PerfilCVId);

                entity.HasMany<Estudios>(e => e.Estudios)
                      .WithOne(pcv=>pcv.PerfilCV)
                      .HasForeignKey(pcv=>pcv.PerfilCVId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Experiencia>(e => e.Experiencia)
                      .WithOne(pcv => pcv.PerfilCV)
                      .HasForeignKey(pcv => pcv.PerfilCVId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Habilidad>(h => h.Habilidad)
                      .WithOne(pcv => pcv.PerfilCV)
                      .HasForeignKey(pcv => pcv.PerfilCVId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.ToTable("Estudios");
                entity.HasKey(ei => ei.EstudioId);
                entity.Property(ei => ei.EstudioId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ai => ai.PerfilCVId)
                      .IsRequired();
                entity.Property(tei => tei.TipoEstudioId)
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(fi => fi.FechaInicio)
                      .IsRequired();
                entity.Property(ff => ff.FechaFin)
                      .IsRequired();

                entity.HasOne<TipoEstudio>(te => te.TipoEstudio)
                      .WithOne(pcv => pcv.Estudios)
                      .HasForeignKey<TipoEstudio>(tei => tei.TipoEstudioId);

                entity.HasOne<PerfilCV>(pcv=>pcv.PerfilCV)
                      .WithMany(e=>e.Estudios)
                      .HasForeignKey(pcvi=>pcvi.PerfilCVId);
            });

            modelBuilder.Entity<TipoEstudio>(entity =>
            {
                entity.ToTable("TipoEstudio");
                entity.HasKey(tei => tei.TipoEstudioId);
                entity.Property(tei => tei.TipoEstudioId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(n => n.Nombre)
                     .IsRequired()
                     .HasMaxLength(500);

                entity.HasOne<Estudios>(e => e.Estudios)
                      .WithOne(te => te.TipoEstudio)
                      .HasForeignKey<TipoEstudio>(tei => tei.TipoEstudioId);

                entity.HasData(
                        new TipoEstudio
                        {
                            TipoEstudioId = 1,
                            Nombre = "Primaria"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 2,
                            Nombre = "Secundaria"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 3,
                            Nombre = "Terciario"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 4,
                            Nombre = "Universitario"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 5,
                            Nombre = "Posgrado"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 6,
                            Nombre = "Master"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 7,
                            Nombre = "Doctorado"
                        },
                        new TipoEstudio
                        {
                            TipoEstudioId = 8,
                            Nombre = "Curso"
                        }
                    );
            });

            modelBuilder.Entity<Habilidad>(entity =>
            {
                entity.ToTable("Habilidad");
                entity.HasKey(hi => hi.HabilidadId);
                entity.Property(hi => hi.HabilidadId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ai => ai.PerfilCVId)
                      .IsRequired();
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasOne<PerfilCV>(pcv => pcv.PerfilCV)
                      .WithMany(h => h.Habilidad)
                      .HasForeignKey(pcvi => pcvi.PerfilCVId);
            });

            modelBuilder.Entity<Experiencia>(entity =>
            {
                entity.ToTable("Experiencia");
                entity.HasKey(ei => ei.ExperienciaId);
                entity.Property(ei => ei.ExperienciaId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ai => ai.PerfilCVId)
                       .IsRequired();
                entity.Property(d => d.Descripcion)
                     .IsRequired()
                     .HasMaxLength(100);
                entity.Property(fi => fi.FechaInicio)
                       .IsRequired();
                entity.Property(ff => ff.FechaFin)
                      .IsRequired();

                entity.HasOne<PerfilCV>(pcv => pcv.PerfilCV)
                      .WithMany(e => e.Experiencia)
                      .HasForeignKey(pcvi => pcvi.PerfilCVId);
            });

            modelBuilder.Entity<Adjunto>(entity =>
            {
                entity.ToTable("Adjunto");
                entity.HasKey(ai => ai.AdjuntoId);
                entity.Property(ai => ai.AdjuntoId)
                      .ValueGeneratedOnAdd()
                      .IsRequired();
                entity.Property(ai => ai.PerfilCVId)
                       .IsRequired();
                entity.Property(p => p.Presentacion)
                     .HasMaxLength(255);
                entity.Property(p => p.Presentacion)
                     .HasMaxLength(255);

                entity.HasOne<PerfilCV>(pcv => pcv.PerfilCV)
                      .WithOne(a => a.Adjunto)
                      .HasForeignKey<PerfilCV>(pcv => pcv.PerfilCVId);
            });
        }
    }
}
