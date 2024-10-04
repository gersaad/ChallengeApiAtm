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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>().ToTable("Cuenta");
            modelBuilder.Entity<Operacion>().ToTable("Operacion");
            modelBuilder.Entity<Tarjeta>().ToTable("Tarjeta");
            modelBuilder.Entity<TarjetaCredencial>().ToTable("TarjetaCredencial");
        }
    }
}
