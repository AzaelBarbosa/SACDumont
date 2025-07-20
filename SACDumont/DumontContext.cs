using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SACDumont.Models;
using SACDumont.modulos; // Assuming you have a Models namespace for your entity models

namespace SACDumont
{
    public class DumontContext : DbContext
    {
        public DumontContext() : base("name=DumontConnectionString")
        {
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure entity properties and relationships here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
