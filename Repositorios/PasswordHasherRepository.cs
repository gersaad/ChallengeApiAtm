using ChallengeApiAtm.Repositorios.Interfaces;
using ChallengeApiAtm.Tools;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace ChallengeApiAtm.Repositorios
{
    public class PasswordHasherRepository : IPasswordHasherRepository
    {
        private readonly PasswordHashingConfig _config;
        public PasswordHasherRepository(IOptions<PasswordHashingConfig> config)
        {
            _config = config.Value;
        }


        /// <summary>
        /// Revisa que el PIN ingresado sea correcto o no, comparando con el PINHash de la tarjeta.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="password"></param>
        /// <returns> True or False </returns>
        public bool CheckHash(string hash, string password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            if (String.IsNullOrEmpty(hash))
                throw new ArgumentException(nameof(hash));

            var parts = hash.Split('.', 3);
            if (parts.Length != 3)
            {
                throw new FormatException("Inesperado formato de hash");
            }

            var iteraciones = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);


            using (var algorithm = new Rfc2898DeriveBytes(
             password,
             salt,
             iteraciones
            ))
            {
                var keyToCheck = algorithm.GetBytes(_config.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }


        /// <summary>
        /// Crea un hash
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Hash(string password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));

            //PBKDF2 IMPLEMENTACION
            using (var algorithm = new Rfc2898DeriveBytes(
             password,
             _config.SaltSize,
             _config.Iterations
            ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_config.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{_config.Iterations}.{salt}.{key}";
            }
        }
    }
}
