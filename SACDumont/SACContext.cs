using SACDumont.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
