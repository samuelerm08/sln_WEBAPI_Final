using Microsoft.EntityFrameworkCore;
using SWProvincias_Rivera.Models;

namespace SWProvincias_Rivera.Data
{
    public class DbPaisContext : DbContext
    {
        public DbPaisContext(DbContextOptions<DbPaisContext> options) : base(options) { }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
