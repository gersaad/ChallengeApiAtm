using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;

namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface ILoginRepository
    {
        public Task<string> Loguear(LoginDTO tarjeta);

    }
}
