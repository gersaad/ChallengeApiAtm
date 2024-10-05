using ChallengeApiAtm.Modelos;

namespace ChallengeApiAtm.DTOs
{
    public class HistorialOperacionDTO
    {

        /// <summary>
        ///  Listado de operaciones encontradas
        /// </summary>
        public List<OperacionResponseDTO> Operaciones { get; set; }

        /// <summary>
        ///  Pagina actual de la consulta
        /// </summary>
        public int PaginaActual { get; set; }

        /// <summary>
        ///  Total de paginas para mostrar
        /// </summary>
        public int TotalPaginas { get; set; }

        /// <summary>
        ///  Total de operaciones 
        /// </summary>
        public int TotalOperaciones { get; set; }

    }
}
