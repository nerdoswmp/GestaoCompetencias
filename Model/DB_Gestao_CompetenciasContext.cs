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
                optionsBuilder.UseSqlServer("Server=" + Environment.MachineName + ";Database=DB_Gestao_Competencias;Trusted_Connection=True;");
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

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TurmaId).HasColumnName("TurmaID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Aprendizes)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Aprendiz__LoginI__286302EC");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Aprendizes)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK__Aprendiz__TurmaI__29572725");
            });

            modelBuilder.Entity<AprendizCompetencia>(entity =>
            {
                entity.ToTable("Aprendiz_Competencias");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.AprendizId).HasColumnName("AprendizID");

                entity.Property(e => e.CompetenciasId).HasColumnName("CompetenciasID");

                entity.HasOne(d => d.Aprendiz)
                    .WithMany(p => p.AprendizCompetencias)
                    .HasForeignKey(d => d.AprendizId)
                    .HasConstraintName("FK__Aprendiz___Apren__38996AB5");

                entity.HasOne(d => d.Competencias)
                    .WithMany(p => p.AprendizCompetencias)
                    .HasForeignKey(d => d.CompetenciasId)
                    .HasConstraintName("FK__Aprendiz___Compe__398D8EEE");
            });

            modelBuilder.Entity<Competencia>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Competencia)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Competenc__Mater__35BCFE0A");
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

                entity.Property(e => e.MateriaId).HasColumnName("MateriaID");

                entity.Property(e => e.ProfessorId).HasColumnName("ProfessorID");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.MateriaProfessores)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Materia_P__Mater__3D5E1FD2");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.MateriaProfessores)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK__Materia_P__Profe__3C69FB99");
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

                entity.Property(e => e.TurmaId).HasColumnName("TurmaID");

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

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Professores)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Professor__Login__2C3393D0");
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

                entity.Property(e => e.ProfessorId).HasColumnName("ProfessorID");

                entity.Property(e => e.TurmaId).HasColumnName("TurmaID");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.TurmaProfessores)
                    .HasForeignKey(d => d.ProfessorId)
                    .HasConstraintName("FK__Turma_Pro__Profe__2F10007B");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.TurmaProfessores)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK__Turma_Pro__Turma__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
