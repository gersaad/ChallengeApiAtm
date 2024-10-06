using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Repositorios;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.OpenApi.Validations;
using ChallengeApiAtm.Modelos;
using System.Security.Claims;
using ChallengeApiAtm.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeApiAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaRepository _tarjeta;
        public TarjetaController(ITarjetaRepository tarjeta , IReadClaimService readClaimService)
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
        [HttpGet("Historial")]
        public async Task<IActionResult> GetHistorialTarjeta([FromQuery] int nroPagina = 1, [FromQuery] int registrosPorPagina = 10 )
        {
            try
            {
                var historial = await _tarjeta.ObtenerHistorialTarjeta(nroPagina, registrosPorPagina);
                return Ok(historial);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
