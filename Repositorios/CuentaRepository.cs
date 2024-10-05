using ChallengeApiAtm.Data;
using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApiAtm.Repositorios
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AtmDbContext _context;

        public CuentaRepository(AtmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///   Obtiene saldo de cuenta por numero de tarjeta
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns> Informe de saldo </returns>
        public async Task<SaldoResponseDTO> ObtenerSaldoPorNroTarjeta(string numeroTarjeta){

            var cuenta = await ObtenerCuentaPorNroTarjeta(numeroTarjeta);
            if (cuenta == null)
            {
                return null;
            }

            var UtlimaExtraccion = cuenta.Operaciones.Where(x => x.Tipo == TipoOperacion.Extraccion).OrderByDescending(x => x.Fecha).FirstOrDefault();

            return new SaldoResponseDTO { 
            
                NombreUsuario = cuenta.NombreUsuario,
                NumeroCuenta = cuenta.NumeroCuenta,
                Saldo = cuenta.Saldo,
                FechaUltimaExtraccion = UtlimaExtraccion?.Fecha
            };
        }


        /// <summary>
        ///   Obtiene cuenta por numero de tarjeta
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns> </returns>
        private async Task<Cuenta> ObtenerCuentaPorNroTarjeta(string numeroTarjeta)
        {
            return await _context.Cuentas
                                 .Include(x => x.Tarjeta)
                                 .Include(x => x.Operaciones)
                                 .FirstOrDefaultAsync(c => c.Tarjeta.NumeroTarjeta == numeroTarjeta);
        }


        /// <summary>
        ///   Realizar extraccion por numero de tarjeta
        /// </summary>
        /// <param name="retiro"></param>
        /// <returns> Resumen Operacion </returns>
        public async Task<RetiroResponseDTO> RetiroPorNroTarjeta(RetiroDTO retiro)
        {
            var cuenta = await ObtenerCuentaPorNroTarjeta(retiro.NumeroTarjeta);
            if (cuenta == null)
            {
                return null;
            }

            var fechaOperacion = DateTime.Now;

            if (retiro.Monto > cuenta.Saldo)
            {
                return null;
            }
            else 
            {
                var extraccion = new Operacion
                {
                    Monto = retiro.Monto,
                    Fecha = fechaOperacion,
                    Tipo = TipoOperacion.Extraccion,
                    CuentaId = cuenta.Id,
                };
                cuenta.Operaciones.Add(extraccion);
                cuenta.Saldo = cuenta.Saldo - retiro.Monto;

                await _context.SaveChangesAsync();
            }

            return new RetiroResponseDTO
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                MontoRetirado = retiro.Monto,
                SaldoRestante = cuenta.Saldo,
                FechaOperacion = fechaOperacion,
                EstadoOperacion = "Operacion exitosa"
            };
        }
    }
}
