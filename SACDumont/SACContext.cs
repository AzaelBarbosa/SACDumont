using SACDumont.Models;
using System.Data.Entity;

namespace SACDumont
{
    public class SACContext : DbContext
    {
        public SACContext() : base("name=SACConnectionString")
        {
        }
        public DbSet<ALUMNOS> Alumnos { get; set; }
    }
}
