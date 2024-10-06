using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Repositorios.Interfaces;
using ChallengeApiAtm.Servicios;
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
        public CuentaController(ICuentaRepository cuenta , IReadClaimService readClaimService)
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
        public async Task<IActionResult> GetSaldo()
        {
            try
            {
                var saldo = await _cuenta.ObtenerSaldo();
                return Ok(saldo);
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        ///  Permite realizar extracciones 
        /// </summary>
        /// <param name="retiro"></param>
        /// <returns> Resumen operacion </returns>
        [Authorize] 
        [HttpPost("Retiro")]
        public async Task<IActionResult> Retiro([FromQuery] decimal Monto)
        {
            try
            {
                var extraccion = await _cuenta.Retiro(Monto);
                return Ok(extraccion);
            }
            catch (Exception ex )
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
