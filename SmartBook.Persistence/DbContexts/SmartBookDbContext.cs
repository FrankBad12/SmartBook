using SmartBook.Domain.Entities;
using SmartBook.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace SmartBook.Persistence.DbContexts
{
    public class SmartBookDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }

        public SmartBookDbContext(DbContextOptions<SmartBookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la tabla Usuarios
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                // Convertir ENUMs de MySQL a ENUMs de C#
                entity.Property(e => e.Rol)
                    .HasConversion<string>()
                    .HasColumnType("ENUM('Admin','Vendedor')");

                entity.Property(e => e.Activo)
                    .HasConversion<string>()
                    .HasColumnType("ENUM('Activo','Inactivo')");

                // Mapear nombres de columnas explícitamente
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Identificacion).HasColumnName("identificacion");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.ContrasenaHash).HasColumnName("contrasena_hash");
                entity.Property(e => e.Rol).HasColumnName("rol");
                entity.Property(e => e.CuentaConfirmada).HasColumnName("cuenta_confirmada");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
                entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            });

            // Configurar relaciones de Venta
            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasOne(v => v.Usuario)
                    .WithMany(u => u.VentasRealizadas)
                    .HasForeignKey(v => v.UsuarioId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(v => v.Cliente)
                    .WithMany(c => c.Ventas)
                    .HasForeignKey(v => v.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurar relaciones de Ingreso
            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasOne(i => i.Libro)
                    .WithMany(l => l.Ingresos)
                    .HasForeignKey(i => i.LibroId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Lote)
                    .WithMany(l => l.Ingresos)
                    .HasForeignKey(i => i.LoteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}