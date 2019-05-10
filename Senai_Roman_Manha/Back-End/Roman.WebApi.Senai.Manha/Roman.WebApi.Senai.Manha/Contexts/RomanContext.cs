using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Roman.WebApi.Senai.Manha.Domains
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipe> Equipe { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'dbo.USER_PROJ'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SENAI_DESAFIO_ROMAN; user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipe>(entity =>
            {
                entity.ToTable("EQUIPE");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__EQUIPE__E2AB1FF4E7022C4B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.Estado1)
                    .HasName("UQ__ESTADO__541A11CCF1EB2386")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado1)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.ToTable("PROJETOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("DATA_CRIACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");

                entity.Property(e => e.IdTema).HasColumnName("ID_TEMA");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__PROJETOS__ID_EST__66603565");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__PROJETOS__ID_TEM__656C112C");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.ToTable("TEMA");

                entity.HasIndex(e => e.Tema1)
                    .HasName("UQ__TEMA__B7FF44CEF2B98863")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tema1)
                    .IsRequired()
                    .HasColumnName("TEMA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.ToTable("TIPO_USUARIOS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPO_USU__E2AB1FF44B5B4548")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724CD7E444B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdEquipe).HasColumnName("ID_EQUIPE");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEquipeNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEquipe)
                    .HasConstraintName("FK__USUARIOS__ID_EQU__6D0D32F4");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__6E01572D");
            });
        }
    }
}
