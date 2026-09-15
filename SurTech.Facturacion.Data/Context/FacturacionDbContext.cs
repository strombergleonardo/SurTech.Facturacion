using Microsoft.EntityFrameworkCore;
using SurTech.Facturacion.Core.Entities;

namespace SurTech.Facturacion.Data.Context
{
    // Heredamos de DbContext para obtener las funciones de Entity Framework
    public class FacturacionDbContext : DbContext
    {
        // -------------------------------------------------------------
        // 1. TABLAS DE LA BASE DE DATOS (DbSet)
        // -------------------------------------------------------------
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EntidadComercial> EntidadesComerciales { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<ComprobanteDetalle> ComprobantesDetalles { get; set; }

        // -------------------------------------------------------------
        // 2. CONFIGURACIÓN DE CONEXIÓN A SQLITE
        // -------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Le indicamos que cree un archivo SQLite local llamado "SurTechBD.db"
            optionsBuilder.UseSqlite("Data Source=SurTechBD.db");
        }

        // -------------------------------------------------------------
        // 3. SEMBRADO DE DATOS INICIALES (Data Seeding)
        // -------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo explícito de claves primarias
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<EntidadComercial>().HasKey(e => e.IdEntidad);
            modelBuilder.Entity<Articulo>().HasKey(a => a.IdArticulo);
            modelBuilder.Entity<Comprobante>().HasKey(c => c.IdComprobante);
            modelBuilder.Entity<ComprobanteDetalle>().HasKey(cd => cd.IdDetalle);

            // Sembrado inicial del Profesor
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    NombreUsuario = "ProfesorAdmin",
                    ClaveHash = "123456",
                    Rol = "Profesor"
                }
            );
        }
    }
}