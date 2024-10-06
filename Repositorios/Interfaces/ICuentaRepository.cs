using ChallengeApiAtm.DTOs;

namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface ICuentaRepository
    {
        Task<SaldoResponseDTO> ObtenerSaldo();

        Task<RetiroResponseDTO> Retiro(decimal monto);
    }
}
