using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Repositorios;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeApiAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly ITarjetaRepository _tarjeta;
        public TarjetaController(ITarjetaRepository tarjeta)
        {
            _tarjeta = tarjeta;
        }

        /// <summary>
        ///   Permite ver el historial de movimientos de la cuenta de la tarjeta ingresada
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <param name="nroPagina"></param>
        /// <returns> Historial Movimientos </returns>
        [Authorize] 
        [HttpGet("Historial/{numeroTarjeta}")]
        public async Task<IActionResult> GetHistorialTarjeta(string numeroTarjeta, [FromQuery] int nroPagina = 1, [FromQuery] int registrosPorPagina = 10 )
        {
            var historial = await _tarjeta.ObtenerHistorialTarjeta(numeroTarjeta, nroPagina, registrosPorPagina);
            if (historial == null)
            {
                return BadRequest("Numero de Tarjeta Invalido o no tiene movimientos");
            }
            return Ok(historial);
        }

    }
}
