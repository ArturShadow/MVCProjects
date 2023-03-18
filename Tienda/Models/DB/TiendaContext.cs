using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Models.DB;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Tienda;uid=sa;Password=Sh1roubon#;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.CodArticulo);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NombreArticulo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente);

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Empresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Puesto)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => new { e.Cliente, e.Articulo });

            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.ArticuloNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.Articulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Articulo");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
