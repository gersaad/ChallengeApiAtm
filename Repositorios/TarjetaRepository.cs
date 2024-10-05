using ChallengeApiAtm.Data;
using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeApiAtm.Repositorios
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly AtmDbContext _context;

        public TarjetaRepository(AtmDbContext context)
        {
            _context = context;
        }


        /// <summary>
        ///  Devuelve el Historial de movimientos de cuenta segun numero de Tarjeta
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="nroPagina"></param>
        /// <returns> HistorialOperacionDTO  </returns>
        public async Task<HistorialOperacionDTO> ObtenerHistorialTarjeta(string numeroTarjeta, int nroPagina, int registrosPorPagina)
        {
            var tarjeta = await _context.Tarjetas
                                 .Include(x => x.Cuenta)
                                 .ThenInclude(x => x.Operaciones)
                                 .FirstOrDefaultAsync(x => x.NumeroTarjeta == numeroTarjeta);

            if (tarjeta == null)
            {
                return null;
            }

            var totalOperaciones = tarjeta.Cuenta.Operaciones.Count();
            var paginasTotales = (int)Math.Ceiling(totalOperaciones / (double)registrosPorPagina);

            var operacionesPaginadas = tarjeta.Cuenta.Operaciones
                                   .Skip((nroPagina - 1) * registrosPorPagina)
                                   .Take(registrosPorPagina)
                                   .ToList();

            var operacionResponse = operacionesPaginadas.Select( x => new OperacionResponseDTO
            {
                TipoOperacion = x.Tipo ==TipoOperacion.Extraccion ? "Extracción" : "Depósito",
                Monto = x.Monto,
                Fecha = x.Fecha,
            }
            ).ToList();

            return new HistorialOperacionDTO
            {
                PaginaActual = nroPagina,
                TotalOperaciones = totalOperaciones,
                TotalPaginas = paginasTotales,
                Operaciones = operacionResponse
            };

        }

    }
}
