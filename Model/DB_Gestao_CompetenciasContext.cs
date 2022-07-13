using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestaoCompetencias.Models
{
    public partial class DB_Gestao_CompetenciasContext : DbContext
    {
        public DB_Gestao_CompetenciasContext()
        {
        }

        public DB_Gestao_CompetenciasContext(DbContextOptions<DB_Gestao_CompetenciasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aprendiz> Aprendizes { get; set; } = null!;
        public virtual DbSet<AprendizCompetencia> AprendizCompetencias { get; set; } = null!;
        public virtual DbSet<Competencia> Competencias { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<MateriaProfessor> MateriaProfessores { get; set; } = null!;
        public virtual DbSet<Materia> Materias { get; set; } = null!;
        public virtual DbSet<Professor> Professores { get; set; } = null!;
        public virtual DbSet<Turma> Turmas { get; set; } = null!;
        public virtual DbSet<TurmaProfessor> TurmaProfessores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JVLPC0587\\SQLExpress;Database=DB_Gestao_Competencias;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aprendiz>(entity =>
            {
                entity.ToTable("Aprendiz");

                entity.HasKey(e => e.Id);
                 
                entity.Property(e => e.Edv)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(e => e.Login);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Turma);
            });

            modelBuilder.Entity<AprendizCompetencia>(entity =>
            {
                entity.ToTable("Aprendiz_Competencias");

                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Aprendiz);

                entity.HasOne(d => d.Competencias);
            });

            modelBuilder.Entity<Competencia>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.HasOne(d => d.Materia);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Senha)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MateriaProfessor>(entity =>
            {
                entity.ToTable("Materia_Professor");

                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Materia);

                entity.HasOne(d => d.Professor);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DataDeFim).HasColumnType("date").IsRequired();

                entity.Property(e => e.DataDeInicio).HasColumnType("date").IsRequired();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(280)
                    .IsUnicode(false).IsRequired();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false).IsRequired();

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Materias);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Identificador)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login);
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("Turma");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.DataDeFim).HasColumnType("date");

                entity.Property(e => e.DataDeInicio).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TurmaProfessor>(entity =>
            {
                entity.ToTable("Turma_Professor");

                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.TurmaProfessores);

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.TurmaProfessores);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
