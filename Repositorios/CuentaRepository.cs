using ChallengeApiAtm.Data;
using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;
using ChallengeApiAtm.Repositorios.Interfaces;
using ChallengeApiAtm.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ChallengeApiAtm.Repositorios
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AtmDbContext _context;
        private readonly IReadClaimService _readClaimService;
        private readonly string _numeroTarjetaLogin;
        public CuentaRepository(AtmDbContext context, IReadClaimService readClaimService)
        {
            _context = context;
            _readClaimService = readClaimService;
            _numeroTarjetaLogin = _readClaimService.ObtejerNumeroTarjetaLogueado();
        }


        /// <summary>
        ///   Obtiene saldo de cuenta por numero de tarjeta
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns> Informe de saldo </returns>
        public async Task<SaldoResponseDTO> ObtenerSaldo(){

            var cuenta = await ObtenerCuenta();
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
        private async Task<Cuenta> ObtenerCuenta()
        {
            return await _context.Cuentas
                                 .Include(x => x.Tarjeta)
                                 .Include(x => x.Operaciones)
                                 .FirstOrDefaultAsync(c => c.Tarjeta.NumeroTarjeta == _numeroTarjetaLogin);
        }


        /// <summary>
        ///   Realizar extraccion por numero de tarjeta
        /// </summary>
        /// <param name="retiro"></param>
        /// <returns> Resumen Operacion </returns>
        public async Task<RetiroResponseDTO> Retiro(decimal monto)
        {
            var cuenta = await ObtenerCuenta();
            if (cuenta == null)
            {
                return null;
            }

            var fechaOperacion = DateTime.Now;

            if (monto > cuenta.Saldo)
            {
                return null;
            }
            else 
            {
                var extraccion = new Operacion
                {
                    Monto = monto,
                    Fecha = fechaOperacion,
                    Tipo = TipoOperacion.Extraccion,
                    CuentaId = cuenta.Id,
                };
                cuenta.Operaciones.Add(extraccion);
                cuenta.Saldo = cuenta.Saldo - monto;

                await _context.SaveChangesAsync();
            }

            return new RetiroResponseDTO
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                MontoRetirado = monto,
                SaldoRestante = cuenta.Saldo,
                FechaOperacion = fechaOperacion,
                EstadoOperacion = "Operacion exitosa"
            };
        }
    }
}
