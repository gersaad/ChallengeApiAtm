namespace ChallengeApiAtm.DTOs
{
    public class RetiroResponseDTO
    {
        /// <summary>
        ///  Numero de cuenta 
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        ///  Monto extraido
        /// </summary>
        public decimal MontoRetirado { get; set; }

        /// <summary>
        ///  Saldo restante 
        /// </summary>
        public decimal SaldoRestante { get; set; }

        /// <summary>
        ///   Fecha operacion realizada
        /// </summary>
        public DateTime FechaOperacion { get; set; }
        
        /// <summary>
        ///  Estado de Operacion
        /// </summary>
        public string EstadoOperacion { get; set; }
    }
}
