namespace ChallengeApiAtm.DTOs
{
    public class SaldoResponseDTO
    {
        /// <summary>
        ///  Nombre Usuario de la cuenta
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        ///  Numero de cuenta 
        /// </summary>
        public string NumeroCuenta { get; set; }

        /// <summary>
        ///  Saldo de la cuenta
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        ///   Fecha ultima extraccion
        /// </summary>
        public DateTime? FechaUltimaExtraccion { get; set; }
    }
}
