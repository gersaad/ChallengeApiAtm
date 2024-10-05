using ChallengeApiAtm.DTOs;

namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface ICuentaRepository
    {
        Task<SaldoResponseDTO> ObtenerSaldoPorNroTarjeta(string numeroTarjeta);

        Task<RetiroResponseDTO> RetiroPorNroTarjeta(RetiroDTO retiro);
    }
}
