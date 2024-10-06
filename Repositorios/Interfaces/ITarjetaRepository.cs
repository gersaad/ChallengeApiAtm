using ChallengeApiAtm.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeApiAtm.Repositorios.Interfaces
{
    public interface ITarjetaRepository
    {
        Task<HistorialOperacionDTO> ObtenerHistorialTarjeta(int pagina, int registrosPorPagina);
    }
}
