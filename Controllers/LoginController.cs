using ChallengeApiAtm.DTOs;
using Microsoft.AspNetCore.Mvc;
using ChallengeApiAtm.Repositorios.Interfaces;
using ChallengeApiAtm.Modelos;
using Microsoft.IdentityModel.Tokens;

namespace ChallengeApiAtm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _login;
        public LoginController(ILoginRepository login)
        {
            _login = login;
        }

        /// <summary>
        /// Endpoint Login  
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <returns> Token </returns>
        [HttpPost("Loguear")]
        public async Task<IActionResult> Loguear([FromBody] LoginDTO tarjeta)
        {

            if (string.IsNullOrEmpty(tarjeta.Pin))
            {
                return BadRequest("Pin Invalido");
            }
            if (string.IsNullOrEmpty(tarjeta.NumeroTarjeta))
            {
                return BadRequest("Numero de Tarjeta Invalido");
            }

            string token = await _login.Loguear(tarjeta);
            if (token == null)
            {
                return Unauthorized("Error al generar Token - Tarjeta o PIN incorrectos o tarjeta bloqueada.");
            }

            return Ok(new { Token = token });

        }
    }
}
