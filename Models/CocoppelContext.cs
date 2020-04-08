using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cocoppel.Models
{
    public partial class CocoppelContext : DbContext
    {
        public CocoppelContext()
        {
        }

        public CocoppelContext(DbContextOptions<CocoppelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuentaCheques> CuentaCheques { get; set; }
        public virtual DbSet<LineaCredito> LineaCredito { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public virtual DbSet<TarjetaDebito> TarjetaDebito { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["CocoppelDatabase"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuentaCheques>(entity =>
            {
                entity.HasKey(e => e.IdnumeroDeCuenta);

                entity.Property(e => e.IdnumeroDeCuenta)
                    .HasColumnName("IDNumeroDeCuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.CuentaCheques)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentaCheques_Usuario");
            });

            modelBuilder.Entity<LineaCredito>(entity =>
            {
                entity.HasKey(e => e.IdlineaDeCredito);

                entity.Property(e => e.IdlineaDeCredito).HasColumnName("IDLineaDeCredito");

                entity.Property(e => e.CantidadMaximaDisponible).HasColumnType("money");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.SaldoRestante).HasColumnType("money");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.LineaCredito)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineaCredito_Usuario");
            });

            modelBuilder.Entity<TarjetaCredito>(entity =>
            {
                entity.HasKey(e => e.IdlineaCredito)
                    .HasName("PK_TarjetaDeCredito");

                entity.HasIndex(e => e.IdlineaCredito)
                    .HasName("UK_NumeroTarjetaCredito")
                    .IsUnique();

                entity.Property(e => e.IdlineaCredito)
                    .HasColumnName("IDLineaCredito")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cvv).HasColumnName("CVV");

                entity.Property(e => e.EntidadEmisora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCaducidad).HasColumnType("date");

                entity.Property(e => e.MarcaInternacional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdlineaCreditoNavigation)
                    .WithOne(p => p.TarjetaCredito)
                    .HasForeignKey<TarjetaCredito>(d => d.IdlineaCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarjetaCredito_LineaCredito");
            });

            modelBuilder.Entity<TarjetaDebito>(entity =>
            {
                entity.HasKey(e => e.IdnumeroDeCuenta);

                entity.HasIndex(e => e.Numero)
                    .HasName("UK_NumeroTarjetaDebito")
                    .IsUnique();

                entity.Property(e => e.IdnumeroDeCuenta)
                    .HasColumnName("IDNumeroDeCuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cvv).HasColumnName("CVV");

                entity.Property(e => e.EntidadEmisora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCaducidad).HasColumnType("date");

                entity.Property(e => e.MarcaInternacional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumeroDeCuentaNavigation)
                    .WithOne(p => p.TarjetaDebito)
                    .HasForeignKey<TarjetaDebito>(d => d.IdnumeroDeCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarjetaDebito_CuentaCheques");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.FechaAfiliacion).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
