namespace ChallengeApiAtm.DTOs
{
    public class OperacionResponseDTO
    {

        /// <summary>
        ///  Tipo de Operacion (Extraccion / Deposito) 
        /// </summary>
        public string TipoOperacion { get; set; }

        /// <summary>
        ///  Monto de la operacion
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha de la operacion
        /// </summary>
        public DateTime Fecha { get; set; }

    }
}
