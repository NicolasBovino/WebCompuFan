using Microsoft.EntityFrameworkCore;
using MVCBasico.Models;
using WebCompuFan.Models;

namespace MVCBasico.Context
{
    public class CompuFanDatabaseContext : DbContext
    {
        public CompuFanDatabaseContext(DbContextOptions<CompuFanDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Articulo> Articulo { get; set; }


    }
}

