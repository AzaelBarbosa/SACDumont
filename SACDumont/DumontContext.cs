using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SACDumont.Models; // Assuming you have a Models namespace for your entity models

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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure entity properties and relationships here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
