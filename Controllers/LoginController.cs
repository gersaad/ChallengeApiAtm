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

            try
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
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
