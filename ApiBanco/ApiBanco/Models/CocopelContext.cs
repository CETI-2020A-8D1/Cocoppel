using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiBanco.Models
{
    public partial class CocopelContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }
        public virtual DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        public virtual DbSet<TarjetaDebito> TarjetaDebito { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=ANGEL;Database=Cocopel;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidoM)
                    .IsRequired()
                    .HasColumnName("Apellido_M")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .IsRequired()
                    .HasColumnName("Apellido_P")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.TarjetaCreditoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.TarjetaCredito)
                    .HasConstraintName("FK_Cliente_TarjetaCredito");

                entity.HasOne(d => d.TarjetaDebitoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.TarjetaDebito)
                    .HasConstraintName("FK_Cliente_TarjetaDebito");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.Property(e => e.IdMovimiento).HasColumnName("ID_movimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TarjetaCredito>(entity =>
            {
                entity.HasKey(e => e.NumeroDeTarjeta);

                entity.Property(e => e.NumeroDeTarjeta).ValueGeneratedNever();

                entity.Property(e => e.Ccv).HasColumnName("CCV");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            });

            modelBuilder.Entity<TarjetaDebito>(entity =>
            {
                entity.HasKey(e => e.NumeroDeTarjeta);

                entity.Property(e => e.NumeroDeTarjeta).ValueGeneratedNever();

                entity.Property(e => e.Ccv).HasColumnName("CCV");

                entity.Property(e => e.FechaVencimiento).HasColumnType("date");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.Property(e => e.IdTransaccion)
                    .HasColumnName("ID_Transaccion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.TarjetaNavigation)
                    .WithMany(p => p.Transaccion)
                    .HasForeignKey(d => d.Tarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaccion_TarjetaCredito");

                entity.HasOne(d => d.Tarjeta1)
                    .WithMany(p => p.Transaccion)
                    .HasForeignKey(d => d.Tarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaccion_TarjetaDebito");

                entity.HasOne(d => d.TipoMovimientoNavigation)
                    .WithMany(p => p.Transaccion)
                    .HasForeignKey(d => d.TipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaccion_Movimiento");
            });
        }
    }
}
