using SACDumont.Models;
using System.Data.Entity;
using System.Configuration;

namespace SACDumont
{
    public class DumontContext : DbContext
    {

        const string ENV_DEFAULT = "Dev";

        public DumontContext() : base("name=" + ConnName("DumontConnectionString"))
        {
        }

        private static string ConnName(string baseName)
        {
            return $"{baseName}.{ENV_DEFAULT}";
        }

        public DbSet<cobros> MovimientoCobros { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }
        public DbSet<movimiento_productos> MovimientoProductos { get; set; }
        public DbSet<Becas> Becas { get; set; }
        public DbSet<Promociones> Promociones { get; set; }
        public DbSet<Promociones_Alumnos> PromocionesAlumnos { get; set; }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Tutores> Tutores { get; set; }
        public DbSet<Tutores_Alumnos> TutoresAlumnos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Producto_Ciclo> ProductoCiclo { get; set; }
        public DbSet<Ciclos_Escolares> CiclosEscolares { get; set; }
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<catalogos> Catalogos { get; set; }
        public DbSet<perfiles> Perfiles { get; set; }
        public DbSet<permisos_perfiles> PermisosPerfiles { get; set; }
        public DbSet<cierre_diario> CierreDiario { get; set; }
        public DbSet<config> Config { get; set; }
        public DbSet<config_equipos> ConfigEquipos { get; set; }
        public DbSet<saldo_favor> SaldoFavor { get; set; }
        public DbSet<saldo_mov> SaldoMovimiento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<config>().ToTable("Config");

            // Configure entity properties and relationships here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
