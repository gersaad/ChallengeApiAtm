using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeApiAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private readonly ICuentaRepository _cuenta;
        public CuentaController(ICuentaRepository cuenta)
        {
            _cuenta = cuenta;
        }

        /// <summary>
        ///  Obtiene el saldo de la cuenta 
        /// </summary>
        /// <param name="numeroTarjeta"></param>
        /// <returns> Informe saldo </returns>
        [Authorize] 
        [HttpGet("Saldo")]
        public async Task<IActionResult> GetSaldo([FromQuery] string numeroTarjeta)
        {
            var saldo = await _cuenta.ObtenerSaldoPorNroTarjeta(numeroTarjeta);
            if (saldo == null)
            {
                return BadRequest("Numero de Tarjeta Invalido");
            }
            return Ok(saldo);
        }

        /// <summary>
        ///  Permite realizar extracciones 
        /// </summary>
        /// <param name="retiro"></param>
        /// <returns> Resumen operacion </returns>
        [Authorize] 
        [HttpPost("Retiro")]
        public async Task<IActionResult> Retiro([FromBody] RetiroDTO retiro)
        {
            var extraccion = await _cuenta.RetiroPorNroTarjeta(retiro);
            if (extraccion == null)
            {
                return BadRequest("Tarjeta Invalida o Saldo Insuficiente");
            }
            return Ok(extraccion);
        }
    }
}
