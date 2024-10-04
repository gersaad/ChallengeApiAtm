using ChallengeApiAtm.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ChallengeApiAtm.Data
{
    public class AtmDbContext : DbContext
    {
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<TarjetaCredencial> TarjetaCredenciales { get; set; }

        public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options)
        {
        }     
    }
}
