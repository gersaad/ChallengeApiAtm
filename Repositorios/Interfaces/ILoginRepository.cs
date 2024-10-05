using ChallengeApiAtm.DTOs;
using ChallengeApiAtm.Modelos;

namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface ILoginRepository
    {
        Task<string> Loguear(LoginDTO tarjeta);

    }
}
