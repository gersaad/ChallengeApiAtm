using ChallengeApiAtm.Data;
using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;
using ChallengeApiAtm.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ChallengeApiAtm.Repositorios
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AtmDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasherRepository _passwordHasher;

        public LoginRepository(AtmDbContext context, IConfiguration configuration, IPasswordHasherRepository passwordHasher)
        {
            _context = context;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Verifica existencia de la Tarjeta y checkea el hash
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <returns> Token o null </returns>
        public async Task<string> Loguear(LoginDTO tarjeta)
        {
            Tarjeta loginTarjeta = await ObtenerTarjetaLogin(tarjeta.NumeroTarjeta);

            if (loginTarjeta == null)
            {
                return null;
            }

            if (loginTarjeta.TarjetaCredencial.Bloqueada)
            {
                return null;
            }

            if (!(_passwordHasher.CheckHash(loginTarjeta.TarjetaCredencial.PinHash, tarjeta.Pin)))
            {
                await PinErroneo(loginTarjeta);
                return null;
            }

            loginTarjeta.TarjetaCredencial.IntentosFallidos = 0;
            await _context.SaveChangesAsync();

            return GenerarToken(loginTarjeta);
        }


        /// <summary>
        /// Obtiene la tarjeta correspondiente a un numero de tarjeta especifico. 
        /// </summary>
        /// <param name="NumeroTarjeta"></param>
        /// <returns></returns>
        private async Task<Tarjeta> ObtenerTarjetaLogin(string NumeroTarjeta)
        {
            return await _context.Tarjetas
                .Include(x => x.TarjetaCredencial)
                .Include(x => x.Cuenta)
                .FirstOrDefaultAsync(x => x.NumeroTarjeta == NumeroTarjeta);

        }

        private async Task PinErroneo(Tarjeta Tarjeta)
        {
            Tarjeta.TarjetaCredencial.IntentosFallidos++;
            if (Tarjeta.TarjetaCredencial.IntentosFallidos >= 4)
            {
                Tarjeta.TarjetaCredencial.Bloqueada = true;
            }
            await _context.SaveChangesAsync();     
        }


        /// <summary>
        ///  Genera token JWT
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <returns></returns>
        private String GenerarToken(Tarjeta tarjeta)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Login:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.Name, tarjeta.Cuenta.NombreUsuario), 
                    new Claim("NumeroTarjeta", tarjeta.NumeroTarjeta),
                    new Claim("CuentaId", tarjeta.Cuenta.Id.ToString()) 
                
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }


    }
}
