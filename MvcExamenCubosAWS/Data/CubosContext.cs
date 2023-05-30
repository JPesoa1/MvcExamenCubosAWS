using Microsoft.EntityFrameworkCore;
using MvcExamenCubosAWS.Models;

namespace MvcExamenCubosAWS.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options)
        {
        }

        public DbSet<Cubo> Cubos { get; set; }
    }
}
